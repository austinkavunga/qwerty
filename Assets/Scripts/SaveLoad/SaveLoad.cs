using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.Overlays;
using System.IO;

public static class SaveLoad 
{
    public static UnityAction OnSaveGame;
    public static UnityAction<SaveData> OnLoadGame;

    private static string directory = "/SaveData/";
    private static string fileName = "SaveData.sav";

    public static bool Save(SaveData data)
    {
        OnSaveGame?.Invoke();
        string dir = Application.persistentDataPath + directory;

        GUIUtility.systemCopyBuffer = dir;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(data, prettyPrint:true );
        File.WriteAllText(path: dir + fileName, contents:json);

        Debug.Log("Game Saved");
        return true;
    }

    public static SaveData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData data = new SaveData();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<SaveData>(json);
            OnLoadGame?.Invoke(data);
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return data;
    }

    public static void DeleteSaveData()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        if(File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("Save data deleted");
        }
        else
        {
            Debug.Log("No save data to delete");
        }
    }
}
