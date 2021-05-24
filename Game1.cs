using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace RocketFramework
{
    public class Game1 : Game
    {
        public static GraphicsDevice device;
        private GraphicsAdapter adapter;
        private GraphicsProfile  graphicsProfile;
        private RigidBody2D bolinha,bolinha2;
        private PresentationParameters  presentationParameters;
        
        public Game1(){
            Content.RootDirectory = "Content";
            Global.graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphicsProfile = new GraphicsProfile();
            presentationParameters =  new PresentationParameters();

            adapter = new GraphicsAdapter();
            device = new GraphicsDevice(adapter,graphicsProfile,presentationParameters);

            bolinha = new RigidBody2D(this,new Vector2(10,50),Color.Orange, mass:0.2f);
            bolinha2 = new RigidBody2D(this,new Vector2(10,10), Color.CornflowerBlue, mass:0.5f);

            Rigidbody2D r = new Rigidbody2D();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Global.keyboard = new InputKeyboard();
            Global.content = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Global.keyboard.Update();
            bolinha.Update(gameTime);
            bolinha2.Update(gameTime);


            Global.keyboard.UpdateOld();
      
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Black);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            bolinha.Draw(gameTime);
            bolinha2.Draw(gameTime);

            Global.spriteBatch.End();
        }
    }
}
