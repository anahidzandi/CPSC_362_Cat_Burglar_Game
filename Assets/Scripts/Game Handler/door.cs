using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{

    public PlayerInventory pI;
    public GameObject Victory;

    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Door");
        if (FindObjectOfType<PlayerInventory>().hasKey == true)
        {
            FindObjectOfType<GameManager>().levelComplete();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerobject>())
        {
            if (pI.hasKey)
            {
                Debug.Log("Victory");
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    LevelUnlock.levelsUnlocked = 2;
                    Debug.Log("Levels Unlocked 2");
                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                    LevelUnlock.levelsUnlocked = 3;
                Time.timeScale = 0f;
                Victory.SetActive(true);
            }
        }
    }
}
