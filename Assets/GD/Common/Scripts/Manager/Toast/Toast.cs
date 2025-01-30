using System;
using UnityEngine;

namespace GD.Toast
{
    [Serializable]
    public class Toast
    {
        private string message;

        private float duration = 2.0f;

        private float delay = 0.0f;

        public string Message { get => message; set => message = value; }
        public float Duration { get => duration; set => duration = value; }
        public float Delay { get => delay; set => delay = value; }

        public Toast(string message, float duration, float delay)
        {
            this.Message = message;
            this.Duration = duration;
            this.Delay = delay;
        }
    }
}