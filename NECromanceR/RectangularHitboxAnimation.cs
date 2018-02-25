using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECromanceR {
    public class RectangularHitboxAnimation : HitboxAnimation {

        #region Private Fields
        private RectangularHitbox hitbox;
        #endregion

        #region Public Fields
        /// <summary>
        /// <para>A <code>KeyFrame</code> object associated specifically with <see cref="RectangularHitboxAnimation"/>.</para>
        /// </summary>
        public struct KeyFrame {
            public int FrameNumber { get; set; }
            public Vector2 Offset { get; set; }
            public int FrameWidth { get; set; }
            public int FrameHeight { get; set; }
            public KeyFrame ( int frameNumber, Vector2 offset, int frameWidth, int frameHeight ) {
                FrameNumber = frameNumber;
                Offset = offset;
                FrameWidth = frameWidth;
                FrameHeight = frameHeight;
            }
            public KeyFrame ( int frameNumber, int xOffset, int yOffset, int frameWidth, int frameHeight ) {
                FrameNumber = frameNumber;
                Offset = new Vector2( xOffset, yOffset );
                FrameWidth = frameWidth;
                FrameHeight = frameHeight;
            }
        }
        public KeyFrame[] KeyFrames { get; set; }
        #endregion

        #region Constructor
        public RectangularHitboxAnimation ( RectangularHitbox interactingHitbox, KeyFrame[] keyFrames ) : base( interactingHitbox, HitboxType.RECTANGLE ) {
            hitbox = interactingHitbox;
            KeyFrames = keyFrames;
        }
        #endregion

        #region Inherited Methods
        public override void Update ( int currentFrame ) {
            for ( int i = KeyFrames.Length - 1; i > 0; --i ) {
                if ( KeyFrames[i].FrameNumber <= currentFrame ) {
                    hitbox.OffsetFromParent = KeyFrames[i].Offset;
                    hitbox.Box = new Rectangle( 
                        ( int ) ( hitbox.parent.Position.X + hitbox.OffsetFromParent.X ), 
                        ( int ) ( hitbox.parent.Position.Y + hitbox.OffsetFromParent.Y ), 
                        KeyFrames[i].FrameWidth, 
                        KeyFrames[i].FrameHeight 
                    );
                }
            }
        }
        #endregion

    }
}
