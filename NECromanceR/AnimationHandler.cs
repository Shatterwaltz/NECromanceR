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
        private Dictionary<string, Tuple<Animation, int, String>> animations = new Dictionary<string, Tuple<Animation, int, String>>();
        public String CurrentAnimation;

        public AnimationHandler(String name, Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth,
            int frameDuration, float scale = 1f, bool loops = true, int priority = 0, String followupAnimation = null) {
            Animation anim = new Animation();
            anim.Initialize(spriteSheet, startFrame, endFrame, frameHeight, frameWidth, frameDuration, scale, loops, Color.White);
            animations.Add(name, new Tuple<Animation, int, String>(anim, priority, followupAnimation));

            CurrentAnimation = name;
        }

        /// <summary>
        /// Adds an Animation object to the handler.
        /// </summary>
        /// <param name="spriteSheet">Horizontal strip containing each frame for this animation.</param>
        /// <param name="startFrame">First frame of the animation. Zero-indexed.</param>
        /// <param name="endFrame">Last frame of the animation. Zero-indexed.</param>
        /// <param name="frameHeight">Height of a single frame.</param>
        /// <param name="frameWidth">Width of a single frame. </param>
        /// <param name="frameDuration">How long each frame should be displayed in ms. </param>
        /// <param name="priority">A currently playing animation cannot be interupted by a lower priority animation </param>
        /// <param name="scale">Multiplicatively scale the height/width of the frame. </param>
        /// <param name="loops">Flag determining if animation should loop</param>
        /// <param name="active">Flag determining if animation should be playing or not. </param>
        /// <param name="tint">Color to apply to animation. </param>
        /// <param name="followupAnimation">Animation to play after the current one finishes</param>
        public void AddAnimation(String name, Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth, 
            int frameDuration, float scale = 1f, bool loops = true, int priority = 0, String followupAnimation=null) {
            Animation anim = new Animation();
            anim.Initialize(spriteSheet, startFrame, endFrame, frameHeight, frameWidth, frameDuration, scale, loops, Color.White);
            animations.Add(name, new Tuple<Animation, int, String>(anim, priority, followupAnimation));
        }

        /// <summary>
        /// Attempts to play the specified animation. 
        /// </summary>
        /// <param name="animationName">Name of animation to play</param>
        /// <returns>True when animation successfully queued, false if current animation is uninterruptible and underway. </returns>
        public bool PlayAnimation(String animationName) {
            //If animation is higher priority, or current one is inactive, allow a new animation to be played
            if(animations[animationName].Item2>=animations[CurrentAnimation].Item2 || !animations[CurrentAnimation].Item1.Active) {
                if(CurrentAnimation != animationName) {
                    animations[CurrentAnimation].Item1.Restart();
                }
                CurrentAnimation = animationName;
                return true;
            } else {
                return false;
            }
        }

        public bool IsPlaying() {
            return animations[CurrentAnimation].Item1.Active;
        }

        public void Update(GameTime gameTime) {
            if(!animations[CurrentAnimation].Item1.Active && animations[CurrentAnimation].Item3 != null) {
                CurrentAnimation = animations[CurrentAnimation].Item3;
            }
            animations[CurrentAnimation].Item1.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) {
            animations[CurrentAnimation].Item1.Draw(spriteBatch, position);
        }
    }
}
