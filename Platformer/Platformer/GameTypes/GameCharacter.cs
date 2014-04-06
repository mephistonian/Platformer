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
    class GameCharacter
    {
        // GameCharacter variables
        public Vector2 location;
        public Texture2D texture { get; set; }
        public float rotation { get; set; }
        public float scale { get; set; }
        public Vector2 origin;


        // Precision detection variables
        public static float Left, Right, Top, Bottom;

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

        public virtual void Update(GameTime gameTime)
        {
            // Initialize precision detection variables
            Left = this.location.X;
            Right = this.location.X + this.texture.Width;
            Top = this.location.Y;
            Bottom = this.location.Y + this.texture.Height;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }
    }
}
