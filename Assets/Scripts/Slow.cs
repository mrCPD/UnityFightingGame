using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("slow", 0);
    }

    public void SlowGiven()
    {
        StartCoroutine(ChangeValueCoroutine());
    }

    IEnumerator ChangeValueCoroutine()
    {
        PlayerPrefs.SetInt("slow", 1);

        yield return new WaitForSeconds(3f); // Wait for a certain duration

        PlayerPrefs.SetInt("slow", 0);
    }
}
