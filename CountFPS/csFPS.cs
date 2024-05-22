using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountFPS
{
    public class csFPS
    {
        /// <summary>
        /// Check interval in ms
        /// </summary>
        public int CalInterval = 2000;

        private int AccCount = 0;

        public double FPS;

        private DateTime LastCalculationTime;

        /// <summary>
        /// Call this method for each frame
        /// </summary>
        public void AddCount()
        {
            AccCount++;
        }

        /// <summary>
        /// Result calculation need to run frequently
        /// </summary>
        public void UpdateFPS()
        {
            var timeSpan = DateTime.Now - LastCalculationTime;

            if (timeSpan > TimeSpan.FromMilliseconds(CalInterval))
            {
                FPS = AccCount / timeSpan.TotalSeconds;
                AccCount = 0;
                LastCalculationTime = DateTime.Now;
            }
        }

    }
}
