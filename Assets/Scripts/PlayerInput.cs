using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject[] interactiveObjects;

    void Update()
    {
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
