using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneController : MonoBehaviour
{
    void OnEnable()
    {
        if (SerialHandler.Instance != null)
        {
            SerialHandler.Instance.OnDataReceived += HandleSerialData; // シングルトンインスタンスからイベントに登録
        }
        else
        {
            Debug.LogError("SerialHandler instance not found.");
        }
    }

    void OnDisable()
    {
        if (SerialHandler.Instance != null)
        {
            SerialHandler.Instance.OnDataReceived -= HandleSerialData; // シングルトンインスタンスからイベントの登録解除
        }
    }

    private void HandleSerialData(string data)
    {
        if (data.Contains("receiverPut"))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
