using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Door");
        if (FindObjectOfType<PlayerInventory>().hasKey == true)
        {
            FindObjectOfType<GameManager>().levelComplete();
        }
    }
}
