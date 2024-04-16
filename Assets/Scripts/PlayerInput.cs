using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject[] interactiveObjects;
    private PlayerController playerController;
    public SerialHandler serialHandler;

    private bool useKeyboardInput = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (SerialHandler.Instance != null)
        {
            if (!SerialHandler.Instance.IsOpenSuccessful)
            {
                useKeyboardInput = true;
            }
            else
            {
                SerialHandler.Instance.OnDataReceived += OnDataReceived; // イベントに登録
            }
        }
        else
        {
            Debug.LogWarning("SerialHandler instance not found");
            useKeyboardInput = true;
        }
    }


    void OnDataReceived(string message)
    {
        if (!useKeyboardInput)
        {
            SerialInput(message);
        }
    }

    private void Update()
    {
        if (useKeyboardInput)
        {
            KeyboardInput();
        }
    }

    private void SerialInput(string message)
    {
        Debug.Log("Received: " + message);
        string[] parts = message.Split(' ');
        if (parts.Length >= 2)
        {
            int btnNumber;
            if (int.TryParse(parts[0], out btnNumber) && btnNumber >= 1 && btnNumber <= 9)
            {
                int adjustedIndex = (btnNumber > 5) ? btnNumber - 2 : btnNumber - 1;

                if (btnNumber == 5 && parts[1] == "ON")
                {
                    if (playerController.currentSP >= playerController.maxSP)
                    {
                        playerController.ActivateSP();
                        Debug.Log("Used SP");
                    }
                }
                else if (parts[1] == "ON")
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

    private void KeyboardInput()
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
