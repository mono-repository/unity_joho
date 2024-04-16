using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
