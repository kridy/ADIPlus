using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    public class InputManager
    {
        private readonly Thread _thread;
        private readonly Dictionary<ConsoleKey, InputCommand> keyActionMap;
        public InputManager()
        {
            keyActionMap = new Dictionary<ConsoleKey, InputCommand>();
            _thread = new Thread(UpdateInput);
        }

        public void RegisterAction(ConsoleKey key, InputCommand command)
        {
            keyActionMap[key] = command;
        }

        private void UpdateInput()
        {
            while (true)
            {
                var key = Console.ReadKey(true);

                if (keyActionMap.ContainsKey(key.Key))
                    keyActionMap[key.Key].Invoke();
            }
        }

        public void Start()
        {
            _thread.Start();
        }
    }
}