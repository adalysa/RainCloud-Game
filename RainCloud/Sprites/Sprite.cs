using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainCloud.Sprites
{
    public class Sprite : Component, ICloneable
    {
        protected Texture2D _texture;

        protected float _rotation;

        public float cloudSize;

        protected KeyboardState kstate;

        protected KeyboardState _previousKey;

        public Vector2 Origin;

        public Vector2 cloudPosition;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)cloudPosition.X - (int)Origin.X, (int)cloudPosition.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        public List<Sprite> Children { get; set; }  //do we need this?

        public Color Colour { get; set; }

        public Vector2 Direction;

        public float RotationVelocity = 3f;

        public bool isPlayer = false;

        public float LinearVelocity = 4f;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public readonly Color[] TextureData;

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                  Matrix.CreateRotationZ(_rotation) *
                  Matrix.CreateTranslation(new Vector3(cloudPosition, 0));
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;

            // The default origin in the centre of the sprite
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Children = new List<Sprite>();  //Do we need this? Only if we need to group sprites, like to make the ship and bullets dissapear when the ship is destroyed.

            Colour = Color.White;

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);

            cloudSize = 1f;
        }

        public override void Update(GameTime gameTime)
        {
            IsRemoved = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,   //Texture 
                cloudPosition,  //Position
                null,           //Source Rectangle 
                Color.White,    //Color
                0f,           //Rotation
                Origin,   //Origin
                cloudSize,  //will be cloudSize,      //scale 0 - 1f
                SpriteEffects.None,     //Effects
		        .1f  //Depth
            );
            // spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, Size, SpriteEffects.None, 0);

        }

        public bool Intersects(Sprite sprite)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Rectangle.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Rectangle.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Rectangle.Width &&
                        0 <= yB && yB < sprite.Rectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.TextureData[xA + yA * this.Rectangle.Width];
                        var colourB = sprite.TextureData[xB + yB * sprite.Rectangle.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }

        public virtual void OnCollide(Sprite sprite)
        {
            // If the sprite should be removed on collision, set IsRemoved to true
            if (!this.isPlayer)
            {
                this.IsRemoved = true;
            }

            Debug.WriteLine(sprite);
            Debug.WriteLine("IT COLLIDED");
            Debug.WriteLine(Rectangle);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
