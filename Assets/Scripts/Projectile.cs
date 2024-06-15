using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 1f;
    private float direction;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = transform.position.x + speed * Time.deltaTime * direction;
        transform.position = new Vector2(movementSpeed, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            hit = true;
            collision.GetComponent<Enemy>().GetHurt(damage: damage);
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
        }
    }

    public void Deactivate() => gameObject.SetActive(false);

    public void SetDirection(float _direction)
    {
        direction = _direction;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void OnBecameInvisible() => gameObject.SetActive(false);

    private void OnEnable()
    {
        hit = false;
        boxCollider.enabled = true;
    }
}