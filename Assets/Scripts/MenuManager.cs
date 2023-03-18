using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public InputField inputField;

    public void StartGame() {
        string playerName;
        if (inputField.text == null)
            playerName = "player";
        else
            playerName = inputField.text;

        ScoreManager.Instance.playerName = playerName;
        SceneManager.LoadScene("main");
    }
}
