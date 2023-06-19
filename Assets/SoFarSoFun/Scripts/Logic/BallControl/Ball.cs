using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.BallControl
{

    public class Ball : MonoBehaviour, IColorChangeable
    {
        [SerializeField] private Renderer _renderer;
        
        private bool _initialized;
        public int ID { get; private set; }
        public Color TargetColor { get; private set; }

        private void OnValidate()
        {
            if (!_renderer) TryGetComponent(out _renderer);
        }

        private void Start()
        {
            Initialize(Random.Range(1, 100));
            if (!_initialized)
                throw new InvalidOperationException($"Ball {gameObject.name} is not initialized");
        }

        public void Initialize(int id)
        {
            ID = id;
            _initialized = true;
        }

        public void ChangeColor(Color color)
        {
            TargetColor = color;
            _renderer.material.color = color;
        }
    }

}