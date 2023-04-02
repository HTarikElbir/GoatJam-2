using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButtons : MonoBehaviour
{
    // Start is called before the first frame update
    private bool soundOn;

    public void startGame()
    {
        soundOn=true;  
        SceneManager.LoadScene("SampleScene");
    }
    public void exitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void firstScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SoundButton()
    {
       
        
        soundOn = !soundOn;
        if (soundOn)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
        

    }
    
}
