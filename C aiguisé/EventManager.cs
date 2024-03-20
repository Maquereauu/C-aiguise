using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public static class EventManager
    {
        public static event Action _rightArrow;
        public static event Action _leftArrow;
        public static event Action _downArrow;
        public static event Action _upArrow;

        public static Transform _transform = new Transform();

        public static void MoveLeft()
        {
            Movement(_transform, -1, 0, "Left");

        }
        public static void MoveRight() 
        {
            Movement(_transform, 1, 0, "Right");
        }

        public static void MoveUp() 
        {
            Movement(_transform, 0, -1, "Up");
        }
        public static void MoveDown() 
        {
            Movement(_transform, 0, 1, "Down");
        }

        public static void Movement(Transform coordinates, int x, int y, string dir)
        {
            if (coordinates.GetCoordinates().x() + x + dir.Length <= Console.LargestWindowWidth &&coordinates.GetCoordinates().x() + x >= 0 &&
                coordinates.GetCoordinates().y() + y <= Console.LargestWindowHeight && coordinates.GetCoordinates().y() + y >= 0)
            {
                Console.Clear();
                coordinates.Translate(x, y);
                Console.SetCursorPosition(coordinates.GetCoordinates().x(), coordinates.GetCoordinates().y());
                Console.WriteLine(dir);
            }
        }

        public static void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        _leftArrow?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        _rightArrow?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        _upArrow?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        _downArrow?.Invoke();
                        break;
                }
            }
        }
    }
}