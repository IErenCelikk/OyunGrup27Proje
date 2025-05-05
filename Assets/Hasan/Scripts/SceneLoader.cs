using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OpenMazeScene() 
    {
        SceneManager.LoadScene("Maze");
    }

    public void OpenRunnerScientistScene()
    {
        SceneManager.LoadScene("RunnerScientist");
    }

    public void OpenBossScene()
    {
        SceneManager.LoadScene("BossScene");
    }
}
