using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace MyGame
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static GraphicsDevice device;
        private GraphicsAdapter adapter;
        private GraphicsProfile  graphicsProfile;
        private Bolinha bolinha;
        private PresentationParameters  presentationParameters;
        
        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphicsProfile = new GraphicsProfile();
            presentationParameters =  new PresentationParameters();

            adapter = new GraphicsAdapter();
            device = new GraphicsDevice(adapter,graphicsProfile,presentationParameters);

            bolinha = new Bolinha();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Global.content = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            bolinha.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Black);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            bolinha.Draw();

            Global.spriteBatch.End();
        }
    }
}
