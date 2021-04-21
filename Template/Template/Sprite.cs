using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    class Sprite
    {
        protected Texture2D spelare;

        public Vector2 spelarepos;
        public bool IsRemoved = false;
    }
}
