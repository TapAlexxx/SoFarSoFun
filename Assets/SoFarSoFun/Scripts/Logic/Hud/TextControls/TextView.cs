using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.Hud.TextControls
{

    public class TextView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private string _prefix;
        
        public void RefreshText(string text)
        {
            _text.text = $"{_prefix} {text}";

            AnimateRefresh();
        }

        private void AnimateRefresh()
        {
            _text.transform
                .DOScale(1.1f, 0.1f)
                .OnComplete(() => _text.transform.DOScale(1f, 0.1f));
        }
    }

}