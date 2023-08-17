using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public static class SceneLoader
    {
        public static void Load(int sceneIndex, Action onLoaded = null) => 
            LoadScene(sceneIndex, onLoaded);

        private static async void LoadScene(int sceneIndex, Action onLoaded = null)
        {
            AsyncOperation waitForNextScene = SceneManager.LoadSceneAsync(sceneIndex);

            while (!waitForNextScene.isDone)
            {
                await Task.Yield();
            }
        }
    }
}
