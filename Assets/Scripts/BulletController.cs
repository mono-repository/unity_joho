using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 targetPosition = new Vector3(2, 0, 0);

    void Update()
    {
        // ���ݒn�_�ƖڕW�n�_�̊Ԃ̋������v�Z
        float distance = Vector3.Distance(transform.position, targetPosition);

        // ������x�߂Â������~�i�I�u�W�F�N�g���ڕW�ɓ��B�����ƌ��Ȃ��j
        if (distance < 0.01f)
        {
            transform.position = targetPosition;
            Destroy(gameObject);
        }
        else
        {
            // �ڕW�n�_�Ɍ������Ĉ�葬�ňړ�
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
