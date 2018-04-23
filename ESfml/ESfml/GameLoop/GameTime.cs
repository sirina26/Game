﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class GameTime
    {
        float _deltaTime=0f;
        float _timeScale = 1f;
        public float TimeScale
        {
            get { return _timeScale; }
            set { _timeScale = value; }
        }
        public float DeltaTime
        {
            get { return _deltaTime * _timeScale; }
            set { _deltaTime = value; }
        }
        public float DeltaTimeUnscaled
        {
            get { return _deltaTime; }
        }
        public float TotalTimeElapsed
        {
            get;
            private set;
        }
        public GameTime() {}
        public void Update(float deltaTime, float totalTimeElapsed) {
            _deltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}
