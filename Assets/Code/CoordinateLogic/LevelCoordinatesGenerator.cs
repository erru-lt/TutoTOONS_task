using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class LevelCoordinatesGenerator
    {
        private readonly Levels _levels;
        public Dictionary<LevelData, List<Vector2>> LevelPointsCoordinates { get; private set; } = new Dictionary<LevelData, List<Vector2>>();

        public LevelCoordinatesGenerator(Levels levels)
        {
            _levels = levels;
        }

        public void Initialize() => 
            ReadCoordinatesAndAddToDictionary();

        private void ReadCoordinatesAndAddToDictionary()
        {
            for (int levelIndex = 0; levelIndex < _levels.levels.Count; levelIndex++)
            {
                LevelData levelData = _levels.levels[levelIndex];
                List<Vector2> coordinates = new List<Vector2>();

                for (int pointIndex = 0; pointIndex < levelData.level_data.Count; pointIndex += 2)
                {
                    float x = float.Parse(levelData.level_data[pointIndex]);
                    float y = float.Parse(levelData.level_data[pointIndex + 1]);
                    coordinates.Add(new Vector2(x, y));
                }

                LevelPointsCoordinates.Add(levelData, coordinates);
            }
        }
    }
}
