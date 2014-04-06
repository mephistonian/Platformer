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

namespace Platformer.GameTypes
{
    class Player : GameCharacter
    {
        float walkSpeed { get; set; }

        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content, string texture_Path, float rotation, float scale, float X, float Y)
        {
            base.Load(content, texture_Path, rotation, scale, X, Y);

            // Set initial values for player
            walkSpeed = 5;
        }

        public override void Update()
        {
            Controls();
            base.Update();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Controls()
        {
            {
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
                            location.X -= walkSpeed;
                            break;
                        case Keys.D:
                            location.X += walkSpeed;
                            break;
                        case Keys.Left:
                            rotation -= .1f;
                            break;
                        case Keys.Right:
                            rotation += .1f;
                            break;
                    }
                }
            }
        }
    }
}
