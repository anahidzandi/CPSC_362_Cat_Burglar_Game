using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Works");
        
        if (collider.gameObject.CompareTag("Key"))
        {
            Debug.Log("Works");
            Destroy(collider.gameObject);
        }
        
    }
}
