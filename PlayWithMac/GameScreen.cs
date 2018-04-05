using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayWithMac
{
    public class GameScreen
    {
        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager Content) { }
        public virtual void Update (GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }


    }
}
