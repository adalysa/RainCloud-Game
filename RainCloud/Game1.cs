using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RainCloud
{
    public class Game1 : Game
    {
        Texture2D cloudTexture; 

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
            Rectangle destinationRectangle = new Rectangle(100, 100, 200, 100);

            _spriteBatch.Draw(cloudTexture, destinationRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}