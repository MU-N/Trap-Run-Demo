using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] GameEvent gameLose;
    [SerializeField] float enemyMaxSpeed;
    [SerializeField] float enemyMinSpeed;
    private float speed;
    Rigidbody rb;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = Random.Range(enemyMaxSpeed, enemyMinSpeed);

    }
    private void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,speed * Time.deltaTime);
        CheckForLocation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameLose.Raise();
        }
    }
    private void CheckForLocation()
    {
        if (transform.position.y <= -30)
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        ObjectPool.SharedInstance.ReturnToPool(gameObject);
    }

}
