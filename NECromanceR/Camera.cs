using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        /* These are C# properties - 
           behind the scenes, the compiler is generating
           two fields called 'position' and 'viewport' and 
           getters and setters for both. */
        private Vector2 Position { get; set; }
        private Vector2 Viewport { get; set; }

        public Camera ( Vector2 position, Vector2 viewport ) {
            Position = position;
            Viewport = viewport;
        }

        public Camera ( int x, int y, Vector2 viewport ) {
            Position = new Vector2( x, y );
            this.Viewport = viewport;
        }

        public Camera ( int x, int y, int width, int height ) {
            Position = new Vector2( x, y );
            Viewport = new Vector2( width, height );
        }

        public void LookAt ( Vector2 worldCoordinates ) {
            Position = new Vector2( worldCoordinates.X - Viewport.X/2, worldCoordinates.Y - Viewport.Y/2 );
        }

    }
}
