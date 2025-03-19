using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RightCharacter : MonoBehaviour
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

    private void CharacterSelect(int rightcharacter)
    {
        if(rightcharacter == 0)
        {
            PlayerPrefs.SetInt("right", 0);
            Debug.Log("wari");
            SceneManager.LoadScene(4);
        }
        else if (rightcharacter == 1)
        {
            PlayerPrefs.SetInt("right", 1);
            Debug.Log("asas");
            SceneManager.LoadScene(4);
        }
        else if (rightcharacter == 2)
        {
            PlayerPrefs.SetInt("right", 2);
            Debug.Log("pri");
            SceneManager.LoadScene(4);
        }
        else if (rightcharacter == 3)
        {
            PlayerPrefs.SetInt("right", 3);
            Debug.Log("mage");
            SceneManager.LoadScene(4);
        }
    }
}
