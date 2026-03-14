using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGane()
    {
        Application.Quit();
    }

    public void LoseGame()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
