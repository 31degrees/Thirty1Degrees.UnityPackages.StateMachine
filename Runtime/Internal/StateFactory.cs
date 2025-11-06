using Zenject;

namespace Thirty1Degrees.StateMachine.Internal
{
    /// <summary>
    /// State factory.
    /// </summary>
    /// <typeparam name="TState">The state type.</typeparam>
    public class StateFactory<TState> : IStateFactory<TState>
    {
        private static readonly object LockObject = new ();

        private readonly DiContainer diContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateFactory{TState}"/> class.
        /// </summary>
        /// <param name="diContainer">DI Container.</param>
        public StateFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        /// <inheritdoc />
        public TState GetState<T>()
            where T : TState, IStatePayload<EmptyPayload>
        {
            return GetState<T, EmptyPayload>(new EmptyPayload());
        }
        
        /// <inheritdoc />
        public TState GetState<T, TPayload>(TPayload payload)
            where T : TState, IStatePayload<TPayload>
        {
            TState state = Resolve<T>();

            // The where clause makes this cast safe.
            ((IStatePayload<TPayload>)state).StatePayload = payload;
            return state;
        }
        
        private T Resolve<T>()
            where T : TState
        {
            // Zenject doesn't like it when we resolve a singleton type at
            // the same time on multiple threads.
            lock (LockObject)
            {
                return diContainer.Resolve<T>();
            }
        }
    }
}