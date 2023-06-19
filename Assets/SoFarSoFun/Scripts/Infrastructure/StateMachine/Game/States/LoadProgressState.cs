using Infrastructure.Services.PersistenceProgress;
using Infrastructure.Services.PersistenceProgress.Player;

namespace Infrastructure.StateMachine.Game.States
{
    public class LoadProgressState : IPayloadedState<string>, IGameState
    {
        private readonly IStateMachine<IGameState> _stateMachine;
        private readonly IPersistenceProgressService _progressService;

        public LoadProgressState(IStateMachine<IGameState> stateMachine, IPersistenceProgressService progressService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void Enter(string payload)
        {
            LoadOrCreatePlayerData();
            _stateMachine.Enter<LoadLevelState, string>(payload);
        }

        public void Exit()
        {
            
        }

        private PlayerData LoadOrCreatePlayerData() => 
            _progressService.PlayerData = new PlayerData();
    }
}