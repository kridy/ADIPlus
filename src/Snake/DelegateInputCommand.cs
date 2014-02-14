using System;

namespace Snake
{
    public class DelegateInputCommand : InputCommand
    {
        private readonly Action _action;

        public DelegateInputCommand(Action action)
        {
            _action = action;
        }

        public override void Invoke()
        {
            _action();
        }
    }
}