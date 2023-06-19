using System;
using UnityEngine;

namespace Logic.BallControl
{

    public class Ball : MonoBehaviour
    {
        private bool _initialized;
        public int ID { get; private set; }

        public void Initialize(int id)
        {
            ID = id;
            _initialized = true;
        }

        private void Start()
        {
            if (!_initialized)
                throw new InvalidOperationException($"Ball {gameObject.name} is not initialized");
        }
    }

}