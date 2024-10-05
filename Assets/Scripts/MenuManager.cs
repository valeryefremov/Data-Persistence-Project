using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text SavedScoreText;
    [SerializeField] GlobalDataSaver globalDataSaver;

    private void Start()
    {
        SavedScoreText.text = globalDataSaver.ShowSavedScore();
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
