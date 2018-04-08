using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace ESfml
{
    public abstract class GameLoop//abstract pattern to owr game
    {
        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE=1f/TARGET_FPS;//time before update

        public RenderWindow Window
        {
            get;
            protected set;
        }
        public GameTime GameTime
        {
            get;
            protected set;
        }
        public Color WindowClearColor
        {
            get;
            protected set;
        }
        protected GameLoop(uint windowWidth, uint windowHeight, string windowTitle, Color WindowClearColor)
        {
            this.WindowClearColor = WindowClearColor;
            this.Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle);
            this.GameTime = new GameTime();
        }
        public void Run()
        {
            LoadContent();
            Initialize();
            float totalTimeBeforUpdate = 0d;
            float previousTimeElapsed = 0f;//temp passé
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();
            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforUpdate += deltaTime;

                if (totalTimeElapsed >= TIME_UNTIL_UPDATE)
                {
                    GameTime.Update(totalTimeBeforUpdate, clock.ElapsedTime.AsSeconds());

                    Update(GameTime);
                    
                }
            }
        }
        public abstract void LoadContent ();
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
