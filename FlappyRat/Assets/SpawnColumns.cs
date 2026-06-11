using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spamw : MonoBehaviour
{
    [SerializeField] private GameObject columnPrefab;
    [SerializeField] private float spawnRate = 2;
    void Start()
    {
       InvokeRepeating("SpawnColumn", 0, spawnRate); 
    }

    
    void SpawnColumn()
    {
        float  randomY = Random.Range (-4f, 4f);
        Instantiate(columnPrefab, new Vector3(19, randomY, 0), Quaternion.identity);
    }
}
