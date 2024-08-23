using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI nameText;
    public string name;

    private void Awake()
    {
        LoadBestScore();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        name = nameText.text;
        SceneManager.LoadScene(1);
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MainManager.SaveData data = new MainManager.SaveData();
            data = JsonUtility.FromJson<MainManager.SaveData>(json);

            bestScoreText.text = $"Best score : {data.bestScoreName} : {data.bestScore}";
        }
    }
}
