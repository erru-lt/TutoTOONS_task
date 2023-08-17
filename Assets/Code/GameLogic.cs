using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class GameLogic : MonoBehaviour
    {
        private Spawner _spawner;
        private Point _previousPoint;
        private int _currentPointIndex = 0;

        public void Construct(Spawner spawner)
        {
            _spawner = spawner;
        }

        private void Start() => 
            AddListenersToButtons();

        private void AddListenersToButtons()
        {
            foreach (Point point in _spawner.LevelPoints)
            {
                Button pointButton = point.GetComponentInChildren<Button>();
                pointButton.onClick.AddListener(() => OnPointClicked(point));
            }
        }

        private async void OnPointClicked(Point clickedPoint)
        {
            if(clickedPoint != FirstPoint() && FirstPoint().IsActive)
            {
                return;
            }

            if (clickedPoint == FirstPoint())
            {
                UpdatePoint(clickedPoint);
            }
            else if (clickedPoint == NextPoint())
            {              
                if (_previousPoint.TryGetComponent<PointLine>(out PointLine previousPointLine))
                {
                    previousPointLine.AnimateLine(NextPoint().transform.position);
                }

                UpdatePoint(clickedPoint);
                _currentPointIndex++;

                if (clickedPoint == LastPoint())
                {
                    if (clickedPoint.TryGetComponent<PointLine>(out PointLine clickedPointLine))
                    {
                        clickedPointLine.AnimateLine(FirstPoint().transform.position, LoadMainMenu);
                        RemovePointListeners();
                    }                   
                }
            }
        }

        private void LoadMainMenu() => 
            SceneLoader.Load(SceneConstants.MainSceneIndex);

        private void UpdatePoint(Point clickedPoint)
        {
            clickedPoint.HideNumber();
            clickedPoint.IsActive = false;
            _previousPoint = clickedPoint;
        }

        private void RemovePointListeners()
        {
            foreach (Point point in _spawner.LevelPoints)
            {
                Button pointButton = point.GetComponentInChildren<Button>();
                pointButton.onClick.RemoveAllListeners();
            }
        }

        private Point LastPoint() =>
            _spawner.LevelPoints[_spawner.LevelPoints.Count - 1];

        private Point NextPoint() =>
            _spawner.LevelPoints[_currentPointIndex + 1];

        private Point FirstPoint() =>
            _spawner.LevelPoints[0];
    }

}

