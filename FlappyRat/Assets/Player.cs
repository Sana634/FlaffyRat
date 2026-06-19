using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            rb.velocity = new Vector2(0f, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;

        GameManager.Instance?.HandleObstacleHit(transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Coin")) return;

        GameManager.Instance?.CollectCoin(other.gameObject);
    }
}
