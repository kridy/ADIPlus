using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            _body = new Queue<Point>();

            for (uint i = 0; i < 20; i++)
            {
                _body.Enqueue(new Point(50, 6+i));
            }

            _head = new Point(50, 25);            
            
            _direction = 2;
            _input = input;
            _input.RegisterAction(ConsoleKey.UpArrow, new DelegateInputCommand(()=> _direction = 1 ));
            _input.RegisterAction(ConsoleKey.DownArrow, new DelegateInputCommand(() => _direction = 2 ));
            _input.RegisterAction(ConsoleKey.LeftArrow, new DelegateInputCommand(() => _direction = 3 ));
            _input.RegisterAction(ConsoleKey.RightArrow, new DelegateInputCommand(() => _direction = 4 ));
        }

        public Point Location
        {
            get { return _head; }
        }

        private double accDelta = 0;


        public void Update(double d, double dt)
        {
            accDelta += dt;

            if (accDelta < 0.07) return;

            accDelta = 0;


            var bodySegment = _body.Dequeue();
            _body.Enqueue(new Point(_head.X, _head.Y));
            
            switch (_direction)
            {                    
                case 1:
                    _head = _head.YDecremented(1);
                    break;
                case 2:
                    _head = _head.YIncremented(1);
                    break;
                case 3:
                    _head = _head.XDecremented(2);
                    break;
                case 4:
                    _head = _head.XIncremented(2);
                    break;
            }

        }

        public void Render(AsciiGraphics graphics)
        {
            graphics.DrawPoint(new AsciiPen('*', AsciiColors.Green), _head);
            foreach (var point in _body)
            {
                graphics.DrawPoint(new AsciiPen('*', AsciiColors.Green), point);
            }
        }

        public void Grow(int i)
        {
            for (int j = 0; j < i; j++)
            {
                _body.Enqueue(new Point(_head.X, _head.Y));
            }
        }
    }

    public class Food
    {
        private readonly Point _location;

        public Food(Point location)
        {
            _location = location;
            currentColor = AsciiColors.Yellow;
            toggelColor = AsciiColors.Red;
        }

        private AsciiColor currentColor;
        private AsciiColor toggelColor;
        private double accDelta = 0;

        public Point Location
        {
            get { return _location; }
        }

        public void Update(double d, double dt)
        {
            accDelta += dt;

            if (accDelta < 1.0) return;

            accDelta = 0;

            var temp = currentColor;
            currentColor = toggelColor;
            toggelColor = temp;
        }

        public void Render(AsciiGraphics graphics)
        {
            graphics.DrawPoint(new AsciiPen('O', currentColor), Location);
        }
    }

    internal class SnakeGame : Game
    {
        private InputManager _input;
        private Snake _snake;
        private AsciiGraphics _bufferRender;
        private AsciiGraphics _displayRender;
        private Image _backBuffer;

        private Food _food;
        private Random _random;
        public override void Start()
        {
            const int width = 100;
            const int height = 50;

            Console.CursorVisible = false;
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = width;
            Console.BufferHeight = height;

            _random = new Random();
            _backBuffer = new Image(width,height);
            _bufferRender = AsciiGraphics.FromCharImage(_backBuffer);
            _displayRender = AsciiGraphics.FromUnManagedConsole();

            _input = new InputManager();
            _input.RegisterAction(ConsoleKey.Escape,  new DelegateInputCommand(()=> Started = false));
            _snake = new Snake(_input);

            var x = (uint)_random.Next(2, 48);
            var y = (uint)_random.Next(0, 25);
            _food = new Food(new Point(x % 2 == 0 ? x : x + 1, y));


            Started = true;            
            _input.Start();
            
        }

        public override void Update(double t, double dt)
        {
            _food.Update(t, dt);
            _snake.Update(t,dt);

            if (_snake.Location.X == _food.Location.X &&
                _snake.Location.Y == _food.Location.Y)
            {
                _snake.Grow(1);
                var x = (uint)_random.Next(2, 48);
                var y = (uint)_random.Next(0, 25);
                _food = new Food(new Point(x % 2 == 0 ? x : x + 1, y));
            }
        }

        public override void Render()
        {
            _bufferRender.Clear();

            _snake.Render(_bufferRender);
            _food.Render(_bufferRender);

            _displayRender.DrawImage(_backBuffer);
        }

        public override void Input()
        { /* Input is handled by inputManager */}
    }
}