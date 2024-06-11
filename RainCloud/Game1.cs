using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;
//using RainCloud.PlayerMovement;
using System.Collections.Generic;
using RainCloud.Sprites;

namespace RainCloud
{
    public class Game1 : Game
    {
        Texture2D cloudTexture;
        Texture2D cloud2Texture;
/*
        Vector2 cloudPosition;
        float cloudSpeed;
        float cloudSize;
*/
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            //Rectangle cloudPosition = new Rectangle(100, 100, 100, 100);

            //cloudSpeed = 200f;

            //cloudSize = .3f;
            //Rectangle # meanings: Rectangle(int x, int y, int width, int height)

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            cloudTexture = Content.Load<Texture2D>("cloud1");
            cloud2Texture = Content.Load<Texture2D>("cloud2");

            _sprites = new List<Sprite>()
            {
                new Cloud(cloudTexture)
                {
                    cloudPosition = new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2,GraphicsDevice.Viewport.Bounds.Height / 2)
                },
                new Sprite(cloud2Texture)
                {
                    cloudPosition = new Vector2(250, 300),
                    cloudSize = 1f
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            /*  Moving this to cloud.cs update
            cloudSize -= (float).01 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(Index.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //cloudPosition = CloudMovement.KeyCloudMovement(cloudPosition, cloudSpeed, gameTime);

            if (cloudSize <= 0.0)
                {
                Debug.WriteLine("GAME OVER!");
                }

            if (cloudSize <= 0.0)
                {
                Debug.WriteLine("GAME OVER!");
                }
 */ 
            foreach (var sprite in _sprites)
                {
                    sprite.Update(gameTime);
                }

            PostUpdate(gameTime);

            base.Update(gameTime);

        }



        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.LightBlue);

            //This is how you set colors w/ rgba values:
            //Color cl = new Color(10, 20, 10, 0);
            //GraphicsDevice.Clear(cl);

            _spriteBatch.Begin();



            //Rectangle # meanings: Rectangle(int x, int y, int width, int height)
            //Rectangle cloudPosition = new Rectangle(100, 100, 200, 100);

            //_spriteBatch.Draw(cloudTexture, cloudPosition, Color.White);
            //Vector2 cloudPosition = new Vector2(800, 100);
            
            /*
            _spriteBatch.Draw(
                cloudTexture,   //Texture 
                cloudPosition,  //Position
                null,           //Source Rectangle 
                Color.White,    //Color
                0f,           //Rotation
                new Vector2(cloudTexture.Width / 2, cloudTexture.Height / 2),   //Origin
                cloudSize,      //scale 0 - 1f
                SpriteEffects.None,     //effects
		        .1f               //depth
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
            */

            foreach (var sprite in _sprites)

                sprite.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void PostUpdate(GameTime gameTime)
        {
            // 1. Check collision between all current "Sprites"
            foreach (var spriteA in _sprites)
            {
                foreach (var spriteB in _sprites)
                {
                    if (spriteA == spriteB)
                        continue;

                    if (spriteA.Intersects(spriteB))
                        spriteA.OnCollide(spriteB);
                }
            }

            // 2. Collect all sprites that need to be removed in a separate list
            List<Sprite> spritesToRemove = new List<Sprite>();

            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    if (!_sprites[i].isPlayer)
                    {
                        spritesToRemove.Add(_sprites[i]);
                    }
                }
            }

            // 3. Remove the sprites in the collected list
            foreach (var sprite in spritesToRemove)
            {
                _sprites.Remove(sprite);
            }
        }
/* don't need sprite count right now, this is optimization
            int count = _sprites.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (var child in _sprites[i].Children)
                    _sprites.Add(child);

                _sprites[i].Children.Clear();
            }

            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
*/
        public void Quit()
        {
            // Call this from other classes to exit
            
            this.Exit();
        }

    }
}
