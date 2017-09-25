using Microsoft.Xna.Framework;
using System; 
namespace NECromanceR {
    class Camera {
        
        public Vector2 Position { get; set; }
        public Vector2 Viewport { get; set; }

        public Camera(Vector2 position, Vector2 viewport) {
            Viewport = viewport;
            Position = position;
        }

        public Camera(int x, int y, Vector2 viewport) {
            Viewport = viewport;
            Position = new Vector2(x, y);
        }

        public Camera(int x, int y, int width, int height) {
            Viewport = new Vector2(width, height);
            Position = new Vector2(x, y);
        }

        public Vector2 LookAt(Vector2 worldCoordinates) {
            Position = new Vector2(worldCoordinates.X - Viewport.X / 2, worldCoordinates.Y - Viewport.Y / 2);
            return Position;
        }

    }
}
