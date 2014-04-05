using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.GameTypes
{
    class Player : GameCharacter
    {
        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content, string texture_Path, float rotation, float scale, float X, float Y)
        {
            base.Load(content, texture_Path, rotation, scale, X, Y);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
