using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{



    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
