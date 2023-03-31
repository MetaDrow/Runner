using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static  class SaveSystem 
{
    public static void SaveHightScore(CountManager countManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.gd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerScore playerScore = new PlayerScore(countManager);
        
        formatter.Serialize(stream, playerScore);
        stream.Close();
    }

    public static PlayerScore LoadScore()
    {
        string path = Application.persistentDataPath + "/gamedata.gd";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerScore score = formatter.Deserialize(stream) as PlayerScore;
            return score;
        }
        else
        {

            Debug.LogError("No save file" + path);
            return null;
        }
    }
}
