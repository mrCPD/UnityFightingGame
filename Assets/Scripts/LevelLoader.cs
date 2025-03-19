using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadBot()
    {
        SceneManager.LoadScene(1);
    }

    public void Load1v1()
    {

    }

    public void LoadOnline()
    {

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
