using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject[] interactiveObjects;
    private PlayerController playerController;
    public SerialHandler serialHandler;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string message)
    {
        Debug.Log("Received: " + message);
        if (message.StartsWith("Btn"))
        {
            string[] parts = message.Split(' ');
            if (parts.Length >= 2)
            {
                int btnNumber;
                if (int.TryParse(parts[0].Substring(3), out btnNumber))
                {
                    if (btnNumber == 5 && parts[1] == "ON")
                    {
                        if (playerController.currentSP >= playerController.maxSP)
                        {
                            playerController.ActivateSP();
                            Debug.Log("Used SP");
                        }
                        
                    }

                    else if (btnNumber >= 1 && btnNumber <= 9)
                    {
                        int adjustedIndex = (btnNumber > 5) ? btnNumber - 2 : btnNumber - 1;

                        if (parts[1] == "ON")
                        {
                            interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Activate();
                        }
                        else if (parts[1] == "OFF")
                        {
                            interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Deactivate();
                        }
                    }
                }
            }
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown("5"))
    //    {
    //        if (playerController.currentSP >= playerController.maxSP)
    //        {
    //            playerController.ActivateSP();
    //            Debug.Log("Used SP");
    //        }
    //    }

    //    for (int i = 1; i <= 9; i++)
    //    {
    //        if (i == 5) continue;

    //        int adjustedIndex = (i > 5) ? i - 2 : i - 1;

    //        if (Input.GetKeyDown(i.ToString()))
    //        {
    //            interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Activate();
    //        }
    //        if (Input.GetKeyUp(i.ToString()))
    //        {
    //            interactiveObjects[adjustedIndex].GetComponent<InteractiveObject>().Deactivate();
    //        }
    //    }
    //}
}
