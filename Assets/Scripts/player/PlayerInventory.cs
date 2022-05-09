using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    public int fish = 0;
    public GameObject Fish1;
    public GameObject Fish2;
    public GameObject Fish3;
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
            if (fish == 1)
            {
                Fish1.SetActive(true);
            }
            if (fish == 2)
            {
                Fish2.SetActive(true);
            }
            if (fish == 3)
            {
                Fish3.SetActive(true);
            }
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
