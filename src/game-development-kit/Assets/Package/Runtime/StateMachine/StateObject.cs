using System;

namespace Infrastructure.StateMachine
{
    public abstract class StateObject
    {
        public event Action OnEnter;
        public event Action OnExit;
        
        public virtual void Enter() => 
            OnEnter?.Invoke();

        public virtual void Exit() => 
            OnExit?.Invoke();
    }
}