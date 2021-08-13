using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100;
    [SerializeField] float directinalSpeed = 15;
    [SerializeField] float maxEdgeDis = 3;
    float hor;
    Vector3 tempValue;
    Vector2 touchValue;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR 
        hor = Input.GetAxis("Horizontal");
        tempValue = new Vector3(Mathf.Clamp(transform.position.x + hor, -maxEdgeDis, maxEdgeDis), transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, tempValue, directinalSpeed * Time.deltaTime);
        if(hor!=0)
        {
            rb.velocity = Vector3.forward * moveSpeed * Time.deltaTime;
        }
#endif
        
        touchValue = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touchValue.x, transform.position.y, transform.position.z) *Time.deltaTime;
           
        }
        rb.velocity = Vector3.forward * moveSpeed * Time.deltaTime;
    }
}
