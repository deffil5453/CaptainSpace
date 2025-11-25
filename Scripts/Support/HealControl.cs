using TMPro;
using UnityEngine;

public class HealControl : MonoBehaviour
{
    [SerializeField] private float HealthScore = 10f;
    public TMP_Text HealthText;

    public float GetHealth()
    {
        return HealthScore;

    }
    public void SummingHealth(float atack)
    {
        HealthScore += atack / 10;
        if (HealthScore >= 100f)
        {
            HealthScore = 100f;
        }
        else
        {
            UpdateText();
        }
    }
    private void UpdateText()
    {
        HealthText.text = HealthScore.ToString() + "%";
    }
}
