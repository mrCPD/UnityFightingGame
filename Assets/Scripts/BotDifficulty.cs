using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotDifficulty : MonoBehaviour
{
    [SerializeField] private Button easyButton;
    [SerializeField] private Button normalButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private Button impossibleButton;

    void Start()
    {
        easyButton.onClick.AddListener(DifficultyEasy);
        normalButton.onClick.AddListener(DifficultyNormal);
        hardButton.onClick.AddListener(DifficultyHard);
        impossibleButton.onClick.AddListener(DifficultyImpossible);
    }

    private void DifficultyEasy()
    {
        PlayerPrefs.SetInt("difficulty", 0);
        SceneManager.LoadScene(2);
    }

    private void DifficultyNormal()
    {
        PlayerPrefs.SetInt("difficulty", 1);
        SceneManager.LoadScene(2);
    }

    private void DifficultyHard()
    {
        PlayerPrefs.SetInt("difficulty", 2);
        SceneManager.LoadScene(2);
    }

    private void DifficultyImpossible()
    {
        PlayerPrefs.SetInt("difficulty", 3);
        SceneManager.LoadScene(2);
    }
}
