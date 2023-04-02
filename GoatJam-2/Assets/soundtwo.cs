using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtwo : MonoBehaviour
{
    private bool soundOn;
    private void Start() {
        soundOn=true;
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
