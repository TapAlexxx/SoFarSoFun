using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Logic.Hud.Buttons
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IStateMachine<IGameState> _gameStateMachine;

        private void OnValidate()
        {
            if (!_button) TryGetComponent(out _button);
        }

        [Inject]
        public void Constructor(IStateMachine<IGameState> gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Start() => 
            _button.onClick.AddListener(RestartGame);

        private void OnDestroy() => 
            _button.onClick.RemoveListener(RestartGame);

        private void RestartGame() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}