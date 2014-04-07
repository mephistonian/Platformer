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
    class Player : GameObject
    {
        float walkSpeed { get; set; }

        ContentManager content;
        GameTime gameTime;

        // Reset values
        public int counter;
        public float Limit = .01f;
        public float Interval = .01f;
        public float Elapsed;

        /// <summary>
        /// Used to dynamically load and draw an instance of the Player
        /// </summary>
        /// /// <param name="content">Determines ContentManager in which to load the content</param>
        /// <param name="texture_Path">Determines the texture to load from content</param>
        /// <param name="posX">Location of Player on the X axis</param>
        /// <param name="posY">Location of Player on the Y axis</param>
        /// <param name="rotation">Rotation of the Player (in radians)</param>
        /// <param name="scale">Scale of the Player</param>
        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content, string texture_Path, float rotation, float scale, float X, float Y)
        {
            base.Load(content, texture_Path, rotation, scale, X, Y);

            // Set initial values for player
            walkSpeed = 5;

            this.content = content;
        }

        /// <summary>
        /// Continuously updates the Player logic
        /// </summary>
        /// <param name="gameTime">Counts the game's update cycles</param>
        public override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;

            Controls();
            Reset();
            base.Update(gameTime);
        }

        /// <summary>
        /// Used to draw / render the Player via the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">Decides the SpriteBatch in which to draw / render the Player</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// The main controls, and their logic, for the Player  are contained here
        /// </summary>
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

        /// <summary>
        /// Resets the Player into it's original scale / rotation
        /// </summary>
        private void Reset()
        {
            #region reset logic
            Elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds; // Passes time since last update

            if (Elapsed >= Interval) // Compares current amount of elapsed time to the set interval of time.
            {
                counter++;
                Elapsed -= Interval; // Reset the elapsed time
            }

            if (counter >= Limit)
            {
                counter = 0; // Reset the counter

                if (scale < 2) scale += .05f;
                if (scale > 2) scale -= .05f;
                if (rotation < 0) rotation += -rotation / 10;
                if (rotation > 0) rotation -= rotation / 10;
            }
            #endregion
        }
    }
}
