using System;
using Infrastructure.Services.StaticData;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Window.MenuButtons
{

    public class PlayButton : MonoBehaviour
    {
        [SerializeField] public Button button;
        private IStateMachine<IGameState> _gameStateMachine;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IStateMachine<IGameState> gameStateMachine,IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            button.onClick.AddListener(LoadGame);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(LoadGame);
        }

        private void LoadGame()
        {
            string targetSceneName = _staticDataService.GameConfig().GameScene;
            _gameStateMachine.Enter<LoadLevelState, string>(targetSceneName);
        }
    }

}