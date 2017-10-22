using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class CulledSpriteBatch: SpriteBatch {
        public CulledSpriteBatch(GraphicsDevice graphicsDevice) : base(graphicsDevice) {
        }


        /// <summary>
        /// DrawByCamera() draws the target sprite in relation to the camera's position. moving the camera will cause the sprite to fall off screen. 
        /// Culling is also implemented through this, sprites that are offscreen will not be drawn. 
        /// </summary>
        /// <param name="texture">Texture to be drawn</param>
        /// <param name="destination">Rectangle detailing position and size of area to draw texture</param>
        /// <param name="source">Rectangle detailing which part of texture to draw</param>
        /// <param name="camera">Camera object to draw in relation to</param>
        /// <param name="color">Color to tint sprite</param>
        public void DrawByCamera(Texture2D texture, Rectangle destination, Rectangle source, Camera camera, Color color) {
            /* Check if destination overlaps camera view...
               If so, call base.Draw(spriteSheet, destination, source, color)
               otherwise return */

            if((destination.X > camera.Position.X && destination.X < camera.Position.X + camera.Viewport.X) ||
                 (destination.X + destination.Width > camera.Position.X && destination.X + destination.Width < camera.Position.X + camera.Viewport.X)) {
                if((destination.Y > camera.Position.Y && destination.Y < camera.Position.Y + camera.Viewport.Y) ||
                     (destination.Y + destination.Height > camera.Position.Y && destination.Y + destination.Height < camera.Position.Y + camera.Viewport.Y)) {
                    Draw(texture, new Rectangle((int)(destination.X - camera.Position.X), (int)(destination.Y - camera.Position.Y), destination.Width, destination.Height),
                        source, color);
                }
            }
        }
        
    }
}
