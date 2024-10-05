using UnityEngine;
using System.IO;

public class GlobalDataSaver : MonoBehaviour
{
    string dataName;
    int dataScore;

    [System.Serializable]
    class ScoreData
    {
        public string dataName = " ";
        public int dataScore = 0;
    }

    public void SaveScoreData()
    {
        ScoreData data = new ScoreData();
        data.dataName = dataName;
        data.dataScore = dataScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            //File.Delete(path);
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            dataName = data.dataName;
            dataScore = data.dataScore;
        }
    }

    public void TrySaveScore(string name, int score)
    {
        LoadScoreData();

        if (score > dataScore)
        {
            dataName = name;
            dataScore = score;
            SaveScoreData();
        }
    }

    public string ShowSavedScore()
    {
        LoadScoreData();
        return "Best Score: " + dataName + " : " + dataScore;
    }
}
