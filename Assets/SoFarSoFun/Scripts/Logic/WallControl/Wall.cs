using System;
using Infrastructure.Services.ColorService;
using UnityEngine;
using Zenject;

namespace Logic.BallControl
{

    public class Wall : MonoBehaviour, IColorChangeable
    {
        [SerializeField] private Renderer _renderer;

        public Color TargetColor { get; private set; }

        private void OnValidate()
        {
            if (!_renderer) TryGetComponent(out _renderer);
        }

        [Inject]
        public void Construct(IColorService colorService)
        {
            _colorService = colorService;
        }
        private IColorService _colorService;
        
        private void Start()
        {
            Initialize(_colorService.GetRandomColor(TargetColor));
        }

        public void Initialize(Color startColor)
        {
            ChangeColor(startColor);
        }

        public void ChangeColor(Color color)
        {
            TargetColor = color;
            _renderer.material.color = color;
        }
    }

}