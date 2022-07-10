using System;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine<TState> where TState : Enum
    {
        TState CurrentState { get; }

        event Action<TState, TState> OnStateChanged;

        void Change(TState to);
    }
}