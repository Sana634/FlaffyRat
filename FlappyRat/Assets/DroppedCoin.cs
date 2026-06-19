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
        rb.velocity = velocity;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
