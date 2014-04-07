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
    /// <summary>
    /// Used as a demonstration of the platformer engine
    /// </summary>
    class Demo : GameScreen
    {
        //Sprite initialization
        Background background = new Background();
        Player player = new Player();
        Platform floor = new Platform();

        public override void LoadContent()
        {
            base.LoadContent();

            // Load sprite content
            background.LoadBackground(content, "Background");
            player.Load(content, "MiniTaur1R", 0, 2, 46, 62);
            floor.Load(content, "Floor", .1f, .5f, 100, 100);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            floor.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawBackground(spriteBatch);
            player.Draw(spriteBatch);
            floor.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
