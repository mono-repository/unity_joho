using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Color defaultColor;
    public bool isActive = false;

    void Start()
    {
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

    void OnTriggerStay2D(Collider2D collider)
    {
        if (isActive && collider.gameObject.CompareTag("Bullet"))
        {
            Destroy(collider.gameObject);
        }
    }
}
