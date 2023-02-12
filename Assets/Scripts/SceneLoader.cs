using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void mainLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void storeLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void menuLoad()
    {
        SceneManager.LoadScene(0);
    }

    public void onExit()
    {
        Application.Quit();
    }
}
