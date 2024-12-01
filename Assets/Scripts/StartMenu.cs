using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInputField; // Reference to the input field
    public void StartGame()
    {
        GameManager.Instance.PlayerName = nameInputField.text;
        if (!string.IsNullOrEmpty(GameManager.Instance.PlayerName))
        {
            PlayerPrefs.SetString("PlayerName", GameManager.Instance.PlayerName); // Save the player's name
            SceneManager.LoadScene("main"); // Load the main game scene
        }
        else
        {
            Debug.LogError("Player name cannot be empty!");
        }
    }
}
