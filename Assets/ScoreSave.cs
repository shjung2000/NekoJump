using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScoreSave
{
    public static void savePlayerHighScore(int score , bool isHighScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerHighScore.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        RecordData data = new RecordData(score, isHighScore);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static RecordData loadHighScore()
    {
        string path = Application.persistentDataPath + "/PlayerHighScore.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open); //Path exists means the file has already been created and saved. Open the file

            RecordData data = formatter.Deserialize(stream) as RecordData;  //Convert the binary file back to normal file

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
