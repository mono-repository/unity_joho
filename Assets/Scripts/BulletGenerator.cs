using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate ;
    public float radius ;
    private Vector2[] spawnPoints;

    void Start()
    {
        spawnPoints = new Vector2[]
        {
            new Vector2(2, radius),
                new Vector2(2 + radius/Mathf.Sqrt(2), radius/Mathf.Sqrt(2)),
                new Vector2(2 + radius, 0),
                new Vector2(2 + radius/Mathf.Sqrt(2), -radius/Mathf.Sqrt(2)),
                new Vector2(2, -radius),
                new Vector2(2 - radius/Mathf.Sqrt(2), -radius/Mathf.Sqrt(2)),
                new Vector2(2 - radius, 0),
                new Vector2(2 - radius/Mathf.Sqrt(2), radius/Mathf.Sqrt(2))
        };
    }   
    private float timer; // タイマー

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            GenerateBullet();
            timer = spawnRate;
        }
    }

    void GenerateBullet()
    {
        Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
    }
}
