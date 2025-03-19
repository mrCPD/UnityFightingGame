using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] private GameObject[] targetCharacters;

    private int flame;

    public void FlameGiven()
    {
        GameObject targetCharacter = null;

        foreach (GameObject character in targetCharacters)
        {
            if (character.activeInHierarchy) // Corrected from activeInHierarchy
            {
                targetCharacter = character;
                break;
            }
        }
        // If there's an active target character, apply damage
        if (targetCharacter != null)
        {
            Health hl = targetCharacter.GetComponent<Health>();

            flame = 150;

            if (hl != null)
            {
                hl.Flame(flame);
            }
        }
        else
        {
            Debug.LogWarning("No active target character found.");
        }
    }
}
