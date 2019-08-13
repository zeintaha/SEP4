using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
    public bool AllAttachedBool { get; private set; }

   void Start () {  
    }
	
	void Update () {	
	}
    public void resetButton()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void playButton()
    {
        SceneManager.LoadScene("AVRHouse");
        Debug.Log("play button is pressed");
    }

    public void nextButton1()
    {
        SceneManager.LoadScene("AVRRobot");
       
    }
    public void nextButton2()
    {
        SceneManager.LoadScene("AVRFurniture");
    }

    public void nextButton3()
    {
        SceneManager.LoadScene("AVRLast");
    }
    public void returnButton()
    {
        SceneManager.LoadScene("AVRMain");
    }
    public void exitButton()
    {
        Application.Quit();
        Debug.Log("exit touched");
    }
}
