using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class CircularHitbox: Hitbox {
        public float Radius { get; set; }

        public CircularHitbox(Point worldCoords, float radius) : base(worldCoords) {
            HitboxType = HitboxType.CIRCLE;
            Radius = radius;
        }

        public CircularHitbox(int x, int y, float radius) : base(x, y) {
            HitboxType = HitboxType.CIRCLE;
            Radius = radius;
        }

        public override bool CheckCollision(Hitbox other) {
            if(other.HitboxType == HitboxType.CIRCLE)
                return CheckCollision((CircularHitbox)other);
            else if(other.HitboxType == HitboxType.RECTANGLE)
                return CheckCollision((RectangularHitbox)other);
            else
                return false;
        }

        public bool CheckCollision(CircularHitbox other) {
            return Math.Sqrt(Math.Pow(WorldCoords.X - other.WorldCoords.X, 2) + Math.Pow(WorldCoords.Y - other.WorldCoords.Y, 2)) < Radius + other.Radius;
        }

        public bool CheckCollision(RectangularHitbox other) {
            //Get point in rectangle that is closest to circle center
            float closestX = MathHelper.Clamp(WorldCoords.X, other.WorldCoords.X, other.WorldCoords.X + other.Box.Width);
            float closestY = MathHelper.Clamp(WorldCoords.Y, other.WorldCoords.Y, other.WorldCoords.Y + other.Box.Width);

            //Get distance from circle to that point
            float distX = WorldCoords.X - closestX;
            float distY = WorldCoords.Y - closestY;

            //If distance<radius, we have an intersection
            //Using a^2+b^2=c^2
            float distanceSquared = distX * distX + distY + distY;
            return distanceSquared < (Radius*Radius);
        }

        public override string ToString() {
            return string.Format("[CircularHitbox: (X: {0}) (Y: {1}) (Radius: {3})]",
                                  WorldCoords.X, WorldCoords.Y, Radius);
        }
    }
}
