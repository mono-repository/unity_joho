using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate ; // 弾を生成する頻度
    public float radius ; // 半径
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
        timer -= Time.deltaTime; // タイマーを減少させる
        if (timer <= 0f) // タイマーが0になったら
        {
            GenerateBullet(); // 生成
            timer = spawnRate; // タイマーをリセット
        }
    }

    void GenerateBullet()
    {
        // ランダムな生成位置を選ぶ
        Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // 弾を生成
        Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
    }
}
