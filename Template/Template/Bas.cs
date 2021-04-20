using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Template
{
    class Bas
    {
        private Texture2D _texture;
        private Vector2 position;

        public Vector2 Position { get { return position; } set { position = value; } } //gör så man kan använda private variablar
        public Bas(Texture2D texture)
        {
            _texture = texture;
        }
    }
}
