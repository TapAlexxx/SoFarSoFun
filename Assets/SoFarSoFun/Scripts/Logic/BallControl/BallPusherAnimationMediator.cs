using System;
using UnityEngine;

namespace Logic.BallControl
{

    public class BallPusherAnimationMediator : MonoBehaviour
    {
        [SerializeField] private BallPusher _ballPusher;
        [SerializeField] private BallAnimation _ballAnimation;

        private void OnValidate()
        {
            if (!_ballAnimation) TryGetComponent(out _ballAnimation);
            if (!_ballPusher) TryGetComponent(out _ballPusher);
        }

        private void Start()
        {
            _ballPusher.BallPushed += Animate;
        }

        private void OnDestroy()
        {
            _ballPusher.BallPushed -= Animate;
        }

        private void Animate()
        {
            _ballAnimation.AnimateBallPop();
        }
    }

}