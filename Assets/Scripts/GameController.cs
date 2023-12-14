using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timeToIncreaseDifficulty = 60f; // 難易度が上がるまでの時間（秒）
    public float difficultyMultiplier = 1.1f;   // 難易度が上がる度に適用される乗数
    private float timeSinceLastIncrease = 0f;

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
        BulletController.speedMultiplier *= difficultyMultiplier;
    }
}

