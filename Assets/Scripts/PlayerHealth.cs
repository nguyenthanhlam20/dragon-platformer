using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Healthbar healthBar;

    public void GetDamage(float damange)
    {
        if (healthBar.IsDamagable) StartCoroutine(healthBar.DescreaseHealth(damange));
    }

}
