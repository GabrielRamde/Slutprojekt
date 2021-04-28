using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Hinder : Bas
    {
        float range = 36f;
        float speed = 5f;

        public Hinder(Texture2D texture, Vector2 position, Point size) : base(texture, position, size)
        {

        }

        public override void Update(GameTime gameTime)
        {
            position.Y += range * (float)Math.Sin(speed * gameTime.TotalGameTime.TotalSeconds); ;
            base.Update(gameTime);
        }
    }
}

