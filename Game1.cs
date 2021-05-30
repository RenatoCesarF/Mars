using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Mars;
using Mars.Primitivies;
using Mars.Components;

namespace gameExample
{
    public class Game1 : Game
    {
        private GraphicsAdapter adapter;
        private GraphicsProfile  graphicsProfile;
        public MarsConsole console;
        public World world;

        private PresentationParameters  presentationParameters;

        
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

            #region Resolution stuff
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
            #endregion
            
            adapter = new GraphicsAdapter();
            Global.device = new GraphicsDevice(adapter,graphicsProfile,presentationParameters);
            Global.console = new MarsConsole(5);
            world = new World(this);

            base.Initialize();
        }

        protected override void LoadContent(){
            base.LoadContent();
            Global.keyboard = new InputKeyboard();
            Global.mouseControl = new MouseControl();
            Global.spriteFont = Content.Load<SpriteFont>("font");
            
            Global.content = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime){
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Global.gameTime = gameTime;
            Global.keyboard.Update();
            Global.mouseControl.Update();

            if(Global.keyboard.GetPress("Insert")){
                Global.debugging = true;
            }
            if(Global.keyboard.GetPress("Home")){
                Global.debugging = false;
            }
            
            Resolution.Update(this, Global.graphics);

            world.Update();
            
            Global.console.Update();
            Global.keyboard.UpdateOld();
            Global.mouseControl.UpdateOld();

      
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.PapayaWhip);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        
            world.Draw(Vector2.Zero);
            Global.console.Draw();
            Global.spriteBatch.End();
        }
    }
}
