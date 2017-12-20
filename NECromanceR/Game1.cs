using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace NECromanceR {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1: Game {
        GraphicsDeviceManager graphics;
        CulledSpriteBatch spriteBatch;
        Camera camera;
        Player player = new Player();

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            //default res to 640x480
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            //HITEXAMPLE: Grab handler instance
            HitboxHandler hithandle = HitboxHandler.GetInstance();
            //HITEXAMPLE: add two hitboxes under the tag "test"
            hithandle.AddHitbox(new RectangularHitbox(50,0,50,50), "test");
            hithandle.AddHitbox(new CircularHitbox(200, 200, 10), "test");

            camera = new Camera(Vector2.Zero, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            player.Initialize(Content.Load<Texture2D>("MovePlaceholder"), camera);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new CulledSpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime);

            //HITEXAMPLE: Check if any hitbox from player is colliding with a hitbox from circle. If this occurs, delete the colliding box from circle.
            Tuple<Hitbox, Hitbox> pair = HitboxHandler.GetInstance().IsColliding("player", "test");
            if(pair != null)
                HitboxHandler.GetInstance().DeleteHitbox(pair.Item2, "test");
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
