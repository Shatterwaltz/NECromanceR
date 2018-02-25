using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public abstract class HitboxAnimation {

        #region Private Fields
        // All other fields handled by base animation class
        private int currentFrame;
        private float scale;
        #endregion

        #region Public Fields
        public HitboxType Type { get; protected set; }
        public Hitbox InteractingHitbox { get; protected set; }
        #endregion

        #region Constructor
        public HitboxAnimation ( Hitbox interactingHitbox, HitboxType type ) {
            InteractingHitbox = interactingHitbox;
            Type = type;
        }
        #endregion

        public abstract void Update ( int currentFrame );

    }
}
