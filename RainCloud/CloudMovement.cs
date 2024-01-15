using System;

namespace RainCloud
{
    public class KeyCloudMovement
    {
        public static void KeyCloudMovement(Vector2 cloudPosition, float cloudSpeed, GameTime gameTime)
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
        }
    }
}
