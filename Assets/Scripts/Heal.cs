using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal;
    public void HealTaken()
    {
        Health hl = GetComponent<Health>();

        // Check if the Health component exists
        if (hl != null)
        {
            // Call the Damage function of the Health component with the damage value
            hl.Heal(heal);

        }
    }
}
