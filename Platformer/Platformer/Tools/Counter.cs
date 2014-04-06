using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Platformer.Tools
{
    public class Counter
    {
        public int Counter { get; set; }
        public int Limit { get; set; }
        public float Interval { get; set; }
        public float Elapsed { get; set; }

        /// <summary>
        /// Used to track a specific duration of time.
        /// </summary>
        /// <param name="gameTime">Uses the platformer's gameTime</param>
        /// <param name="Interval">The interval of time to count by(in seconds)</param>
        /// <param name="Limit">Max time before counter reset (in seconds)</param>
        public Counter(GameTime gameTime, float Interval, float Limit)
        {
            Elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds; // Passes time since last update

            if (Elapsed >= Interval) // Compares current amount of elapsed time to the set interval of time.
            {
                Counter++;
                Elapsed -= Interval; // Reset the elapsed time
            }

            if (Counter >= Limit)
            {
                Counter = 0; // Reset the counter
            }
        }
    }
}
