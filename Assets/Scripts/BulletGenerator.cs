using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���t�@�u���A�T�C�����܂��B
    public float spawnRate = 1f; // �e�𐶐�����p�x�i�b�j
    public float radius = 6f;
    private Vector2[] spawnPoints;

    void Start()
    {
        spawnPoints = new Vector2[]// 8�����̃x�N�g��
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
    private float timer; // �^�C�}�[

    void Update()
    {
        timer -= Time.deltaTime; // �^�C�}�[�����������܂��B
        if (timer <= 0f) // �^�C�}�[��0�ɂȂ�����
        {
            GenerateBullet(); // �e�𐶐����܂��B
            timer = spawnRate; // �^�C�}�[�����Z�b�g���܂��B
        }
    }

    void GenerateBullet()
    {
        // �����_���Ȑ����ʒu��I�т܂��B
        Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // �e�𐶐����܂��B
        Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
    }
}
