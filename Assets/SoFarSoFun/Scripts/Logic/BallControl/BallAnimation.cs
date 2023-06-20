using DG.Tweening;
using UnityEngine;

namespace Logic.BallControl
{

    public class BallAnimation : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _ballCollisionParticle;
        
        public void AnimateBallPop()
        {
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(transform.DOScale(2.3f, 0.1f))
                .Append(transform.DOScale(1.8f, 0.1f))
                .Append(transform.DOScale(2f, 0.1f));
        }

        public void AnimateBallCollision(Vector3 position, Color color)
        {
            ParticleSystem particleSystemInstance = Instantiate(_ballCollisionParticle);
            particleSystemInstance.transform.position = position;
            var main = particleSystemInstance.main;
            main.startColor = color;
            particleSystemInstance.Play();
        }
    }

}