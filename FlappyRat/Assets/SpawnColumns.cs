using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class SpawnColumns : MonoBehaviour

{

    [SerializeField] private GameObject columnPrefab;
    [SerializeField] private float spawnRate = 2;
    [SerializeField] private float gapSize = 2f;
    [SerializeField] private float minGapCenterY = -1f;
    [SerializeField] private float maxGapCenterY = 2f;

    void Start()

    {
        InvokeRepeating(nameof(SpawnColumn), 0, spawnRate);
    }

    void SpawnColumn()
    {
        GameObject col = Instantiate(columnPrefab, new Vector3(19, 0, 0), Quaternion.identity);
        Transform upper = col.transform.Find("Upper");
        Transform lower = col.transform.Find("Lower");
        SpriteRenderer upperSprite = upper.GetComponent<SpriteRenderer>();
        SpriteRenderer lowerSprite = lower.GetComponent<SpriteRenderer>();


        Camera cam = Camera.main;
        float camY = cam.transform.position.y;
        float screenTop = camY + cam.orthographicSize;
        float screenBottom = camY - cam.orthographicSize;
        float halfGap = gapSize / 2f;
        float gapCenterY = Random.Range(
            Mathf.Max(minGapCenterY, screenBottom + halfGap),
            Mathf.Min(maxGapCenterY, screenTop - halfGap)

        );


        float gapTop = gapCenterY + halfGap;
        float gapBottom = gapCenterY - halfGap;
       float upperHeight = screenTop - gapTop;
        upper.localPosition = new Vector3(0, gapTop + upperHeight / 2f, 0);
        upperSprite.flipY = false;
        upperSprite.size = new Vector2(upperSprite.size.x, upperHeight);



        float lowerHeight = gapBottom - screenBottom;
        lower.localPosition = new Vector3(0, screenBottom + lowerHeight / 2f, 0);
        lowerSprite.flipY = false;
        lowerSprite.size = new Vector2(lowerSprite.size.x, lowerHeight);

    }

}


