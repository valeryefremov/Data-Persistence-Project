using UnityEngine;
using System.IO;

public class GlobalDataSaver : MonoBehaviour
{
    string dataName;
    int dataScore;

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = dataName;
        data.score = dataScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            dataName = data.name;
            dataScore = data.score;
        }
    }

    public void TrySaveScore(string name, int score)
    {
        LoadScore();

        if (score > dataScore)
        {
            dataName = name;
            dataScore = score;
            SaveScore();
        }
    }

    public string ShowSavedScore()
    {
        LoadScore();

        return "Best Score: " + dataName + " : " + dataScore;
    }
}
