using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Spawner
    {
        public List<Point> LevelPoints { get; private set; } = new List<Point>();

        private GameObject _pointPrefab;
        private GameObject _uiRootPrefab;
        private readonly LevelCoordinatesGenerator _coordinatesGenerator;
        private readonly Levels _levels;
        private readonly int _levelIndex = 0;

        public Spawner(LevelCoordinatesGenerator coordinates, Levels levels, int levelIndex)
        {
            _coordinatesGenerator = coordinates;
            _levels = levels;
            _levelIndex = levelIndex;
        }

        public void Initialize()
        {
            LoadResources();
            GameObject uiRoot = CreateUIRoot();
            List<Vector2> levelCoordinates = LevelCoordinates();
            CreatePointsAndAddToList(uiRoot, levelCoordinates);
        }

        private void CreatePointsAndAddToList(GameObject uiRoot, List<Vector2> levelCoordinates)
        {
            if (levelCoordinates != null)
            {
                int number = 1;
                foreach (Vector2 coordinate in levelCoordinates)
                {
                    Vector2 position = new Vector2(coordinate.x, coordinate.y);
                    Vector2 spawnPosition = CoordinateConverter.ConvertCoordinates(position);

                    GameObject pointObject = Object.Instantiate(_pointPrefab, spawnPosition, Quaternion.identity);
                    pointObject.transform.SetParent(uiRoot.transform, false);

                    if (pointObject.TryGetComponent<Point>(out Point point))
                    {
                        point.SetNumber(number);
                        LevelPoints.Add(point);
                    }

                    number++;
                }
            }
        }

        private List<Vector2> LevelCoordinates()
        {
            _coordinatesGenerator.LevelPointsCoordinates.TryGetValue(_levels.levels[_levelIndex], out var coordinates);
            return coordinates;
        }

        private void LoadResources()
        {
            _pointPrefab = Resources.Load<GameObject>(AssetPath.PointPrefabPath);
            _uiRootPrefab = Resources.Load<GameObject>(AssetPath.UIRootPath);
        }

        private GameObject CreateUIRoot() =>
            Object.Instantiate(_uiRootPrefab);

    }
}
