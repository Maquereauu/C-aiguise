using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
        public static event Action _backspace;
        public static string _lastTouch;

        public static event Action _menu;
        public static event Action _tab;

        public static Transform _transform = new Transform();
        public static Transform _transform2 = new Transform();

        public static void MoveLeft()
        {
            Movement(_transform, -1, 0, "P");
            _lastTouch = "left";
        }
        public static void MoveRight() 
        {
            Movement(_transform, 1, 0, "P");
            _lastTouch = "right";
        }

        public static void MoveUp() 
        {
            Movement(_transform, 0, -1, "P");
            _lastTouch = "up";
        }
        public static void MoveDown() 
        {
            Movement(_transform, 0, 1, "P");
            _lastTouch = "down";
        }

        public static void Movement(Transform coordinates, int x, int y, string dir)
        {
            if (coordinates._mCoordinates.x() + x + dir.Length < Console.BufferWidth && coordinates._mCoordinates.x() + x >= 0 &&
                coordinates._mCoordinates.y() + y + 1 < Console.BufferHeight && coordinates._mCoordinates.y() + y >= 0)
            {
/*                Console.SetCursorPosition(0, 0);*/
                coordinates.Translate(x, y);
            }
        }

        public static void Update()
        {
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                var key = Console.ReadKey(true).Key;

                Scene Currentscene = SceneManager._mCurrentScene;
                Bitmap map = Currentscene.bitmap;
                int x = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item1;
                int y = FileReader.GetSizeFromFile("../../../Content/Role/Player.txt").Item2;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (EventManager._transform._mCoordinates.x() > 0 && map != null)
                        {
                            for (int i = 0; i < y; i++)
                            {
                                for (int j = 0; j < x; j++)
                                {
                                    Color pix = map.GetPixel(EventManager._transform._mCoordinates.x() + j - 1, EventManager._transform._mCoordinates.y() * 2 + i * 2);
                                    byte pixR = pix.R;
                                    byte pixG = pix.G;
                                    byte pixB = pix.B;
                                    if (pixR == 0 && pixG == 0 && pixB == 0)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                            

                        _leftArrow?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        if(EventManager._transform._mCoordinates.x() < 192 && map != null)
                        {
                            for (int i = 0; i < y; i++)
                            {
                                for (int j = 0; j < x; j++)
                                {
                                    Color pix = map.GetPixel(EventManager._transform._mCoordinates.x() + j + 1, EventManager._transform._mCoordinates.y() * 2 + i * 2);
                                    byte pixR = pix.R;
                                    byte pixG = pix.G;
                                    byte pixB = pix.B;
                                    if (pixR == 0 && pixG == 0 && pixB == 0)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        
                        _rightArrow?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        if(EventManager._transform._mCoordinates.y() > 0 && map != null)
                        {
                            for (int i = 0; i < y; i++)
                            {
                                for (int j = 0; j < x; j++)
                                {
                                    Color pix = map.GetPixel(EventManager._transform._mCoordinates.x() + j + 1, EventManager._transform._mCoordinates.y() * 2 + i * 2 -2);
                                    byte pixR = pix.R;
                                    byte pixG = pix.G;
                                    byte pixB = pix.B;
                                    if (pixR == 0 && pixG == 0 && pixB == 0)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        
                        _upArrow?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        if(EventManager._transform._mCoordinates.y() < 107/2 && map != null)
                        {
                            if (EventManager._transform._mCoordinates.y() > 0 && map != null)
                            {
                                for (int i = 0; i < y; i++)
                                {
                                    for (int j = 0; j < x; j++)
                                    {
                                        Color pix = map.GetPixel(EventManager._transform._mCoordinates.x() + j + 1, EventManager._transform._mCoordinates.y() * 2 + i * 2 + 1);
                                        byte pixR = pix.R;
                                        byte pixG = pix.G;
                                        byte pixB = pix.B;
                                        if (pixR == 0 && pixG == 0 && pixB == 0)
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        
                        _downArrow?.Invoke();
                        break;
                    case ConsoleKey.Enter:
                        _enter?.Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        _backspace?.Invoke();
                        break;
                    case ConsoleKey.Escape:
                        _menu?.Invoke();
                        break; 
                    case ConsoleKey.Tab:
                        _tab.Invoke();
                        break;
                }
            }
        }
    }
}