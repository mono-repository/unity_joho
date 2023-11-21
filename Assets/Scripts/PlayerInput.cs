using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject[] interactiveObjects;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("5"))
        {
            if (playerController.currentSP >= playerController.maxSP)
            {
                playerController.ActivateSP();
                Debug.Log("Used SP");
            }
        }

        for (int i = 1; i <= 9; i++)
        {
            if (i == 5) continue;

            int adjustedIndex = (i > 5) ? i - 2 : i - 1;

            if (Input.GetKeyDown(i.ToString()))
            {
                interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Activate();
            }
            if (Input.GetKeyUp(i.ToString()))
            {
                interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Deactivate();
            }
        }
    }
}
