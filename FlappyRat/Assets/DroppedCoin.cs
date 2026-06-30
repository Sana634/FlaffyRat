using UnityEngine;

public class DroppedCoin : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 velocity)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.velocity = velocity;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
