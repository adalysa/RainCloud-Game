using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RainCloud
{
    public class Game1 : Game
    {
        Texture2D cloudTexture;
        Vector2 cloudPosition;
        float cloudSpeed;
        float cloudSize;
        Viewport viewport1;
        Vector2 screenCenter; 

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // cloudPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            // _graphics.PreferredBackBufferHeight / 2);

            //Rectangle # meanings: Rectangle(int x, int y, int width, int height)

            Vector2 cloudPosition = new Vector2(100, 100);

            cloudSpeed = 200f;
            cloudSize = 0.1f;

            Viewport viewport1 = graphics.GraphicsDevice.Viewport;
            Vector2 screenCenter = new Vector2(viewport1.Width / 2f, viewport1.Height / 2f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            cloudTexture = Content.Load<Texture2D>("cloud1");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                cloudPosition.Y -= cloudSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                cloudPosition.Y += cloudSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                cloudPosition.X -= cloudSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                cloudPosition.X += cloudSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            //This is how you set colors w/ rgba values:
            //Color cl = new Color(10, 20, 10, 0);
            //GraphicsDevice.Clear(cl);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            //Rectangle # meanings: Rectangle(int x, int y, int width, int height)
            //Rectangle cloudPosition = new Rectangle(100, 100, 200, 100);

            //_spriteBatch.Draw(cloudTexture, cloudPosition, Color.White);

            _spriteBatch.Draw(
                cloudTexture,   //Texture 
                cloudPosition,  //Position
                null,           //Source Rectangle 
                Color.White,    //Color
                0f,           //Rotation
                screenCenter,   //Origin
                cloudSize,      //scale 0 - 1f
                SpriteEffects.None,     //Depth
                .1f
            );


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}