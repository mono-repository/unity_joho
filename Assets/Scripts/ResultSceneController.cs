using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneController : MonoBehaviour
{
    void OnEnable()
    {
        if (SerialHandler.Instance != null)
        {
            SerialHandler.Instance.OnDataReceived += HandleSerialData; // �V���O���g���C���X�^���X����C�x���g�ɓo�^
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
            SerialHandler.Instance.OnDataReceived -= HandleSerialData; // �V���O���g���C���X�^���X����C�x���g�̓o�^����
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
