using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColumns : MonoBehaviour
{
    [SerializeField] private GameObject columnPrefab;
    [SerializeField] private float spawnRate = 2;
    [SerializeField] private float gapSize = 3f;
    [SerializeField] private float minGapCenterY = -1f;
    [SerializeField] private float maxGapCenterY = 2f;
    void Start()
    {
       InvokeRepeating("SpawnColumn", 0, spawnRate); 
    }

    
void SpawnColumn()
{
    GameObject col = Instantiate(columnPrefab, new Vector3(19, 0, 0), Quaternion.identity);
    
    Transform upper = col.transform.Find("Upper");
    Transform lower = col.transform.Find("Lower");
    
    float gapSize = Random.Range(3f, 6f);
    float gapCenterY = Random.Range(minGapCenterY, maxGapCenterY);
    float halfGap = gapSize / 2f;

    upper.localPosition = new Vector3(Random.Range(-1f, 1f), gapCenterY + halfGap, 0);
    lower.localPosition = new Vector3(Random.Range(-1f, 1f), gapCenterY - halfGap, 0);
}
}
