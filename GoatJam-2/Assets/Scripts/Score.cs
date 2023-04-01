using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float score;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manageTimer();
        score += Time.deltaTime;
        displayScore();
    }
    public void manageTimer()
    {
        timer += Time.deltaTime;
    }
    public void displayScore()
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "Score " +":"+ (int)score;
    }
}
