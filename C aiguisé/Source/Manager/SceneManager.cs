using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public static class SceneManager
    {
        public static List<Scene> _sceneList = new List<Scene>();
        public static Scene _currentScene = new MainMenu();
        public static Scene CurrentScene { get { return _currentScene; } }
        public static Scene _previousScene = new MainMenu();

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
            _currentScene.LoadScene();
        }

        public static void SwitchScene(string sceneName)
        {
            for (int i = 0; i < _sceneList.Count; i++)
            {
                if (_sceneList[i].GetName() == sceneName)
                {
                    _previousScene = _currentScene;
                    _previousScene.UnLoad();

                    _currentScene = _sceneList[i];
                    LoadScene();
                    Update();
                    return;
                }
            }
        }
        public static void SwitchScene()
        {
            _currentScene.UnLoad();
            _currentScene = _previousScene;
            LoadScene();
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