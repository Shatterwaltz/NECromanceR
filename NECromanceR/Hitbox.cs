using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace NECromanceR {
    class Hitbox {
        public Rectangle HitboxRect { get; set; }

        public Hitbox(Rectangle hitboxRect) {
            HitboxRect = hitboxRect;
        }
    }
}
