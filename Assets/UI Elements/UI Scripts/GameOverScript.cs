
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    // 1
    void Start()
    {

  
    }
    private void Update()
    {
   

    }


    public void RestartGame(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }
    // 4
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
    // 5
    public void MainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

}
