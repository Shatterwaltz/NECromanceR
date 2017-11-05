using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace NECromanceR {
    public abstract class Hitbox {
        public Point WorldCoords { get; set; }

        public HitboxType HitboxType { get; protected set; }

        protected Hitbox () {
            WorldCoords = new Point( 0, 0 );
        }

        protected Hitbox ( Point worldCoords ) {
            WorldCoords = worldCoords;
        }

        protected Hitbox ( int x, int y ) {
            WorldCoords = new Point( x, y );
        }
        //public Rectangle HitboxRect { get; set; }
        //
        //public Hitbox(Rectangle hitboxRect) {
        //    HitboxRect = hitboxRect;
        //}

        //public override string ToString () {
        //    return string.Format( "[Hitbox: (X: {0}) (Y: {1}) (Width: {2}) (Height: {3})]", 
        //                          HitboxRect.X, HitboxRect.Y, HitboxRect.Width, HitboxRect.Height );
        //}

        public abstract bool CheckCollision(Hitbox other);
    }
    public enum HitboxType {
        RECTANGLE,
        CIRCLE
    }
}
