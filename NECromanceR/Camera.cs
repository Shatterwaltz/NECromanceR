using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        private Vector2 Position { get { return Position; } set { Position = value; } }
        private Vector2 Viewport { get { return Viewport; } set { Viewport = value; } }

        public Camera ( Vector2 position, Vector2 viewport ) {
            this.Position = position;
            this.Viewport = viewport;
        }

        public Camera ( int x, int y, Vector2 viewport ) {
            this.Position = new Vector2( x, y );
            this.Viewport = viewport;
        }

        public Camera ( int x, int y, int width, int height ) {
            this.Position = new Vector2( x, y );
            this.Viewport = new Vector2( width, height );
        }

        public void LookAt ( Vector2 worldCoordinates ) {
            Position = new Vector2( worldCoordinates.X - Viewport.X/2, worldCoordinates.Y - Viewport.Y/2 );
        }

    }
}
