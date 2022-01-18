using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
