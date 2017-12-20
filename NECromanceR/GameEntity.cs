using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NECromanceR {
    public abstract class GameEntity {
        //Location in world coords of this game entity
        public Vector2 Position { get; protected set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(CulledSpriteBatch spriteBatch);
    }
}
