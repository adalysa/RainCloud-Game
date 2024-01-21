using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace RainCloud2
{
    public class CloudMovement
    {
        public static Vector2 KeyCloudMovement(Vector2 cloudPosition, float cloudSpeed, GameTime gameTime)
        {
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

            return cloudPosition;
        }
    }
}
