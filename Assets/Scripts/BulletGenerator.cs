using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレファブをアサインします。
    public float spawnRate = 1f; // 弾を生成する頻度（秒）
    public float radius = 6f;
    private Vector2[] spawnPoints;

    void Start()
    {
        spawnPoints = new Vector2[]// 8方向のベクトル
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
        timer -= Time.deltaTime; // タイマーを減少させます。
        if (timer <= 0f) // タイマーが0になったら
        {
            GenerateBullet(); // 弾を生成します。
            timer = spawnRate; // タイマーをリセットします。
        }
    }

    void GenerateBullet()
    {
        // ランダムな生成位置を選びます。
        Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // 弾を生成します。
        Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
    }
}
