using UnityEngine;

namespace Util
{
    public class Timer
    {
        public const float DEFAULT_START_TIME = 25.0f;
        public const float TIMER_DEC_MOMENTUM = 1.07f;
        public static float MINIMUM_TIME = 4.0f;
        
        public float timerDecStep = 0.5f;

        private float startTime;
        private float timeRemaining;
        private bool timerRunning;
        private bool autoDecTimer;

        public Timer() : this(DEFAULT_START_TIME, DEFAULT_START_TIME)
        {
        }

        public Timer(float startTime, float timeRemaining, bool timerRunning = true, bool autoDecTimer = true)
        {
            this.startTime = startTime;
            this.timeRemaining = timeRemaining;
            this.timerRunning = timerRunning;
            this.autoDecTimer = autoDecTimer;
        }

        public float GetTimeRemaining()
        {
            return this.timeRemaining;
        }
        
        public bool IsRunning()
        {
            return this.timerRunning;
        }

        public float Tick()
        {
            return Tick(Time.deltaTime);
        }
        
        public float Tick(float dt)
        {
            this.timeRemaining -= dt;

            float r = this.timeRemaining;

            if (r <= 0)
                this.timeRemaining = 0.0f;

            return r;
        }

        public void Stop()
        {
            this.timerRunning = false;
        }

        public void Start()
        {
            this.timerRunning = true;
        }

        public void SetTimer(float t, bool reset)
        {
            this.startTime = t;
            
            if (reset)
                this.timeRemaining = t;
        }

        public void Reset()
        {
            this.timeRemaining = this.startTime;
        }

        public void SetAutoDec(bool autoDec)
        {
            this.autoDecTimer = autoDec;
        }

        public void Dec()
        {
            if (this.autoDecTimer)
            {
                this.timerDecStep *= TIMER_DEC_MOMENTUM;
                Dec(this.timerDecStep);
            }
        }

        public void Dec(float dec)
        {
            this.startTime -= dec;

            if (this.startTime <= MINIMUM_TIME)
                this.startTime = MINIMUM_TIME;
            
            this.timeRemaining = this.startTime;
        }
    }
}