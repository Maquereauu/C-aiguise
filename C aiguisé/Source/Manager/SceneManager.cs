﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public static class SceneManager
    {
        private static List<Scene> _sceneList = new List<Scene>();
        private static Scene _currentScene = new MainMenu();
        private static Scene _previousScene = new MainMenu();
        private static Scene _lastGameZone = new Game();

        public static List<Scene> _mSceneList 
        {  
            get { return _sceneList; } 
            set { _sceneList = value; }
        }
        public static Scene _mCurrentScene
        {
            get { return _currentScene; }
            set { _currentScene = value; }
        }

        public static Scene _mPreviousScene
        {
            get { return _previousScene; }
            set { _previousScene = value; }
        }

        public static Scene _mLastGameZone
        {
            get { return _lastGameZone; }
            set { _lastGameZone = value; }
        }


        public static void AddScene(Scene scene)
        {
            _sceneList.Add(scene);
        }
        public static void Init()
        {
            for (int i = 0; i < _sceneList.Count; i++)
            {
                _sceneList[i].Init();
            }
        }
        public static void PreUpdate()
        {
            _currentScene.PreUpdate();
        }
        public static void Update()
        {
            _currentScene.Update();
            EventManager.Update();
        }
        public static void PostUpdate()
        {
            _currentScene.PostUpdate();
        }
        public static void LoadScene()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            _currentScene.LoadScene();
        }

        public static void SwitchScene(string sceneName)
        {
            for (int i = 0; i < _sceneList.Count; i++)
            {
                if (_sceneList[i].GetName() == sceneName)
                {
                    if (_sceneList[i].GetIsGameZone())
                    {
                        _lastGameZone = _sceneList[i];
                    }
                    _previousScene = _currentScene;
                    _previousScene.UnLoad();

                    _currentScene = _sceneList[i];
                    LoadScene();
                    Update();
                    return;
                }
            }
        }
        public static void Display()
        {
            /*_currentScene.Update();*/
        }

        public static bool IsSceneExist(string sceneName)
        {
            for (int i = 0; i < _sceneList.Count; i++)
            {
                if (_sceneList[i].GetName() == sceneName)
                {
                   return true;
                }
            }
            return false;
        }

    }
}