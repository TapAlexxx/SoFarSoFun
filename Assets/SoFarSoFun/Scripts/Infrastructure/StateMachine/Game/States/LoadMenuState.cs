﻿using Infrastructure.Services.Window;
using Window;
using Zenject;

namespace Infrastructure.StateMachine.Game.States
{

    public class LoadMenuState : IPayloadedState<string>, IGameState
    {
        private ILoadingCurtain _loadingCurtain;
        private ISceneLoader _sceneLoader;
        private IWindowService _windowService;
        private IStateMachine<IGameState> _gameStateMachine;

        [Inject]
        public void Construct(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader,
            IWindowService windowService, IStateMachine<IGameState> gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _windowService = windowService;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }
        public void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(payload, OnLevelLoad);
        }

        private void OnLevelLoad()
        {
            InitMenu();
            
            _gameStateMachine.Enter<MenuState>();
        }

        private void InitMenu()
        {
            _windowService.Open(WindowTypeId.Menu);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }

}