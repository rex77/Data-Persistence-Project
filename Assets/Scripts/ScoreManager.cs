using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Playables;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int highScore;
    public string playerName;
    public string bestPlayerName;

    // Start is called before the first frame update
    private void Awake()
    {
        //Make this class as Singlton
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    //session persistence
    [System.Serializable]
    private class HighScore {
        public int highScore;
        public string bestPlayerName;
    }
    
    public void SaveScore() {
        HighScore data = new HighScore();
        data.highScore = highScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "\\savefile.json", json);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "\\savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);
            highScore = data.highScore;
            bestPlayerName = data.bestPlayerName;
        }
        else {
            highScore = 0;
            playerName = "";
        }
    }
}
