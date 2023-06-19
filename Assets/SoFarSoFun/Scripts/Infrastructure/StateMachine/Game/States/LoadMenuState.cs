using Infrastructure.Services.Factories.UIFactory;
using Infrastructure.Services.Window;
using Window;
using Zenject;

namespace Infrastructure.StateMachine.Game.States
{

    public class LoadMenuState : IPayloadedState<string>, IGameState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IWindowService _windowService;
        private readonly IStateMachine<IGameState> _gameStateMachine;
        private readonly IUIFactory _uiFactory;

        [Inject]
        public LoadMenuState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader,
            IWindowService windowService, IStateMachine<IGameState> gameStateMachine, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
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
            _uiFactory.CreateUiRoot();
            
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