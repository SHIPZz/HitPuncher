using CodeBase.Infrastructure.States.StateInfrastructure;
using CodeBase.UI.Services.Window;

namespace CodeBase.Infrastructure.States.States
{
    public class GameState : IState
    {
        private readonly IWindowService _windowService;

        public GameState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter()
        {

        }
        

        public void Exit() { }
    }
}