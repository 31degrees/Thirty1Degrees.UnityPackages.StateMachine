namespace Thirty1Degrees.StateMachine
{
    /// <summary>
    /// State factory.
    /// </summary>
    public interface IStateFactory<TState>
    {
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <typeparam name="T">The state type.</typeparam>
        /// <returns>The state.</returns>
        TState GetState<T>()
            where T : TState;

        /// <summary>
        /// Gets the state with a payload.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <typeparam name="T">The state type.</typeparam>
        /// <typeparam name="TPayload">The payload type.</typeparam>
        /// <returns>The state.</returns>
        TState GetState<T, TPayload>(TPayload payload)
            where T : TState, IStatePayload<TPayload>;
    }
}