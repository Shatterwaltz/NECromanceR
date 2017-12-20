using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace NECromanceR {
    public abstract class Hitbox {
        //Parent object
        public GameEntity parent;
        //Describes position in relation to parent object
        public Vector2 OffsetFromParent { get; set; }

        public Vector2 WorldCoords { get; protected set; }

        //Identifies if hitbox is a rectangle or circle
        public HitboxType HitboxType { get; protected set; }

        protected Hitbox(){
            WorldCoords = new Vector2(0, 0);
        }

        protected Hitbox(Vector2 worldCoords) {
            WorldCoords = worldCoords;
        }

        protected Hitbox(GameEntity parent) {
            WorldCoords = parent.Position;
            this.parent = parent;
        }

        protected Hitbox(GameEntity parent, Vector2 offset) {
            WorldCoords = parent.Position + offset;
            this.parent = parent;
            this.OffsetFromParent = offset;

        }



        public abstract bool CheckCollision(Hitbox other);

        public abstract void Update(GameTime gameTime);
    }
    public enum HitboxType {
        RECTANGLE,
        CIRCLE
    }
}
