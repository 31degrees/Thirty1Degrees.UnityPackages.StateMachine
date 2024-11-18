namespace Thirty1Degrees.StateMachine
{
    /// <summary>
    /// Base state.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        void Enter();

        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        void Exit();
    }
}