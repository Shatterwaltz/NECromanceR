using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    class CulledSpriteBatch : SpriteBatch {
        public CulledSpriteBatch ( GraphicsDevice graphicsDevice ) : base( graphicsDevice ) {
        }

        public void Draw ( Texture2D texture, Rectangle destination, Rectangle source, Camera camera, Color color ) {
            /* Check if destination overlaps camera view...
               If so, call base.Draw(spriteSheet, destination, source, color)
               otherwise return */
            if ( ( destination.X > camera.Position.X && destination.X < camera.Position.X + camera.Viewport.X ) || 
                 ( destination.X + destination.Width > camera.Position.X && destination.X + destination.Width < camera.Position.X + camera.Viewport.X ) ) {
                if ( ( destination.Y > camera.Position.Y && destination.Y < camera.Position.Y + camera.Viewport.Y ) ||
                     ( destination.Y + destination.Height > camera.Position.Y && destination.Y + destination.Height < camera.Position.Y + camera.Viewport.Y ) ) {
                    Draw( texture, destination, source, color );
                }
            }
        }
    }
}
