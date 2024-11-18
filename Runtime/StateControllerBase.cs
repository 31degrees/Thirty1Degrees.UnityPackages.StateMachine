namespace Thirty1Degrees.StateMachine
{
    /// <summary>
    /// State controller base functions.
    /// </summary>
    public abstract class StateControllerBase<TState> : IStateControllerBase<TState>
        where TState : IState
    {
        /// <summary>
        /// Gets or sets the current state.
        /// </summary>
        protected abstract TState CurrentState { get; set; }

        /// <summary>
        /// Returns whether the controller is in the current state.
        /// </summary>
        /// <typeparam name="T">The state type.</typeparam>
        /// <returns>Returns true if in that state or any state deriving from the given state.</returns>
        public bool IsInState<T>()
            where T : TState
        {
            return CurrentState.GetType().IsAssignableFrom(typeof(T)) ||
                   CurrentState.GetType().IsSubclassOf(typeof(T));
        }

        /// <summary>
        /// Handles the state change.
        /// </summary>
        /// <param name="newState">The new state.</param>
        protected virtual void HandleStateChange(TState newState)
        {
            if (newState == null)
            {
                return;
            }

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}