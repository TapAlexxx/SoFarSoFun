using DG.Tweening;
using UnityEngine;

namespace Logic.BallControl
{

    public class BallAnimation : MonoBehaviour
    {
        public void AnimateBallHit()
        {
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(transform.DOScale(2.3f, 0.2f))
                .Append(transform.DOScale(1.7f, 0.15f))
                .Append(transform.DOScale(2f, 0.2f));
        }
    }

}