using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace NECromanceR {
    public class Hitbox {
        public Rectangle HitboxRect { get; set; }

        public Hitbox(Rectangle hitboxRect) {
            HitboxRect = hitboxRect;
        }

        public override string ToString () {
            return string.Format( "[Hitbox: (X: {0}) (Y: {1}) (Width: {2}) (Height: {3})]", 
                                  HitboxRect.X, HitboxRect.Y, HitboxRect.Width, HitboxRect.Height );
        }
    }
}
