using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private GameObject[] leftCharacters;
    [SerializeField] private GameObject[] rightCharacters;

    void Start()
    {
        ActivateCharacter(PlayerPrefs.GetInt("left"), leftCharacters);
        ActivateCharacter(PlayerPrefs.GetInt("right"), rightCharacters);
    }

    void ActivateCharacter(int index, GameObject[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }
}
