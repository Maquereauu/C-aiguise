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
        public static event Action _enter;


        public static void MoveLeft()
        {
            Console.WriteLine("Left");
        }
        public static void MoveRight() 
        {
            Console.WriteLine("Right");
        }

        public static void MoveUp() 
        {
            Console.WriteLine("Up");
        }
        public static void MoveDown() 
        {
            Console.WriteLine("Down");
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
                    case ConsoleKey.Enter:
                        _enter?.Invoke();
                        break;
                }
            }
        }
    }
}