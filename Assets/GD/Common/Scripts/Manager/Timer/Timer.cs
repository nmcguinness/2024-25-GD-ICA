using UnityEngine;

namespace GD.Utility
{
    public class Timer
    {
        private string name;

        private bool isRunning = false;
        private float startTime = 0;

        private float elapsedUpdateTime = 0;
        private float elapsedFixedTime = 0;

        //TODO - UnityEvent - OnStart, OnStop, Who should call update and fixedupdate?

        public Timer(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
        public float ElapsedUpdateTime { get => elapsedUpdateTime - startTime; }
        public float ElapsedFixedTime { get => elapsedFixedTime - startTime; }

        public virtual void Start(int time)
        {
            isRunning = true;
            startTime = time;
            Reset(time);
        }

        public virtual void Reset(int time) => elapsedUpdateTime = elapsedFixedTime = time;

        public virtual void Stop()
        {
        }

        public virtual void Update()
        {
            if (isRunning)
                elapsedUpdateTime += Time.deltaTime;
        }

        public virtual void FixedUpdate()
        {
            if (isRunning)
                elapsedFixedTime += Time.fixedDeltaTime;
        }
    }
}