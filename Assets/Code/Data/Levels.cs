using System;
using System.Collections.Generic;

namespace Assets.Code
{
    [Serializable]
    public class Levels : IJsonData
    {
        public List<LevelData> levels = new();
    }
}
