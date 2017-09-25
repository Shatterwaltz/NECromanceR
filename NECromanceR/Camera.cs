using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        private Vector2 position;
        public Vector2 Position {
            get { return position; }
            set {
                position = new Vector2(value.X - Viewport.X / 2, value.Y - Viewport.Y / 2);
            }
        }
        public Vector2 Viewport { get; set; }

        public Camera(Vector2 position, Vector2 viewport) {
            Position = position;
            Viewport = viewport;
        }

        public Camera(int x, int y, Vector2 viewport) {
            Position = position;
            this.Viewport = viewport;
        }

        public Camera(int x, int y, int width, int height) {
            Position = position;
            Viewport = new Vector2(width, height);
        }

    }
}
