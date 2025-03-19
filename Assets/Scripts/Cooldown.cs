using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private Image oncooldown;
    [SerializeField] private Image offcooldown;
    [SerializeField] private Image loading;

    public float delayTime; // Delay time

    void Start()
    {
        PlayerPrefs.SetInt("slowchar", 0);
    }

    public void CooldownControl()
    {
        if (oncooldown != null)
        {
            oncooldown.gameObject.SetActive(true);
            offcooldown.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            StartCoroutine(ChangeCooldownAfterDelay(delayTime));
        }
    }

    IEnumerator ChangeCooldownAfterDelay(float delay)
    {
        if (PlayerPrefs.GetInt("slowchar") == 0)
        {
            yield return new WaitForSeconds(delay);
        }
        else if (PlayerPrefs.GetInt("slowchar") != 0 && delay > 2)
        {
            yield return new WaitForSeconds(delay + 2);
        }
        else
        {
            yield return new WaitForSeconds(delay * 2);
        }
        // Change the state after the delay
        oncooldown.gameObject.SetActive(false);
        offcooldown.gameObject.SetActive(true);
        loading.gameObject.SetActive(false);
    }
}
