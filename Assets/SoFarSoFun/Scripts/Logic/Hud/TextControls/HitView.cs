using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.Hud.TextControls
{

    public class HitView : MonoBehaviour
    {
        [SerializeField] private GameObject _hitViewObject;
        [SerializeField] private GameObject _comboHitViewObject;
        [SerializeField] private Text _comboHitText;

        private bool _showedCombo;
        private Sequence _sequence;

        public void ShowHit()
        {
            _comboHitViewObject.transform.DOScale(0, 0.2f);
            
            _comboHitText.text = "x1";
            
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(_hitViewObject.transform.DOScale(0, 0f))
                .OnComplete(() => _hitViewObject.SetActive(true))
                .Append(_hitViewObject.transform.DOScale(1.5f, 0.1f))
                .Append(_hitViewObject.transform.DOScale(1, 0.1f))
                .AppendInterval(0.5f)
                .Append(_hitViewObject.transform.DOScale(0, 0.1f));
            
        }

        public void ShowComboHit(int currentCombo)
        {
            _hitViewObject.transform.DOScale(0, 0.2f);
            
            _comboHitText.text = $"COMBO x{currentCombo}!";

            if (!_showedCombo)
            {
                _sequence = DOTween.Sequence();
                _sequence
                    .Append(_comboHitViewObject.transform.DOScale(0, 0f))
                    .OnComplete(() => _comboHitViewObject.gameObject.SetActive(true))
                    .Append(_comboHitViewObject.transform.DOScale(1.4f, 0.1f))
                    .Append(_comboHitViewObject.transform.DOScale(1, 0.11f));
                _showedCombo = true;
            }
            else
            {
                _sequence = DOTween.Sequence();
                _sequence
                    .Append(_comboHitViewObject.transform.DOScale(1.4f, 0.1f))
                    .Append(_comboHitViewObject.transform.DOScale(1, 0.1f));
            }
        }

        public void HideComboHit()
        {
            _sequence.Kill();
            _comboHitViewObject.transform.DOScale(0, 0.15f);
        }
    }

}