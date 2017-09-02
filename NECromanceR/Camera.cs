using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        public Vector2 Position;
        private Vector2 Viewport;

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

        public Vector2 LookAt ( Vector2 worldCoordinates ) {
            Position = new Vector2( worldCoordinates.X - Viewport.X/2, worldCoordinates.Y - Viewport.Y/2 );
            return Position;
        }

    }
}
