using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        /* These are C# properties - 
           behind the scenes, the compiler is generating
           two fields called 'position' and 'viewport' and 
           getters and setters for both. */
        private Vector2 position;
        public Vector2 Position {
            get { return position; }
            set {
                position = value;
                LookAt( position );
            }
        }
        public Vector2 Viewport { get; set; }

        public Camera ( Vector2 position, Vector2 viewport ) {
            LookAt(position);
            Viewport = viewport;
        }

        public Camera ( int x, int y, Vector2 viewport ) {
            LookAt(new Vector2( x, y ));
            this.Viewport = viewport;
        }

        public Camera ( int x, int y, int width, int height ) {
            LookAt(new Vector2( x, y ));
            Viewport = new Vector2( width, height );
        }

        // After LookAt is called on something's position, camera's position can be used
        // to calculate screen coordinates by subtracting it from an entity's position.
        public Vector2 LookAt ( Vector2 worldCoordinates ) {
            Position = new Vector2( worldCoordinates.X - Viewport.X / 2, worldCoordinates.Y - Viewport.Y / 2 );
            return Position;
        }

    }
}
