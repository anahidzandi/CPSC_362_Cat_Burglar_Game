using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    public int fish = 0;

    public void restartInventory()
    {
        hasKey = false;
        fish = 0;
    }

    private void Start()
    {
        hasKey = false;
        fish = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Key"))
        {
            Destroy(collider.gameObject);
            hasKey = true;
            Debug.Log(hasKey);
        }

        if (collider.gameObject.CompareTag("fish"))
        {
            Destroy(collider.gameObject);
            fish += 1;
            print(fish);
        }

        if (collider.gameObject.CompareTag("door"))
        {
            if (hasKey == true)
            {
                Debug.Log("PlayerInv");
                FindObjectOfType<GameManager>().levelComplete();
            }
        }
    }
}
