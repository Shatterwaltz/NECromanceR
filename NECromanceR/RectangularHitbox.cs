using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class RectangularHitbox: Hitbox {
        public Rectangle Box { get; set; }

        public RectangularHitbox(Rectangle box) : base(box.X, box.Y) {
            HitboxType = HitboxType.RECTANGLE;
            Box = box;
        }

        public RectangularHitbox(int x, int y, int width, int height) : base(x, y) {
            HitboxType = HitboxType.RECTANGLE;
            Box = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Accepts a generic Hitbox and returns boolean indicating intersection with this hitbox. 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool CheckCollision(Hitbox other) {
            if(other.HitboxType == HitboxType.CIRCLE)
                return CheckCollision((CircularHitbox)other);
            else if(other.HitboxType == HitboxType.RECTANGLE)
                return CheckCollision((RectangularHitbox)other);
            else
                return false;
        }


        /// <summary>
        /// Checks for a collision between the calling RectangularHitbox and a <see cref="CircularHitbox"/>
        /// </summary>
        /// <param name="other">The <see cref="CircularHitbox"/> that this RectangularHitbox collides with</param>
        /// <returns><code>true</code> if a collision occured between the calling RectangularHitbox and the <see cref="CircularHitbox"/></returns>
        public bool CheckCollision(CircularHitbox other) {
            //Get point in rectangle that is closest to circle center
            float closestX = MathHelper.Clamp(other.WorldCoords.X, WorldCoords.X, WorldCoords.X + Box.Width);
            float closestY = MathHelper.Clamp(other.WorldCoords.Y, WorldCoords.Y, WorldCoords.Y + Box.Width);

            //Get distance from circle to that point
            float distX = other.WorldCoords.X - closestX;
            float distY = other.WorldCoords.Y - closestY;

            //If distance<radius, we have an intersection
            //Using a^2+b^2=c^2
            float distanceSquared = distX * distX + distY + distY;
            return distanceSquared < (other.Radius * other.Radius);
        }

        /// <summary>
        /// Checks for a collision between the calling RectangularHitbox and another <see cref="RectangularHitbox"/>
        /// </summary>
        /// <param name="other">The <see cref="RectangularHitbox"/> that this RectangularHitbox collides with</param>
        /// <returns><code>true</code> if a collision occured between the calling RectangularHitbox and the other <see cref="RectangularHitbox"/></returns>
        public bool CheckCollision(RectangularHitbox other) {
            return Box.Intersects(other.Box);
        }

        public override string ToString() {
            return string.Format("[RectangularHitbox: (X: {0}) (Y: {1}) (Width: {3}) (Height: {4})]",
                                  WorldCoords.X, WorldCoords.Y, Box.Width, Box.Height);
        }
    }
}
