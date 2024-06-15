using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().GetDamage(1f);
            StartCoroutine(other.GetComponent<PlayerMovement>().GetHurt());
        }
    }
}
