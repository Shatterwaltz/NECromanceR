using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class RectangularHitbox : Hitbox {
        public Rectangle Box { get; set; }

        public RectangularHitbox () : base() {
            Box = new Rectangle( WorldCoords.X, WorldCoords.Y, 0, 0 );
        }

        public RectangularHitbox ( Rectangle box ) : base( box.X, box.Y ) {

        }

        public RectangularHitbox ( int x, int y, int width, int height ) : base( x, y ) {
            Box = new Rectangle( x, y, width, height );
        }

        /// <summary>
        /// Checks for a collision between the calling RectangularHitbox and a <see cref="CircularHitbox"/>
        /// </summary>
        /// <param name="other">The <see cref="CircularHitbox"/> that this RectangularHitbox collides with</param>
        /// <returns><code>true</code> if a collision occured between the calling RectangularHitbox and the <see cref="CircularHitbox"/></returns>
        public override bool CheckCollision ( CircularHitbox other ) {
            bool collision = false;
            Point rectCenter = new Point( Box.X + Box.Width/2, Box.Y + Box.Height/2 );
            double distance = Math.Sqrt( Math.Pow( Box.X - other.WorldCoords.X, 2 ) + Math.Pow( Box.Y - other.WorldCoords.Y, 2 ) );
            // Need to find intersection between line and side of the calling RectangularHitbox
            // If distance between this point and the center of the CircularHitbox is less than the CircularHitbox's radius, there is a collision
            return collision;
        }

        /// <summary>
        /// Checks for a collision between the calling RectangularHitbox and another <see cref="RectangularHitbox"/>
        /// </summary>
        /// <param name="other">The <see cref="RectangularHitbox"/> that this RectangularHitbox collides with</param>
        /// <returns><code>true</code> if a collision occured between the calling RectangularHitbox and the other <see cref="RectangularHitbox"/></returns>
        public override bool CheckCollision ( RectangularHitbox other ) {
            return Box.Intersects( other.Box );
        }

        public override string ToString () {
            return string.Format( "[RectangularHitbox: (X: {0}) (Y: {1}) (Width: {3}) (Height: {4})]", 
                                  WorldCoords.X, WorldCoords.Y, Box.Width, Box.Height );
        }
    }
}
