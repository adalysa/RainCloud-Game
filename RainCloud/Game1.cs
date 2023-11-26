using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;

namespace RainCloud
{
    public class Game1 : Game
    {
        Texture2D cloudTexture;
        Vector2 cloudPosition;
        float cloudSpeed;
        float cloudSize;

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

            //Rectangle # meanings: Rectangle(int x, int y, int width, int height)

            cloudPosition = new Vector2(
                GraphicsDevice.Viewport.Bounds.Width / 2,
                GraphicsDevice.Viewport.Bounds.Height / 2);

            //Rectangle cloudPosition = new Rectangle(100, 100, 100, 100);

            cloudSpeed = 200f;

            cloudSize = .3f;

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
            
            cloudSize -= (float).01 * (float)gameTime.ElapsedGameTime.TotalSeconds;

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

            if (cloudSize <= 0.0)
            {
                Debug.WriteLine("GAME OVER!");
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
            //Vector2 cloudPosition = new Vector2(800, 100);

            _spriteBatch.Draw(
                cloudTexture,   //Texture 
                cloudPosition,  //Position
                null,           //Source Rectangle 
                Color.White,    //Color
                0f,           //Rotation
                new Vector2(cloudTexture.Width / 2, cloudTexture.Height / 2),   //Origin
                cloudSize,      //scale 0 - 1f
                SpriteEffects.None,     //Depth
                .1f
            );

            _spriteBatch.Draw(
                cloudTexture,
                new Vector2(200,300),
                null,
                Color.White,
                0.0f, // rotation
                new Vector2(cloudTexture.Width / 2, cloudTexture.Height / 2),
                0.1f,  // scale 0 - 1f
                SpriteEffects.None,
                .1f
            );

            _spriteBatch.Draw(
                cloudTexture,
                new Vector2(400, 200),
                null,
                Color.White,
                0.0f, // rotation
                new Vector2(cloudTexture.Width / 2, cloudTexture.Height / 2),
                0.1f,  // scale 0 - 1f
                SpriteEffects.None,
                .1f
             );


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}