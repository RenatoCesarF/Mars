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
        public static RigidBody2D square,square2;
        private Line2D line;
        private PresentationParameters  presentationParameters;
        private Basic2D basic;
        
        public Game1(){
            this.Window.ClientSizeChanged += delegate { Resolution.WasResized = true; };

            Content.RootDirectory = "Content";
            Global.content = Content;
            Global.graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize(){
            graphicsProfile = new GraphicsProfile();
            presentationParameters =  new PresentationParameters();

            Resolution.Initialize(Global.graphics);
            Global.graphics.IsFullScreen = false;
            Global.graphics.PreferredBackBufferWidth = Resolution.GameWidth;
            Global.graphics.PreferredBackBufferHeight = Resolution.GameHeight;
            
            //TODO: add this into the engine
            //============== Fulll Screen =========== 
            // this.Window.Position = new Point(0, 0);
            // this.Window.IsBorderless = true;
            // Global.graphics.PreferredBackBufferWidth = Resolution.ScreenWidth;
            // Global.graphics.PreferredBackBufferHeight = Resolution.ScreenHeight;
            
            //=========== Wide Screen ==========================
            this.Window.Position = new Point((Resolution.ScreenWidth - Resolution.GameWidth) / 2, ((Resolution.ScreenHeight - Resolution.GameHeight) / 2) - 40);
            this.Window.IsBorderless = false;
            Global.graphics.PreferredBackBufferWidth = Resolution.GameWidth;
            Global.graphics.PreferredBackBufferHeight = Resolution.GameHeight;

            Global.graphics.ApplyChanges();
            
            adapter = new GraphicsAdapter();
            device = new GraphicsDevice(adapter,graphicsProfile,presentationParameters);

            square = new RigidBody2D(this,new Vector2(10,50),Color.Orange, mass:0.2f);
            square2 = new RigidBody2D(this,new Vector2(10,10), Color.CornflowerBlue, mass:0.5f);

            basic = new Basic2D("sprite", new Vector2(400,250),new Vector2(100,100));
            line = new Line2D( new Vector2(400,250), new Vector2(400,250));

            base.Initialize();
        }

        protected override void LoadContent(){
            base.LoadContent();
            Global.keyboard = new InputKeyboard();
            Global.content = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Global.keyboard.Update();
            
            Resolution.Update(this, Global.graphics);

            square.Update();
            square2.Update();
            line.Update();
            basic.Update();
            Global.keyboard.UpdateOld();

      
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.PapayaWhip);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

           
            line.Draw();
            basic.Draw();
            square.Draw();
            square2.Draw();

            Global.spriteBatch.End();
        }
    }
}
