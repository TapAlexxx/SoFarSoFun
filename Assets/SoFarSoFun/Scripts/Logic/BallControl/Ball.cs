using DG.Tweening;
using UnityEngine;

namespace Logic.BallControl
{

    public class Ball : MonoBehaviour, IColorChangeable
    {
        [SerializeField] private Renderer _renderer;
        
        public int ID { get; private set; }
        public Color TargetColor { get; private set; }

        private void OnValidate()
        {
            if (!_renderer) TryGetComponent(out _renderer);
        }
        
        public void Initialize(int id, Color color)
        {
            ID = id;
            ChangeColor(color);
        }

        public void ChangeColor(Color color)
        {
            TargetColor = color;
            _renderer.material.DOColor(TargetColor, 0.3f);
        }
    }

}