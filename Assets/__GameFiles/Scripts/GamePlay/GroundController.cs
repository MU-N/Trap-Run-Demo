using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private Material walkOnMat;
    [SerializeField] private float waitTimer = 0.25f;
    Rigidbody rb;
    Renderer render;

    WaitForSeconds seconds = new WaitForSeconds(.4F);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }
    private void Update()
    {
        CheckForLocation();
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(WaitForFewSeconds());

            render.material = walkOnMat;
        }

    }

    private void CheckForLocation()
    {
        if (transform.position.y <= -30)
        {
            rb.isKinematic = true;
            gameObject.SetActive(false);
        }
    }
    IEnumerator WaitForFewSeconds()
    {

        yield return seconds;
        rb.isKinematic = false;
    }
}
