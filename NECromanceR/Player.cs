using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Player {

        //Player spritesheet
        private Texture2D spriteSheet;
        //Track keyboard
        private KeyboardState currentKeyState;
        private KeyboardState prevKeyState;
        //Player's move speed
        private float speed;
        private Vector2 velocity;
        //Player's position in world coordinates
        public Vector2 Position;
        //Dictionary of player's animations
        private Dictionary<String, Animation> animations = new Dictionary<string, Animation>();
        //Currently playing animation 
        private Animation currentAnimation;

        public void Initialize(Texture2D spriteSheet) {
            this.spriteSheet = spriteSheet;

            speed = 5f;

            animations.Add("Idle", new Animation());
            animations.Add("Left", new Animation());
            animations.Add("Right", new Animation());
            animations.Add("Down", new Animation());
            animations.Add("Up", new Animation());

            animations["Idle"].Initialize(spriteSheet, 0, 0, 32, 32, 30, 1f, true, true, Color.White);
            animations["Left"].Initialize(spriteSheet, 7, 8, 32, 32, 30, 1f, true, true, Color.White);
            animations["Right"].Initialize(spriteSheet, 3, 4, 32, 32, 30, 1f, true, true, Color.White);
            animations["Up"].Initialize(spriteSheet, 1, 2, 32, 32, 30, 1f, true, true, Color.White);
            animations["Down"].Initialize(spriteSheet, 5, 6, 32, 32, 30, 1f, true, true, Color.White);
        }

        public void Update(GameTime gameTime) {
            prevKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            velocity = Vector2.Zero;

            if(currentKeyState.IsKeyDown(Keys.A)) {
                velocity.X -= speed;
            }
            if(currentKeyState.IsKeyDown(Keys.D)) {
                velocity.X += speed;
            }
            if(currentKeyState.IsKeyDown(Keys.W)){
                velocity.Y -= speed;
            }
            if(currentKeyState.IsKeyDown(Keys.S)) {
                velocity.Y += speed;
            }

            Position += velocity;

            if(velocity.Y < 0) {
                currentAnimation = animations["Up"];
            } else if(velocity.Y > 0) {
                currentAnimation = animations["Down"];
            }
            if(velocity.X > 0) {
                currentAnimation = animations["Right"];
            } else if(velocity.X < 0) {
                currentAnimation = animations["Left"];
            }
            if(velocity.Y == 0 && velocity.X == 0) {
                currentAnimation = animations["Idle"];
            }
            
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            currentAnimation.Draw(spriteBatch, Position);
        }

    }
}
