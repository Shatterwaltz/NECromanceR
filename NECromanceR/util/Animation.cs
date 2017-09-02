using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NECromanceR.util {
    class Animation {
        private Texture2D spriteSheet;
        private int startFrame;
        private int endFrame;
        private int currentFrame;
        public int FrameHeight;
        public int FrameWidth;
        float scale;
        private Color tint;
        private int frameDuration;
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
        public void Initialize(Texture2D spriteSheet, int startFrame, int endFrame, int frameHeight, int frameWidth, int frameDuration, float scale, bool loops, bool active, Color tint) {
            this.spriteSheet = spriteSheet;
            this.startFrame = startFrame;
            this.endFrame = endFrame;
            FrameHeight = frameHeight;
            FrameWidth = frameWidth;
            this.frameDuration = frameDuration;
            this.scale = scale;
            Loops = loops;
            Active = active;
            this.tint = tint;
            this.currentFrame = startFrame;
        }

        public void Update() {
            if (Active) {

            }
        }

        /// <summary>
        /// Given a spritebatch to add to and a position, will add correct frame to spritebatch with the target coordinates. 
        /// </summary>
        /// <param name="spriteBatch">Spritebatch to use</param>
        /// <param name="position">Coordinates to draw sprite at, from top left corner</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position) {
            spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X, (int)position.Y, (int)(position.X + FrameWidth * scale), (int)(position.Y + FrameHeight * scale)),
                new Rectangle(currentFrame * FrameWidth, 0, currentFrame * FrameWidth + FrameWidth, FrameHeight), tint);
        }

    }
}
