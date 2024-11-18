namespace Thirty1Degrees.StateMachine
{
    /// <summary>
    /// State payload.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    public interface IStatePayload<T>
    {
        /// <summary>
        /// Gets or sets the state payload.
        /// </summary>
        T StatePayload { get; set; }
    }
}