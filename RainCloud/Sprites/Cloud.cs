using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainCloud.Sprites
{

    public class Cloud : Sprite
    {
        public Cloud(Texture2D texture)
          : base(texture)
        {
        }
        public Game1 game;

        // public Vector2 cloudPosition;
         
        public float cloudSpeed = 200f;

        // public float cloudSize = .3f;

        public override void Update(GameTime gameTime)
        {

            cloudSize -= (float).01 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Quit();

            kstate = Keyboard.GetState();

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

         }
    }
}