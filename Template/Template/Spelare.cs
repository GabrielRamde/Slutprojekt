using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Spelare : Bas
    {
        public Spelare(Texture2D texture, Vector2 position, Point size) : base(texture, position, size)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += 6;
            }
        }
    }
}

