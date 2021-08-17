using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float enemyMaxSpeed;
    [SerializeField] float enemyMinSpeed;
    private float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(enemyMaxSpeed, enemyMinSpeed);

        rb.velocity = new Vector3(rb.velocity.x ,rb.velocity.y, speed *Time.deltaTime) ;
    }

  
}
