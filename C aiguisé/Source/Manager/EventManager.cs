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

        public static event Action _menu;

        public static Transform _transform = new Transform();
        public static Transform _transform2 = new Transform();

        public static void MoveLeft()
        {
            Movement(_transform, -1, 0, "P");
        }
        public static void MoveRight() 
        {
            Movement(_transform, 1, 0, "P");
        }

        public static void MoveUp() 
        {
            Movement(_transform, 0, -1, "P");
        }
        public static void MoveDown() 
        {
            Movement(_transform, 0, 1, "P");
        }

        public static void Movement(Transform coordinates, int x, int y, string dir)
        {
            if (coordinates.GetCoordinates().x() + x + dir.Length < Console.BufferWidth && coordinates.GetCoordinates().x() + x >= 0 &&
                coordinates.GetCoordinates().y() + y + 1 < Console.BufferHeight && coordinates.GetCoordinates().y() + y >= 0)
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


                Bitmap b = new Bitmap("../../../Content/Map/map.bmp"); // récupérer la zone actuelle
                

                

                    switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (EventManager._transform.GetCoordinates().x() > 0)
                        {
                            Color pix = b.GetPixel(EventManager._transform.GetCoordinates().x() - 1, EventManager._transform.GetCoordinates().y() * 2);
                            byte pixR = pix.R;

                            byte pixG = pix.G;

                            byte pixB = pix.B;
                            if (pixR == 0 && pixG == 0 && pixB == 0)
                            {
                                return;
                            }
                        }
                        
                            _leftArrow?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        if(EventManager._transform.GetCoordinates().x() < 192)
                        {
                            Color pix = b.GetPixel(EventManager._transform.GetCoordinates().x() + 1, EventManager._transform.GetCoordinates().y() * 2);
                            byte pixR = pix.R;

                            byte pixG = pix.G;

                            byte pixB = pix.B;
                            if (pixR == 0 && pixG == 0 && pixB == 0)
                            {
                                return;
                            }
                        }
                        
                        _rightArrow?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        if(EventManager._transform.GetCoordinates().y() > 0)
                        {
                            Color pix = b.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2 - 2);
                            byte pixR = pix.R;

                            byte pixG = pix.G;

                            byte pixB = pix.B;
                            Color pix2 = b.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2 - 1);
                            byte pix2R = pix2.R;

                            byte pix2G = pix2.G;

                            byte pix2B = pix2.B;
                            if (pixR == 0 && pixG == 0 && pixB == 0 || pix2R == 0 && pix2G == 0 && pix2B == 0)
                            {
                                return;
                            }
                        }
                        
                        _upArrow?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        if(EventManager._transform.GetCoordinates().y() < 107/2)
                        {
                            Color pix = b.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2 + 1);
                            byte pixR = pix.R;

                            byte pixG = pix.G;

                            byte pixB = pix.B;
                            Color pix2 = b.GetPixel(EventManager._transform.GetCoordinates().x(), EventManager._transform.GetCoordinates().y() * 2 + 2);
                            byte pix2R = pix2.R;

                            byte pix2G = pix2.G;

                            byte pix2B = pix2.B;
                            if (pixR == 0 && pixG == 0 && pixB == 0 || pix2R == 0 && pix2G == 0 && pix2B == 0)
                            {
                                return;
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
                }
            }
        }
    }
}