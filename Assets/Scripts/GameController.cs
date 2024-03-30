using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BulletGenerator bulletGenerator;
    public float timeToIncreaseDifficulty = 60f; // 難易度が上がるまでの時間（秒）
    public float difficultyIncreaseAmount = 0.9f;

    private float timeSinceLastIncrease = 0f;

    void Start()
    {
        bulletGenerator = FindObjectOfType<BulletGenerator>();
    }

    void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= timeToIncreaseDifficulty)
        {
            IncreaseDifficulty();
            timeSinceLastIncrease = 0f;
        }
    }

    void IncreaseDifficulty()
    {
        bulletGenerator.spawnRate *= difficultyIncreaseAmount;
        bulletGenerator.spawnRate = Mathf.Max(bulletGenerator.spawnRate, 0.1f);
    }
}

