using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public GameObject GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerobject>())
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}