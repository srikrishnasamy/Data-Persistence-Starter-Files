using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor; // Add this to use Editor functions like exiting play mode in the editor
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName { get; set; }
    public string BestPlayerName { get; private set; }
    public int HighScore { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDatas();
    }

    public void SaveDatas(string playerName, int score)
    {
        SaveData data = new SaveData
        {
            bestplayer = playerName,
            bestScore = score
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        HighScore = score;
        BestPlayerName = playerName;
    }

    public void LoadDatas()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.bestScore;
            BestPlayerName = data.bestplayer;
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
    #if UNITY_EDITOR
    // If running in Unity Editor, stop play mode
    if (EditorApplication.isPlaying)
    {
        EditorApplication.isPlaying = false;
    }
    #else
        // If running in a build, quit the application
        Application.Quit();
    #endif
    }

    [System.Serializable]
    class SaveData
    {
        public string bestplayer;
        public int bestScore;
    }
}
