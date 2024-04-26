using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Color defaultColor;
    public bool isActive = false;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    public void Activate()
    {
        isActive = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void Deactivate()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().color = defaultColor;
    }

    public void Reset()
    {
        Deactivate();  // 非アクティブ状態に設定し、デフォルトの色に戻す
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (isActive && collider.gameObject.CompareTag("Bullet"))
        {
            Destroy(collider.gameObject);
            playerController.AddSP(5);
            playerController.UpdateSPText();
            playerController.IncreaseScore(100);
            playerController.UpdateScoreText();
        }
    }
}
