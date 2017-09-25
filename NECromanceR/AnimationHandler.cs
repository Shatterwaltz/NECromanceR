using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NECromanceR {
    class AnimationHandler {
        //pairs an animation name with a tuple containing:
        //the relevant animation
        //A int indicating the priority of that animation
        //What animation should be played following the end of that animation
        private Dictionary<string, AnimationInfo> animations = new Dictionary<string, AnimationInfo>();
        public AnimationInfo CurrentAnimation { get; private set; }
        
        public AnimationHandler(string name, Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth,
            int frameDuration, float scale = 1f, bool loops = true, int priority = 0, bool cancelBySamePriority=true, string followupAnimation = null) {
            Animation anim = new Animation();
            anim.Initialize(spriteSheet, startFrame, endFrame, frameHeight, frameWidth, frameDuration, scale, loops, Color.White);
            animations.Add(name, new AnimationInfo(name, anim, priority, cancelBySamePriority, followupAnimation));

            CurrentAnimation = animations[name];
        }

        /// <summary>
        /// Adds an Animation object to the handler.
        /// </summary>
        /// <param name="name">Name of this animation</param>
        /// <param name="spriteSheet">Horizontal strip containing each frame for this animation.</param>
        /// <param name="startFrame">First frame of the animation. Zero-indexed.</param>
        /// <param name="endFrame">Last frame of the animation. Zero-indexed.</param>
        /// <param name="frameHeight">Height of a single frame.</param>
        /// <param name="frameWidth">Width of a single frame. </param>
        /// <param name="frameDuration">How long each frame should be displayed in ms. </param>
        /// <param name="scale">Multiplicatively scale the height/width of the frame. </param>
        /// <param name="loops">Flag determining if animation should loop</param>
        /// <param name="priority">A currently playing animation cannot be interupted by a lower priority animation </param>
        /// <param name="cancelBySamePriority">Determines if this animation can be cancelled by other animations of the same priority</param>
        /// <param name="followupAnimation">Animation to play after the current one finishes</param>
        public void AddAnimation(string name, Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth,
            int frameDuration, float scale = 1f, bool loops = true, int priority = 0, bool cancelBySamePriority = true, string followupAnimation = null) {
            Animation anim = new Animation();
            anim.Initialize(spriteSheet, startFrame, endFrame, frameHeight, frameWidth, frameDuration, scale, loops, Color.White);
            animations.Add(name, new AnimationInfo(name, anim, priority, cancelBySamePriority, followupAnimation));
        }

        /// <summary>
        /// Attempts to play the specified animation. 
        /// </summary>
        /// <param name="animationName">Name of animation to play</param>
        /// <returns>True when animation successfully queued, false if current animation is uninterruptible and underway. </returns>
        public bool PlayAnimation(String animationName) {
            return PlayAnimation(animations[animationName]);
        }


        public bool PlayAnimation(AnimationInfo animation) {
            //If animation is higher priority, or current one is inactive, or current animation allows cancelling by same priority animations, allow a new animation to be played
            if(animation.Priority > CurrentAnimation.Priority || !CurrentAnimation.Animation.Active || 
                (CurrentAnimation.Priority==animation.Priority && CurrentAnimation.CancelBySamePriority==true)) {
                if(CurrentAnimation != animation) {
                    CurrentAnimation.Animation.Restart();
                }
                CurrentAnimation = animation;
                return true;
            } else {
                return false;
            }
        }

        public void Update(GameTime gameTime) {
            if(!CurrentAnimation.Animation.Active && CurrentAnimation.FollowupAnimation != null) {
                PlayAnimation(animations[CurrentAnimation.FollowupAnimation]);
            }
            CurrentAnimation.Animation.Update(gameTime);
        }

        public void Draw(CulledSpriteBatch spriteBatch, Vector2 position, Camera camera) {
            CurrentAnimation.Animation.Draw(spriteBatch, position, camera);
        }
    }

    struct AnimationInfo{
        public string Name { get; set; }
        public Animation Animation { get; set; }
        public int Priority { get; set; }
        public string FollowupAnimation { get; set; }
        public bool CancelBySamePriority { get; set; }

        public AnimationInfo(string name, Animation animation, int priority=0, bool cancelBySamePriority=true, string followupAnimation = null) {
            Name = name;
            Animation = animation;
            Priority = priority;
            CancelBySamePriority = cancelBySamePriority;
            FollowupAnimation = followupAnimation;
        }

        public static bool operator ==(AnimationInfo a1, AnimationInfo a2) {
            return a1.Equals(a2);
        }

        public static bool operator !=(AnimationInfo a1, AnimationInfo a2) {
            return !a1.Equals(a2);
        }
    }
}
