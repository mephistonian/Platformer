using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Management;

namespace Platformer.GameTypes
{
    class GameObject
    {
        // GameObject variables (set public to support changing of size, shape, and texture)
        public Vector2 location;
        public Texture2D texture { get; set; }
        public float rotation { get; set; }
        public float scale { get; set; }
        public Vector2 origin;


        // Precision detection variables
        public static float Left, Right, Top, Bottom;

        /// <summary>
        /// Used to dynamically load and draw an instance of a GameObject
        /// </summary>
        /// /// <param name="content">Determines ContentManager in which to load the content</param>
        /// <param name="texture_Path">Determines the texture to load from content</param>
        /// <param name="posX">Location of GameObject on the X axis</param>
        /// <param name="posY">Location of GameObject on the Y axis</param>
        /// <param name="rotation">Rotation of the GameObject (in radians)</param>
        /// <param name="scale">Scale of the GameObject</param>
        public virtual void Load(ContentManager content, string texture_Path,
            float rotation, float scale, float posX, float posY)
        {
            location = new Vector2(posX, posY);
            texture = content.Load<Texture2D>(texture_Path);
            this.rotation = rotation;
            this.scale = scale;
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
        }

        /// <summary>
        /// Continuously updates the GameObject logic
        /// </summary>
        /// <param name="gameTime">Counts the game's update cycles</param>
        public virtual void Update(GameTime gameTime)
        {
            // Initialize precision detection variables
            Left = this.location.X;
            Right = this.location.X + this.texture.Width;
            Top = this.location.Y;
            Bottom = this.location.Y + this.texture.Height;
        }

        /// <summary>
        /// Used to draw / render the GameObject via the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">Decides the SpriteBatch in which to draw / render the GameObject</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }
    }
}
