using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.GameTypes;
using Platformer.Screens;
using Platformer.Tools;

namespace Platformer.GameTypes
{
    class Player : GameCharacter
    {
        float walkSpeed { get; set; }

        ContentManager content;
        GameTime gameTime;

        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content, string texture_Path, float rotation, float scale, float X, float Y)
        {
            base.Load(content, texture_Path, rotation, scale, X, Y);

            // Set initial values for player
            walkSpeed = 5;

            this.content = content;
        }

        public override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;

            Controls();
            RotationReset();
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Controls()
        {
                #region controls switch
                Keys[] pressed_Key = Keyboard.GetState().GetPressedKeys();  // Gathers pressed keys into an array

                for (int i = 0; i < pressed_Key.Length; i++)                // Loops through the pressed keys array for key detection
                {
                    switch (pressed_Key[i])
                    {
                        case Keys.W:
                            location.Y -= walkSpeed;
                            break;
                        case Keys.S:
                            location.Y += walkSpeed;
                            break;
                        case Keys.A:
                            texture =content.Load<Texture2D>("MiniTaur1L");
                            location.X -= walkSpeed;
                            break;
                        case Keys.D:
                            texture = content.Load<Texture2D>("MiniTaur1R");
                            location.X += walkSpeed;
                            break;
                        case Keys.Up:
                            scale += .1f;
                            break;
                        case Keys.Down:
                            scale -= .1f;
                            break;
                        case Keys.Left:
                            
                            rotation -= .1f;
                            break;
                        case Keys.Right:
                            rotation += .1f;
                            break;
                        case Keys.Space:
                            // TODO: Add logic
                            break;
                    }
                }
                #endregion
        }
        private void RotationReset()
        {
            Counter resetTimer = new Counter(gameTime, 1, 10);

            if (resetTimer.counter == 10)
            {
                rotation = 0;
            }
        }
    }
}
