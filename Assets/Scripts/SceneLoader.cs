using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StoreLoad()
    {
        SceneManager.LoadScene("Store");
    }
    public void GameLoad()
    {
        SceneManager.LoadScene("Dzen mode");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
