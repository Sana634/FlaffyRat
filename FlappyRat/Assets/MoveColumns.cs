using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class MoveColumns : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -19)
        {
            Destroy(gameObject);
        }
    }
}
