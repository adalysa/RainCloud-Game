using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RainCloud.PlayerMovement;

namespace RainCloud.Sprites
{
    public class Cloud : Sprite
    {
        Vector2 cloudPosition;
        float cloudSpeed;

        public Cloud(Texture2D texture)
          : base(texture)
        {
        }

        public void Update(GameTime gameTime)
        {
            cloudSpeed = 200f;
            cloudPosition = CloudMovement.KeyCloudMovement(cloudPosition, cloudSpeed, gameTime);
        }

        /*public override void OnCollide(Sprite sprite)
        {

        }*/
    };
};