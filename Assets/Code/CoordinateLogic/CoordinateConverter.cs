using UnityEngine;

namespace Assets.Code
{
    public static class CoordinateConverter
    {        
        public static float xConversionFactor = 1.0f;
        public static float yConversionFactor = 1.0f;

        public static Vector2 ConvertCoordinates(Vector2 position)
        {           
            float convertedX = position.x * xConversionFactor;
            float convertedY = -position.y * yConversionFactor;

            return new Vector2(convertedX, convertedY);
        }
    }
}
