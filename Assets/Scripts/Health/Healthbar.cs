using System.Collections;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public bool IsDamagable { set; get; } = true;

    [SerializeField] private SpriteRenderer blood;

    [SerializeField] private Transform target;

    public float smoothSpeed = 0.125f;
    public float offsetX;
    public float offsetY;

    public float CurrentHealth = 1.65f;

    private void Awake() => blood.size = new Vector2(1.65f, 0.25f);

    public IEnumerator DescreaseHealth(float damage)
    {
        IsDamagable = false;
        CurrentHealth = blood.size.x;
        float damageHealth = CurrentHealth - damage / 10f;

        if (damageHealth < 0)
        {
            damageHealth = 0;
            CurrentHealth = 0;
        }
        blood.size = new Vector2(damageHealth, blood.size.y);

        yield return new WaitForSeconds(1f);
        IsDamagable = true;
    }

    public void Update()
    {
        var desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}