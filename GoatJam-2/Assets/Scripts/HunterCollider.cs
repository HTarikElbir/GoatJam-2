using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HunterCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag=="Player")
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        print("Reloading the scene");
        SceneManager.LoadScene("GameOverScene");

    }
}
