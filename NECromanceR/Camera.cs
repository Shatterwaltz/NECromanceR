using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Camera {

        public Vector2 Position;
        public Vector2 Viewport;

        public Camera(Vector2 position, Vector2 viewport) {
            this.Position = position;
            this.Viewport = viewport;
        }

        public Camera(int x, int y, Vector2 viewport) {
            this.Position = new Vector2(x, y);
            this.Viewport = viewport;
        }

        public Camera(int x, int y, int width, int height) {
            this.Position = new Vector2(x, y);
            this.Viewport = new Vector2(width, height);
        }

        //After LookAt is called on something's position, camera's position can be used
        //to calculate screen coordinates by subtracting it from an entity's position.
        public Vector2 LookAt(Vector2 worldCoordinates) {
            Position = new Vector2(worldCoordinates.X - Viewport.X / 2, worldCoordinates.Y - Viewport.Y / 2);
            return Position;
        }

    }
}
