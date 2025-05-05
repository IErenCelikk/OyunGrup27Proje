using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OpenMazeScene() 
    {
        SceneManager.LoadScene("Maze");
    }
}
