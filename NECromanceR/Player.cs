using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NECromanceR {
    class Player {
        private Camera camera;
        //Player spritesheet
        private Texture2D spriteSheet;
        //Track keyboard
        private KeyboardState currentKeyState;
        private KeyboardState prevKeyState;
        //Player's move speed
        private float speed;
        private Vector2 velocity;
        private bool attacking;
        //Player's position in world coordinates
        public Vector2 Position;
        //Dictionary of player's animations
        private Dictionary<String, Animation> animations = new Dictionary<string, Animation>();
        //Currently playing animation 
        private Animation currentAnimation;

        public void Initialize(Texture2D spriteSheet, Camera camera) {
            this.camera = camera;
            this.spriteSheet = spriteSheet;

            speed = 5f;
            attacking = false;

            //Add animations to dictionary
            animations.Add("Idle", new Animation());
            animations.Add("Left", new Animation());
            animations.Add("Right", new Animation());
            animations.Add("Down", new Animation());
            animations.Add("Up", new Animation());
            animations.Add("AttackDown", new Animation());
            animations.Add("AttackUp", new Animation());
            animations.Add("AttackLeft", new Animation());
            animations.Add("AttackRight", new Animation());

            //Set properties of each animation
            animations["Idle"].Initialize(spriteSheet, 0, 0, 32, 32, 30, 1f, true,  Color.White);
            animations["Left"].Initialize(spriteSheet, 7, 8, 32, 32, 500, 1f, true, Color.White);
            animations["Right"].Initialize(spriteSheet, 3, 4, 32, 32, 500, 1f, true,  Color.White);
            animations["Up"].Initialize(spriteSheet, 1, 2, 32, 32, 500, 1f, true, Color.White);
            animations["Down"].Initialize(spriteSheet, 5, 6, 32, 32, 500, 1f, true, Color.White);
            animations["AttackDown"].Initialize(spriteSheet, 15, 15, 32, 32, 600, 1f, false, Color.White);
            animations["AttackUp"].Initialize(spriteSheet, 13, 13, 32, 32, 600, 1f, false, Color.White);
            animations["AttackLeft"].Initialize(spriteSheet, 16, 16, 32, 32, 600, 1f, false, Color.White);
            animations["AttackRight"].Initialize(spriteSheet, 14, 14, 32, 32, 600, 1f, false, Color.White);

            //Start in Idle by default
            currentAnimation = animations["Idle"];
        }

        public void Update(GameTime gameTime) {
            prevKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            //Change state back to normal and begin idling
            //when attack animation completes
            if(attacking && !currentAnimation.Active) {
                attacking = false;
                currentAnimation.Restart();
                currentAnimation = animations["Idle"];
            }

            //If keystate has changed and player is not attacking, 
            //restart the animation before beginning a new one.
            if(prevKeyState!=currentKeyState && !attacking) {
                currentAnimation.Restart();
            }

            //Set velocity to zero and then modify based on input
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
            
            //If an attack key is pressed, set state to attacking and queue correct attack animation
            if(currentKeyState.IsKeyDown(Keys.Down) && !attacking) {
                attacking = true;
                currentAnimation = animations["AttackDown"];
            } else if(currentKeyState.IsKeyDown(Keys.Up) && !attacking) {
                attacking = true;
                currentAnimation = animations["AttackUp"];
            } else if(currentKeyState.IsKeyDown(Keys.Left) && !attacking) {
                attacking = true;
                currentAnimation = animations["AttackLeft"];
            }else if(currentKeyState.IsKeyDown(Keys.Right) && !attacking) {
                attacking = true;
                currentAnimation = animations["AttackRight"];
            }

            //Halt player movement during attack animation
            if(attacking) {
                velocity = Vector2.Zero;
            }

            //Set movement animation based on velocity
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

            //If not attacking or in motion, idle. 
            if(velocity.Y == 0 && velocity.X == 0 && !attacking) {
                currentAnimation = animations["Idle"];
            }

            //Update player position
            Position += velocity;

            //Update animation
            currentAnimation.Update(gameTime);
        }

        public void Draw(CulledSpriteBatch spriteBatch) {
            currentAnimation.Draw(spriteBatch, Position, camera);
        }

    }
}
