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
        private Line2D line;
        private PresentationParameters  presentationParameters;
        private Texture2D texture;
        private Basic2D basic;
        
        public Game1(){
            
            Content.RootDirectory = "Content";
            Global.content = Content;
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

            texture = Global.content.Load<Texture2D>("sprite");

            basic = new Basic2D("sprite", new Vector2(50,50),new Vector2(100,100));
            line = new Line2D(this);

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
            line.Update(gameTime);
            Global.keyboard.UpdateOld();
            basic.Update();
      
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.PapayaWhip);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);


            // Global.spriteBatch.Draw(
            //     texture, Vector2.Zero, null, Color.White, 0f, 
            //     Vector2.Zero, 5f, SpriteEffects.None, 0f
            // );
            line.Draw(gameTime);
            bolinha.Draw(gameTime);
            bolinha2.Draw(gameTime);
            basic.Draw();

            Global.spriteBatch.End();
        }
    }
}
