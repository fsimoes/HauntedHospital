using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }

	public void Quit()
	{
		Application.Quit ();
		Debug.Log ("Quit");

	}
}
