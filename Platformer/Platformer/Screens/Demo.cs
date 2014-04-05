using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Platformer.Management;
using Platformer.GameTypes;

namespace Platformer.Screens
{
    class Demo : GameScreen
    {
        Background background = new Background();
        Player player = new Player();

        public override void LoadContent()
        {
            base.LoadContent();

            background.LoadBackground(content, "Background");
            player.Load(content, "MiniTaur1R", 0, 2, 46, 62);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawBackground(spriteBatch);
            player.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
