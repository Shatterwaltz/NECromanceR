using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NECromanceR {
    public class Player : GameEntity{

        //Position inherited from GameEntity class
        
        //Player spritesheet
        private Texture2D spriteSheet;
        //Track keyboard
        private KeyboardState currentKeyState;
        private KeyboardState prevKeyState;
        //Player's move speed
        private float speed;
        private Vector2 velocity;
        
        private AnimationHandler animationHandler;
        private Camera camera;

        private HitboxHandler hitHandler;


        RectangularHitbox r;
        public void Initialize(Texture2D spriteSheet, Camera camera) {
            this.spriteSheet = spriteSheet;
            this.camera = camera;
            //HITEXAMPLE: get hitboxhandler instance
            hitHandler = HitboxHandler.GetInstance();
            //HITEXAMPLE: define a hitbox, add to handler
            r = new RectangularHitbox(this, Vector2.Zero, 32, 32);
            hitHandler.AddHitbox(r, "player");
            speed = 5f;
            
            //Set properties of each animation
            animationHandler = new AnimationHandler("Idle", spriteSheet, 0, 0, 32, 32, 30, 1f, true);
            animationHandler.AddAnimation("Left", spriteSheet, 7, 8, 32, 32, 500, 1f, true);
            animationHandler.AddAnimation("Right", spriteSheet, 3, 4, 32, 32, 500, 1f, true);
            animationHandler.AddAnimation("Up", spriteSheet, 1, 2, 32, 32, 500, 1f, true);
            animationHandler.AddAnimation("Down", spriteSheet, 5, 6, 32, 32, 500, 1f, true);
            animationHandler.AddAnimation("AttackDown", spriteSheet, 15, 15, 32, 32, 600, 1f, false, 1, false, "Idle");
            animationHandler.AddAnimation("AttackUp", spriteSheet, 13, 13, 32, 32, 600, 1f, false, 1, false, "Idle");
            animationHandler.AddAnimation("AttackLeft", spriteSheet, 16, 16, 32, 32, 600, 1f, false, 1, false, "Idle");
            animationHandler.AddAnimation("AttackRight", spriteSheet, 14, 14, 32, 32, 600, 1f, false, 1, false, "Idle");
            animationHandler.AddAnimation("HurtDown", spriteSheet, 11, 11, 32, 32, 300, 1f, false, 2, false, "Idle");
            animationHandler.AddAnimation("HurtUp", spriteSheet, 9, 9, 32, 32, 300, 1f, false, 2, false, "Idle");
            animationHandler.AddAnimation("HurtLeft", spriteSheet, 12, 12, 32, 32, 300, 1f, false, 2, false, "Idle");
            animationHandler.AddAnimation("HurtRight", spriteSheet, 10, 10, 32, 32, 300, 1f, false, 2, false, "Idle");
        }

        public override void Update(GameTime gameTime) {
            prevKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();

            //Set velocity to zero and then modify based on input
            velocity = Vector2.Zero;

            if(currentKeyState.IsKeyDown(Keys.A)) {
                velocity.X -= speed;
            }
            if(currentKeyState.IsKeyDown(Keys.D)) {
                velocity.X += speed;
            }
            if(currentKeyState.IsKeyDown(Keys.W)) {
                velocity.Y -= speed;
            }
            if(currentKeyState.IsKeyDown(Keys.S)) {
                velocity.Y += speed;
            }

            //If an attack key is pressed, set state to attacking and queue correct attack animation
            if(currentKeyState.IsKeyDown(Keys.Down)) {
                animationHandler.PlayAnimation("AttackDown");
            } else if(currentKeyState.IsKeyDown(Keys.Up)) {
                animationHandler.PlayAnimation("AttackUp");
            } else if(currentKeyState.IsKeyDown(Keys.Left)) {
                animationHandler.PlayAnimation("AttackLeft");
            } else if(currentKeyState.IsKeyDown(Keys.Right)) {
                animationHandler.PlayAnimation("AttackRight");
            }

            //Halt player movement during attacking or receiving damage animations
            if(animationHandler.CurrentAnimation.Name.Contains("Attack") || animationHandler.CurrentAnimation.Name.Contains("Hurt")) {
                velocity = Vector2.Zero;
            }

            //Set movement animation based on velocity
            if(velocity.X < 0) {
                animationHandler.PlayAnimation("Left");
            } else if(velocity.X > 0) {
                animationHandler.PlayAnimation("Right");
            } else if(velocity.Y > 0) {
                animationHandler.PlayAnimation("Down");
            } else if(velocity.Y < 0) {
                animationHandler.PlayAnimation("Up");
            }

            //If not motion, attempt to play idle animation. 
            if(velocity.Y == 0 && velocity.X == 0) {
               animationHandler.PlayAnimation("Idle");
            }

            //Update player position
            Position += velocity;

            //Update animation
            animationHandler.Update(gameTime);

            //Update hitbox
            r.Update(gameTime);
            Console.WriteLine(r.WorldCoords + " " + r.Box.Width + " "+r.Box.Height);

            //HITEXAMPLE: if player collides with a test hitbox, play the attack right animation
            if(hitHandler.IsColliding("player", "test")!=null) {
                animationHandler.PlayAnimation("AttackRight");
            }
        }

        public override void Draw(CulledSpriteBatch spriteBatch) {
            animationHandler.Draw(spriteBatch, Position, camera);
        }

    }
}
