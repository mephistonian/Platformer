using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.GameTypes
{
    class Platform : GameObject
    {
        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content, string texture_Path, float rotation, float scale, float posX, float posY)
        {
            base.Load(content, texture_Path, rotation, scale, posX, posY);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
