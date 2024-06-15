using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [SerializeField] float movingSpeed = 1f;

    [SerializeField] float strength = 2f;

    public bool IsMoving { set; get; } = true;

    private Direction currentDirection = Direction.Left;
    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField] private Healthbar healthbar;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 target = currentDirection == Direction.Left ? startPoint.position : endPoint.position;

        Vector2 current = transform.position;
        if (Vector2.Distance(current, startPoint.position) < 0.1f)
        {
            currentDirection = Direction.Right;
            sr.flipX = false;
        };
        if (Vector2.Distance(current, endPoint.position) < 0.1f)
        {
            currentDirection = Direction.Left;
            sr.flipX = true;
        }

        transform.position = Vector2.Lerp(current, target, movingSpeed * Time.deltaTime);
    }

    public void GetHurt(float damage)
    {

        if (healthbar.CurrentHealth == 0f)
        {
            StopAllCoroutines();
            Destroy(transform.parent.gameObject);
        }
        anim.SetTrigger("hurt");
        StartCoroutine(healthbar.DescreaseHealth(damage: damage));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().GetDamage(strength);
            StartCoroutine(other.GetComponent<PlayerMovement>().GetHurt());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
