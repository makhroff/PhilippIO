using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilippIO.Scripts
{
    public class DebugUtil
    {
        public const string baseFontPath = "./Fonts/base.TTF";

        public static Font baseFont = new(baseFontPath);

        public static void DrawPerformanceLog(Color textColor)
        {
            if(baseFont == null)
                return;

            Time time = Game.Instance.Time;

            string totalTimeElapsedStr = "TOTAL_TIME: " + time.TotalTimeElapsed.ToString("0.000");
            string deltaTimeStr = "DELTA_TIME: " + time.DeltaTime.ToString("0.00000");
            float FPS = 1f / time.DeltaTimeUnscaled;
            string FPSStr = "FPS: " + FPS.ToString("0.00");

            Text totalTimeText = new(totalTimeElapsedStr, baseFont, 15);
            totalTimeText.Position = new(0f, 0f);
            totalTimeText.Color = textColor;

            Text deltaTimeText = new(deltaTimeStr, baseFont, 15);
            deltaTimeText.Position = new(0f, 15f);
            deltaTimeText.Color = textColor;

            Text FPSText = new(FPSStr, baseFont, 15);
            FPSText.Position = new(0f, 30f);
            FPSText.Color = textColor;

            RenderWindow w = Game.Instance.Window;
            w.Draw(totalTimeText);
            w.Draw(deltaTimeText);
            w.Draw(FPSText);
        }
    }
}
