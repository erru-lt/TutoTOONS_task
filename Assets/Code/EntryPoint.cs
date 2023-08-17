using UnityEngine;

namespace Assets.Code
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameLogic _gameLogic;
        [SerializeField] private int _levelIndex;

        private void Awake()
        {
            DataLoader dataLoader = new DataLoader();
            Levels levels = dataLoader.LoadData<Levels>(AssetPath.JsonDataPath); 
            LevelCoordinatesGenerator levelCoordinatesGenerator = new LevelCoordinatesGenerator(levels);
            levelCoordinatesGenerator.Initialize();
            Spawner spawner = new Spawner(levelCoordinatesGenerator, levels, _levelIndex);
            spawner.Initialize();

            _gameLogic.Construct(spawner);
        }
    }
}
