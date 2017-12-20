using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class CircularHitbox: Hitbox {
        public float Radius { get; set; }

        public CircularHitbox(Vector2 worldCoords, float radius) : base(worldCoords) {
            HitboxType = HitboxType.CIRCLE;
            Radius = radius;
            WorldCoords = worldCoords;
        }

        public CircularHitbox(int x, int y, float radius) : base(new Vector2(x, y)) {
            HitboxType = HitboxType.CIRCLE;
            Radius = radius;
            WorldCoords = WorldCoords;
        }

        /// <summary>
        /// create a circular hitbox attached to parent, positioned at parent position plus offset. 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="offset"></param>
        /// <param name="radius"></param>
        public CircularHitbox(GameEntity parent, Vector2 offset, float radius) : base(parent, offset) {
            HitboxType = HitboxType.CIRCLE;
            Radius = radius;
            WorldCoords = parent.Position + offset;
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

        public override void Update(GameTime gameTime) {
            //Move hitbox with parent object
            WorldCoords = parent.Position + OffsetFromParent;
        }
    }
}
