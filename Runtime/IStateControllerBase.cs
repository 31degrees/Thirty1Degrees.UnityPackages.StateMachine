namespace Thirty1Degrees.StateMachine
{
    /// <summary>
    /// State controller base.
    /// </summary>
    public interface IStateControllerBase<TState>
    {
        /// <summary>
        /// Returns whether the controller is in the current state.
        /// </summary>
        /// <typeparam name="T">The state type.</typeparam>
        /// <returns>Returns true if in that state or any state deriving from the given state.</returns>
        bool IsInState<T>()
            where T : TState;
    }
}