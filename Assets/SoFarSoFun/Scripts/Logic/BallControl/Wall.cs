using UnityEngine;

namespace Logic.BallControl
{

    public class Wall : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        private void OnValidate()
        {
            if (!_renderer) TryGetComponent(out _renderer);
        }

        public void Initialize(Color startColor)
        {
            _renderer.material.color = startColor;
        }
    }

}