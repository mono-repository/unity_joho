using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 targetPosition = new Vector3(2, 0, 0);

    void Update()
    {
        // 現在地点と目標地点の間の距離を計算
        float distance = Vector3.Distance(transform.position, targetPosition);

        // ある程度近づいたら停止（オブジェクトが目標に到達したと見なす）
        if (distance < 0.01f)
        {
            transform.position = targetPosition;
            Destroy(gameObject);
        }
        else
        {
            // 目標地点に向かって一定速で移動
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
