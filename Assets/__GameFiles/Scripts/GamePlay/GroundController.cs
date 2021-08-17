using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private Material walkOnMat;
    [SerializeField] private float waitTimer = 0.25f;
    Rigidbody rb;
    Renderer render;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }
    private void Update()
    {
        CheckForLocation();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            StartCoroutine(WaitForTime(waitTimer));
            render.material = walkOnMat;
        }
        
    }

    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.isKinematic = false;
    }
    private void CheckForLocation()
    {
        if (transform.position.y <= -30)
        {
            rb.isKinematic = true;
            gameObject.SetActive(false);
        }
    }

}
