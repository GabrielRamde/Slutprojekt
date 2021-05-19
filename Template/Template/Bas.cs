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
        protected Rectangle hitbox;
        private Point size;
        public bool IsRemoved = false;
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, size.X, size.Y);
            }
        }
        public Relation relation;
        protected bool isDrawn = true;

        public Vector2 Position { get { return position; } set { position = value; } } //gör så man kan använda private variablar
        public Bas(Texture2D texture, Vector2 pos, Point size, Relation relation, bool isDrawn = true)
        {
            _texture = texture;
            position = pos;
            this.size = size;
            this.relation = relation;
            this.isDrawn = isDrawn;
        }
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(isDrawn){
                spriteBatch.Draw(_texture, new Rectangle(position.ToPoint(), size), Color.White);
            }
        }
    }

    public enum Relation
    {
        none,
        player,
        win,
        respawn
    }
}
