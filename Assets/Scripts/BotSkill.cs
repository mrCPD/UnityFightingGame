using UnityEngine;
using System.Collections;

public class BotSkill : MonoBehaviour
{
    [SerializeField] private GameObject[] character;
    [SerializeField] private GameObject[] hpcharacter;
    [SerializeField] private GameObject[] targetCharacters;

    private GameObject activeCharacter;
    private int difficulty;

    void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");

        foreach (GameObject bcharacter in character)
        {
            if (bcharacter.activeInHierarchy)
            {
                activeCharacter = bcharacter;
                StartCoroutine(ActivateSkill(activeCharacter.name));
                break;
            }
        }
    }

    IEnumerator ActivateSkill(string characterName)
    {
        switch (characterName)
        {
            case "WarriorRight":
                yield return StartCoroutine(WarriorBotSkill());
                break;
            case "AsasRight":
                yield return StartCoroutine(AsasBotSkill());
                break;
            case "PriestRight":
                yield return StartCoroutine(PriestBotSkill());
                break;
            case "MageRight":
                yield return StartCoroutine(MageBotSkill());
                break;
        }
    }

    IEnumerator PriestBotSkill()
    {
        yield return new WaitForSeconds(GetStartDelay());

        GameObject hpCharacter = GetActiveCharacter(hpcharacter);
        if (hpCharacter == null) yield break;

        Health hl = hpCharacter.GetComponent<Health>();
        if (hl == null) yield break;

        while (hl.health > 0)
        {
            hl.Heal(GetHealAmount(400, 425, 450, 500));
            yield return new WaitForSeconds(GetCooldown(4f, 3.5f, 3f, 2.5f));
        }
    }

    IEnumerator AsasBotSkill()
    {
        yield return new WaitForSeconds(GetStartDelay());

        GameObject hpCharacter = GetActiveCharacter(hpcharacter);
        if (hpCharacter == null) yield break;

        Health hl = hpCharacter.GetComponent<Health>();
        if (hl == null) yield break;

        while (hl.health > 0)
        {
            hl.Heal(GetHealAmount(30, 40, 50, 60));
            yield return new WaitForSeconds(GetCooldown(0.6f, 0.5f, 0.4f, 0.3f));
        }
    }

    IEnumerator WarriorBotSkill()
    {
        yield return new WaitForSeconds(GetStartDelay());

        while (true)
        {
            PlayerPrefs.SetInt("slowchar", 1);
            yield return new WaitForSeconds(GetCooldown(3f, 3.5f, 4f, 4.5f));
            PlayerPrefs.SetInt("slowchar", 0);
            yield return new WaitForSeconds(GetCooldown(4f, 3.5f, 3f, 2.5f));
        }
    }

    IEnumerator MageBotSkill()
    {
        yield return new WaitForSeconds(GetStartDelay());

        GameObject targetCharacter = GetActiveCharacter(targetCharacters);
        if (targetCharacter == null) yield break;

        Health hl = targetCharacter.GetComponent<Health>();
        if (hl == null) yield break;

        while (hl.health > 0)
        {
            hl.Flame(GetDamageAmount(100, 125, 150, 175));
            yield return new WaitForSeconds(GetCooldown(10f, 10f, 10f, 10f));
        }
    }

    // Helper function to get the first active character from an array
    private GameObject GetActiveCharacter(GameObject[] characters)
    {
        foreach (GameObject character in characters)
        {
            if (character.activeInHierarchy) return character;
        }
        return null;
    }

    // Helper function to get start delay based on difficulty
    private float GetStartDelay()
    {
        return new float[] { 1f, 0.8f, 0.6f, 0.4f }[difficulty];
    }

    // Helper function to get heal amounts based on difficulty
    private int GetHealAmount(int easy, int normal, int hard, int extreme)
    {
        return new int[] { easy, normal, hard, extreme }[difficulty];
    }

    // Helper function to get damage amounts based on difficulty
    private int GetDamageAmount(int easy, int normal, int hard, int extreme)
    {
        return new int[] { easy, normal, hard, extreme }[difficulty];
    }

    // Helper function to get cooldown time based on difficulty and slow mode
    private float GetCooldown(float easy, float normal, float hard, float extreme)
    {
        float[] cooldowns = { easy, normal, hard, extreme };
        int slowMode = PlayerPrefs.GetInt("slow"); // Slow modunu her bekleme süresi öncesi kontrol et
        return slowMode == 0 ? cooldowns[difficulty] : cooldowns[difficulty] * 2f;
    }
}