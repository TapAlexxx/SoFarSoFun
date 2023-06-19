using UnityEngine;

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