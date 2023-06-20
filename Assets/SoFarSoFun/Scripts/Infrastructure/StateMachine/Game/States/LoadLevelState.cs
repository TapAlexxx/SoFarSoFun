using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.ColorService;
using Infrastructure.Services.Factories.Game;
using Infrastructure.Services.Factories.UIFactory;
using Infrastructure.Services.StaticData;
using Logic.BallControl;
using Logic.CameraControl;
using Logic.PlayerControl;
using Logic.PlayerInputControl;
using StaticData;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.StateMachine.Game.States
{

    public class LoadLevelState : IPayloadedState<string>, IGameState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IUIFactory _uiFactory;
        private readonly IStateMachine<IGameState> _gameStateMachine;
        private IGameFactory _gameFactory;
        private DiContainer _diContainer;
        private IColorService _colorService;
        private IStaticDataService _staticDataService;

        [Inject]
        public LoadLevelState(
            IStateMachine<IGameState> gameStateMachine,
            ISceneLoader sceneLoader, 
            ILoadingCurtain loadingCurtain, 
            IUIFactory uiFactory, IGameFactory gameFactory,
            DiContainer diContainer, IColorService colorService, IStaticDataService staticDataService)
        {
            _colorService = colorService;
            _diContainer = diContainer;
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        public void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(payload, OnLevelLoad);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        protected virtual void OnLevelLoad()
        {
            InitGameWorld(OnLevelInited);
        }

        private void OnLevelInited()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld(Action onLevelInited)
        {
           _uiFactory.CreateUiRoot();
           _gameFactory.Clear();

           InitPlayer();
           
           InitHud();
           
           InitCamera();

           InitBalls(onLevelInited);
        }

        private void InitBalls(Action onLevelInited)
        {
            _gameFactory.CreateBalls(onLevelInited);
        }

        private void InitHud()
        {
            GameObject hud = _gameFactory.CreateHud();
        }

        private void InitPlayer()
        {
            _gameFactory.CreatePlayer();
        }

        private void InitCamera()
        {
            CameraStateChanger cameraStateChanger = Object.FindObjectOfType<CameraStateChanger>();
            CameraRotator cameraRotator = cameraStateChanger.GetComponentInChildren<CameraRotator>();
            
            Transform player = _gameFactory.Player.transform;
            cameraStateChanger.SwitchTo(CameraViewState.Default, player);
            
            cameraRotator.Initialize(_gameFactory.Player.GetComponentInChildren<PlayerDragInput>());
        }

        private void Inject<T>() where T : Object
        {
            foreach (var injectable in Object.FindObjectsOfType<T>())
                _diContainer.Inject(injectable);
        }
    }
}