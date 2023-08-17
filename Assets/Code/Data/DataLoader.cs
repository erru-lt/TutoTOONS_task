using Assets.Code;
using System.IO;
using UnityEngine;

public class DataLoader
{
    public T LoadData<T>(string path) where T : IJsonData
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Unable to locate the file at the specified path");
        }

        string json = File.ReadAllText(path);
        T data = JsonUtility.FromJson<T>(json);

        return data;
    }
}
