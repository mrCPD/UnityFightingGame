using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameObject[] targetCharacters;
    [SerializeField] private GameObject[] damageCharacters;

    private int damage;

    public void DamageGiven()
    {
        GameObject targetCharacter = System.Array.Find(targetCharacters, c => c.activeInHierarchy);
        GameObject damageCharacter = System.Array.Find(damageCharacters, c => c.activeInHierarchy);

        if (damageCharacter != null)
        {
            damage = damageCharacter.name switch
            {
                "Priest" => 150,
                "Asas" => 200,
                "Warrior" or "Mage" => 250,
                _ => 0
            };
        }

        targetCharacter?.GetComponent<Health>()?.Damage(damage);
    }
}