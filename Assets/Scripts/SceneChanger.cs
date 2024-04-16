using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SerialHandler serialHandler;

    void OnEnable()
    {
        serialHandler.OnDataReceived += HandleSerialData;
    }

    void OnDisable()
    {
        serialHandler.OnDataReceived -= HandleSerialData;
    }

    private void HandleSerialData(string data)
    {
        if (data.Contains("receiverPulled"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
