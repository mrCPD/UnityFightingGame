using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Slider hpImage;

    public int health;
    public int fullhealth;

    void Start()
    {
        healthText.text = health.ToString() + "/" + fullhealth;
        hpImage.value = 1f; // Baþlangýçta tam dolu
        UpdateHPImage();
    }

    public void Damage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        UpdateHPImage();
        UpdateUI();
    }

    public void Flame(int damage)
    {
        StartCoroutine(ExecuteFlame(damage));
    }

    public void Heal(int heal)
    {
        health += heal;
        health = Mathf.Min(fullhealth, health);
        UpdateHPImage();
        UpdateUI();
    }

    void UpdateHPImage()
    {
        hpImage.value = (float)health / fullhealth; // Slider deðeri saðlýk yüzdesi olarak ayarlanýyor
    }

    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString() + "/" + fullhealth;
        }
    }

    private IEnumerator ExecuteFlame(int damage)
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt("FlameStop") > 0)
            {
                break;
            }

            health -= damage;
            health = Mathf.Max(0, health);
            UpdateHPImage();
            UpdateUI();

            yield return new WaitForSeconds(1f);
        }
    }
}