using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Template
{
    public class Bas
    {
        private Texture2D _texture;
        protected Vector2 position;
        private Point size;

        public Vector2 Position { get { return position; } set { position = value; } } //gör så man kan använda private variablar
        public Bas(Texture2D texture, Vector2 pos, Point size)
        {
            _texture = texture;
            position = pos;
            this.size = size;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(position.ToPoint(), size), Color.White);
        }
    }
}
