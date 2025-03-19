using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeftCharacter : MonoBehaviour
{
    [SerializeField] private Button warriorButton;
    [SerializeField] private Button assasinButton;
    [SerializeField] private Button priestButton;
    [SerializeField] private Button mageButton;

    void Start()
    {
        warriorButton.onClick.AddListener(() => CharacterSelect(0));
        assasinButton.onClick.AddListener(() => CharacterSelect(1));
        priestButton.onClick.AddListener(() => CharacterSelect(2));
        mageButton.onClick.AddListener(() => CharacterSelect(3));
    }

    private void CharacterSelect(int leftcharacter)
    {
        if(leftcharacter == 0)
        {
            PlayerPrefs.SetInt("left", 0);
            Debug.Log("wari");
            SceneManager.LoadScene(3);
        }
        else if (leftcharacter == 1)
        {
            PlayerPrefs.SetInt("left", 1);
            Debug.Log("asas");
            SceneManager.LoadScene(3);
        }
        else if (leftcharacter == 2)
        {
            PlayerPrefs.SetInt("left", 2);
            Debug.Log("pri");
            SceneManager.LoadScene(3);
        }
        else if (leftcharacter == 3)
        {
            PlayerPrefs.SetInt("left", 3);
            Debug.Log("mage");
            SceneManager.LoadScene(3);
        }
    }
}
