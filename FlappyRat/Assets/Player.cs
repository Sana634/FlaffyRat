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
        if( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
        {
            rb.velocity = new Vector2(0f, jumpForce);
        }
    }
}