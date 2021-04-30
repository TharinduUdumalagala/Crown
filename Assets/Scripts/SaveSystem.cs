using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SaveSystem 
{

    public static string path = Application.persistentDataPath + "/player";

    public static void SaveData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); 
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
        
    }
}
