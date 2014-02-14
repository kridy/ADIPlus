using System;
using System.Collections.Generic;
using ADIPlus.Drawing;

namespace Snake
{
    public class Snake
    {
        private readonly InputManager _input;
        private Queue<Point> _body;
        private Point _head;
        private int _direction;

        public Snake(InputManager input)
        {
            //_body = new Queue<Point>();
            //_body.Enqueue();
            _direction = 2;
            _head = new Point(15,7);
            _input = input;
            _input.RegisterAction(ConsoleKey.UpArrow, new DelegateInputCommand(()=> _direction = 1 ));
            _input.RegisterAction(ConsoleKey.DownArrow, new DelegateInputCommand(() => _direction = 2 ));
            _input.RegisterAction(ConsoleKey.LeftArrow, new DelegateInputCommand(() => _direction = 3 ));
            _input.RegisterAction(ConsoleKey.RightArrow, new DelegateInputCommand(() => _direction = 4 ));
        }


        public void Update()
        {
            //var part = _body.Dequeue();

            switch (_direction)
            {                    
                case 1:
                    _head = _head.YDecremented(1);
                    break;
                case 2:
                    _head = _head.YIncremented(1);
                    break;
                case 3:
                    _head = _head.XDecremented(1);
                    break;
                case 4:
                    _head = _head.XIncremented(1);
                    break;
            }

        }

        public void Render(AsciiGraphics graphics)
        {
            graphics.DrawPoint(new AsciiPen('*', AsciiColors.Green), _head);
        }
    }

    internal class SnakeGame : Game
    {
        private InputManager _input;
        private Snake _snake;
        private AsciiGraphics _bufferRender;
        private AsciiGraphics _displayRender;
        private Image _backBuffer;
        public override void Start()
        {
            const int width = 30;
            const int height = 15;

            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = width;
            Console.BufferHeight = height;

            //const uint horizontalSpeed = 2;
            //const uint verticalSpeed = 1;

            _backBuffer = new Image(width,height);
            _bufferRender = AsciiGraphics.FromCharImage(_backBuffer);
            _displayRender = AsciiGraphics.FromUnManagedConsole();

            _input = new InputManager();
            _input.RegisterAction(ConsoleKey.Escape,  new DelegateInputCommand(()=> Started = false));
            _snake = new Snake(_input);

            Started = true;            
            _input.Start();
            
        }

        public override void Update()
        {
            _snake.Update();
        }

        public override void Render()
        {
            _bufferRender.Clear();

            _snake.Render(_bufferRender);

            _displayRender.DrawImage(_backBuffer);
        }

        public override void Input()
        { /* Input is handled by inputManager */}
    }
}