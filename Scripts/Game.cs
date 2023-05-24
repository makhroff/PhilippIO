using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PhilippIO.Scripts
{
    public class Game
    {
        public static Game Instance { get; private set; }

        public bool isGameRunning = true;

        public const int targetFps = 60;
        public const float timeUntilUpdate = 1f / targetFps;

        private float totalTimeElapsed = 0f;
        private float previousTimeElapsed = 0f;
        private float deltaTime = 0f;
        private float totalTimeBeforeUpdate = 0f;

        public RenderWindow Window { get; private set; }
        public Time Time { get; private set; }
        public Color WindowColor { get; private set; }

        public Game(uint windowWidth,  uint windowHeight, string windowTitle, Color windowColor)
        {
            Instance = this;

            Window = new(new VideoMode(windowWidth, windowHeight), windowTitle);
            Window.Closed += OnWindowClosed;
            Window.SetFramerateLimit(targetFps);

            Time = new();
            WindowColor = windowColor;
        }

        public void Run()
        {
            Clock clock = new Clock();
            while (isGameRunning)
            {
                Window.DispatchEvents();

                CalculateTime(clock);

                if(totalTimeBeforeUpdate >= timeUntilUpdate) 
                {
                    Time.Update(totalTimeBeforeUpdate, clock.ElapsedTime.AsSeconds());
                    totalTimeBeforeUpdate = 0f;

                    UpdateAllUpdatableObjects();

                    Window.Clear(WindowColor);
                    DrawAllDrawableObjects();

                    DebugUtil.DrawPerformanceLog(Color.Black);

                    Window.Display();
                }
            }
        }

        private void CalculateTime(Clock clock)
        {
            totalTimeElapsed = clock.ElapsedTime.AsSeconds();
            deltaTime = totalTimeElapsed - previousTimeElapsed;
            previousTimeElapsed = totalTimeElapsed;
            totalTimeBeforeUpdate += deltaTime;
        }

        private void UpdateAllUpdatableObjects()
        {

        }

        private void DrawAllDrawableObjects()
        {

        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Window?.Close();
            Environment.Exit(0);
        }
    }
}
