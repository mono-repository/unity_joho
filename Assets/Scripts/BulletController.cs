using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed; // 弾の速度
    private Vector3 targetPosition = new Vector3(2, 0, 0); // 弾が向かう位置
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance < 0.01f)
        {
            transform.position = targetPosition;
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
