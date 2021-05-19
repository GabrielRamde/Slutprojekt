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
    public class Spelare : Bas
    {
        public bool HasDied = false;
        private Vector2 startPos;
        Rectangle rectangle_view;
        public Spelare(Texture2D texture, Vector2 position, Point size) : base(texture, position, size, Relation.player)
        {
            startPos = position;
            rectangle_view = new Rectangle(0, 0, 1920, 1080);
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && position.Y > 0)
            {
                position.Y -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && position.Y < rectangle_view.Height - Hitbox.Height)
            {
                position.Y += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && position.X > 0)
            {
                position.X -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && position.X < rectangle_view.Width - Hitbox.Width)
            {
                position.X += 6;
            }
        }

        public void Reset()
        {
            position = startPos;
        }
    }
}

