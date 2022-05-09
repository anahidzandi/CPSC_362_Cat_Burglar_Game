using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    [SerializeField] private FieldOfView fieldOfView;



    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(transform.forward);
        //fieldOfView.SetAimDirection(transform.position);
    }
}
