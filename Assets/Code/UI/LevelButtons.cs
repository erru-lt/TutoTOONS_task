using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class LevelButtons : MonoBehaviour
    {
        [SerializeField] private List<Button> _levelButtons = new List<Button>();

        private void Start() => 
            InitializeLevelButtons();

        private void InitializeLevelButtons()
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int sceneIndex = i + 1;

                if (_levelButtons[i].TryGetComponent<Button>(out Button button))
                {
                    button.onClick.AddListener(() => LoadScene(sceneIndex));
                }
            }
        }

        private void LoadScene(int sceneIndex) => 
            SceneLoader.Load(sceneIndex);
    }
}
