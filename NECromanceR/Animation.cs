using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NECromanceR {
    class Animation {
        private Texture2D spriteSheet;
        private int startFrame;
        private int endFrame;
        private int currentFrame;
        public int FrameHeight;
        public int FrameWidth;
        private float scale;
        private Color tint;
        private int frameDuration;
        private int elapsedTime;
        public bool Loops;
        public bool Active;

        /// <summary>
        /// Initializes an Animation object for use.
        /// </summary>
        /// <param name="spriteSheet">Horizontal strip containing each frame for this animation.</param>
        /// <param name="startFrame">First frame of the animation. Zero-indexed.</param>
        /// <param name="endFrame">Last frame of the animation. Zero-indexed.</param>
        /// <param name="frameHeight">Height of a single frame.</param>
        /// <param name="frameWidth">Width of a single frame. </param>
        /// <param name="frameDuration">How long each frame should be displayed in ms. </param>
        /// <param name="scale">Multiplicatively scale the height/width of the frame. </param>
        /// <param name="loops">Flag determining if animation should loop</param>
        /// <param name="active">Flag determining if animation should be playing or not. </param>
        /// <param name="tint">Color to apply to animation. </param>
        public void Initialize(Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth, int frameDuration,
            float scale, bool loops, Color tint) {
            this.spriteSheet = spriteSheet;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            FrameHeight = frameHeight;
            FrameWidth = frameWidth;
            this.frameDuration = frameDuration;
            this.scale = scale;
            Loops = loops;
            Active = true;
            this.tint = tint;
            this.currentFrame = startFrame;
        }

        public void Update(GameTime gameTime) {
            if(!Active) {
                return;
            }
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapsedTime > frameDuration) {
                currentFrame++;
                if(currentFrame > endFrame) {
                    currentFrame = startFrame;
                    if(!Loops) {
                        Active = false;
                    }
                }

                elapsedTime = 0;
            }
        }

        //Jumps animation back to beginning
        public void Restart() {
            currentFrame = startFrame;
            elapsedTime = 0;
            Active = true;
        }

        /// <summary>
        /// Given a spritebatch to add to and a position, will add correct frame to spritebatch with the target coordinates. 
        /// </summary>
        /// <param name="spriteBatch">Spritebatch to use</param>
        /// <param name="position">Coordinates to draw sprite at, from top left corner</param>
        public void Draw(CulledSpriteBatch spriteBatch, Vector2 position, Camera camera) {
            spriteBatch.DrawByCamera(spriteSheet, new Rectangle((int)position.X, (int)position.Y, (int)(FrameWidth * scale), (int)(FrameHeight * scale)),
                new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight), camera, tint);
        }

    }
}
