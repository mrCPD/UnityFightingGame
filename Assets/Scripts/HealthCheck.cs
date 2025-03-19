using UnityEngine;
using UnityEngine.UI;

public class HealthCheck : MonoBehaviour
{
    [SerializeField] private GameObject[] character;
    [SerializeField] private GameObject[] characterbot;
    [SerializeField] private GameObject[] disable;
    [SerializeField] private Text[] winnerText;

    private GameObject botcharacter;
    private GameObject playercharacter;

    private void Start()
    {
        PlayerPrefs.SetInt("FlameStop", 0);
        foreach (Text wcharacter in winnerText)
        {
            wcharacter.gameObject.SetActive(false);
        }

        foreach (GameObject bcharacter in character)
        {
            if (bcharacter.activeInHierarchy)
            {
                botcharacter = bcharacter;
            }
        }

        foreach (GameObject pcharacter in characterbot)
        {
            if (pcharacter.activeInHierarchy)
            {
                playercharacter = pcharacter;
            }
        }
    }

    void Update()
    {
        Health hlbot = botcharacter.GetComponent<Health>();
        Health hlplayer = playercharacter.GetComponent<Health>();
        if (hlbot.health == 0)
        {
            PlayerPrefs.SetInt("FlameStop", 1);
            foreach (GameObject todisable in disable)
            {
                todisable.SetActive(false);
                winnerText[0].gameObject.SetActive(true);
                winnerText[2].gameObject.SetActive(true);
            }
        }
        if (hlplayer.health == 0)
        {
            PlayerPrefs.SetInt("FlameStop", 1);
            foreach (GameObject todisable in disable)
            {
                todisable.SetActive(false);
                winnerText[1].gameObject.SetActive(true);
                winnerText[2].gameObject.SetActive(true);
            }   
        }
    }
}
