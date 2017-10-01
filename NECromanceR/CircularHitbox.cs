using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class CircularHitbox : Hitbox {
        public float Radius { get; set; }

        public CircularHitbox () : base() {
            Radius = 0.0f;
        }

        public CircularHitbox ( Point worldCoords, float radius ) : base( worldCoords ) {
            Radius = radius;
        }

        public CircularHitbox ( int x, int y, float radius ) : base( x, y ) {
            Radius = radius;
        }

        public override bool CheckCollision ( CircularHitbox other ) {
            // TODO
            throw new NotImplementedException();
        }

        public override bool CheckCollision ( RectangularHitbox other ) {
            // TODO
            throw new NotImplementedException();
        }

        public override string ToString () {
            return string.Format( "[CircularHitbox: (X: {0}) (Y: {1}) (Radius: {3})]", 
                                  WorldCoords.X, WorldCoords.Y, Radius );
        }
    }
}
