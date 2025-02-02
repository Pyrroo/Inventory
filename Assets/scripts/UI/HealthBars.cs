using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBars : MonoBehaviour
{
    [SerializeField] private Slider HeroSlider, EnemySlider;
    [SerializeField] private TextMeshProUGUI HeroText, EnemyText;

    public void SetHeroSlider(int value)
    {
        HeroSlider.value = value;
        HeroText.text = value.ToString();
    }
    public void SetEnemySlider(int value)
    {
        EnemySlider.value = value;
        EnemyText.text = value.ToString();
    }
}
