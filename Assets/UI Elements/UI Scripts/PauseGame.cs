using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public Transform canvas;
    public Transform creditCanvas;



    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game paused");
            if(canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                creditCanvas.gameObject.SetActive(false);
                Time.timeScale = 0.0f;
         
            }
            else
            {
                canvas.gameObject.SetActive(false);
                
                Time.timeScale = 1.0f;
            }
        }	
	}

    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
  
}
