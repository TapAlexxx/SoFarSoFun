using Infrastructure.Services.Factories.Game;
using UnityEngine;
using Zenject;

namespace Logic.Hud.TextControls
{

    public class HitViewControl : MonoBehaviour
    {
        [SerializeField] private TextView _ballHitText;
        [SerializeField] private TextView _wallHitText;
        [SerializeField] private HitView _hitView;
        
        private IGameFactory _gameFactory;
        private BallHitCounter _hitCounter;
        private bool _isComboView;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _hitCounter = _gameFactory.Player.GetComponentInChildren<BallHitCounter>();
            
            _hitCounter.BallHitsChanged += RefreshBallHitView;
            _hitCounter.WallHitsChanged += RefreshWallHitView;
            _hitCounter.ComboStarted += OnComboStarted;
            _hitCounter.ComboEnded += OnComboEnded;
            
            RefreshBallHitView();
            RefreshWallHitView();
        }

        private void OnDestroy()
        {
            if (!_hitCounter)
                return;

            _hitCounter.BallHitsChanged -= RefreshBallHitView;
            _hitCounter.WallHitsChanged -= RefreshWallHitView;
            _hitCounter.ComboStarted -= OnComboStarted;
            _hitCounter.ComboEnded -= OnComboEnded;
        }

        private void RefreshWallHitView()
        {
            _wallHitText.RefreshText(_hitCounter.WallHits.ToString());
        }

        private void RefreshBallHitView()
        {
            if (!_isComboView) 
                _hitView.ShowHit();
            else
                _hitView.ShowComboHit(_hitCounter.CurrentCombo);

            _ballHitText.RefreshText(_hitCounter.BallHits.ToString());
        }

        private void OnComboStarted()
        {
            _hitView.ShowComboHit(_hitCounter.CurrentCombo);
            _isComboView = true;
        }

        private void OnComboEnded()
        {
            _hitView.HideComboHit();
            _isComboView = false;
        }
    }

}