using UnityEngine;
using System.Collections;

public class BotDamage : MonoBehaviour
{
    [SerializeField] private GameObject[] character;
    [SerializeField] private GameObject[] targetCharacter;

    void Start()
    {
        foreach (GameObject bcharacter in character)
        {
            if (bcharacter.activeInHierarchy)
            {
                switch (bcharacter.name)
                {
                    case "WarriorRight":
                        StartCoroutine(BotRoutine(200, 225, 250, 300, 1.2f, 1f, 0.6f, 0.4f));
                        break;
                    case "AsasRight":
                        StartCoroutine(BotRoutine(150, 175, 200, 250, 1.2f, 1f, 0.6f, 0.4f));
                        break;
                    case "PriestRight":
                        StartCoroutine(BotRoutine(150, 175, 200, 250, 1.2f, 1f, 0.6f, 0.4f));
                        break;
                    case "MageRight":
                        StartCoroutine(BotRoutine(150, 175, 250, 300, 1.2f, 1f, 0.6f, 0.4f));
                        break;
                }
                break;
            }
        }
    }

    IEnumerator BotRoutine(int dmgEasy, int dmgNormal, int dmgHard, int dmgExtreme, float waitEasy, float waitNormal, float waitHard, float waitExtreme)
    {
        int difficulty = PlayerPrefs.GetInt("difficulty");
        int damage = difficulty switch
        {
            0 => dmgEasy,
            1 => dmgNormal,
            2 => dmgHard,
            _ => dmgExtreme
        };

        GameObject target = GetFirstActiveTarget();
        if (target == null) yield break;

        Health targetHealth = target.GetComponent<Health>();

        while (targetHealth != null && targetHealth.health > 0)
        {
            // Slow modunu her tur kontrol et
            float waitTime = difficulty switch
            {
                0 => waitEasy,
                1 => waitNormal,
                2 => waitHard,
                _ => waitExtreme
            };

            if (PlayerPrefs.GetInt("slow") == 1)
            {
                waitTime *= 2f;
            }

            targetHealth.Damage(damage);
            yield return new WaitForSeconds(waitTime);
        }
    }

    GameObject GetFirstActiveTarget()
    {
        foreach (GameObject target in targetCharacter)
        {
            if (target.activeInHierarchy)
            {
                return target;
            }
        }
        return null;
    }
}