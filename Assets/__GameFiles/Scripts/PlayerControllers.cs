using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] GameEvent touchStart;


    [SerializeField] float moveSpeed = 100;
    [SerializeField] float directinalSpeed = 15;
    [SerializeField] float maxEdgeDis = 3;

    Vector2 touchValue;
    Rigidbody rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouchInput();
        CheckAnimation();

    }

   

    private void CheckTouchInput()
    {
        touchValue = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 10f));
        if (Input.touchCount > 0)
        {
            touchStart.Raise();
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed * Time.deltaTime);
            if (Input.touches[0].phase == TouchPhase.Moved)
                transform.position = new Vector3( touchValue.x , transform.position.y, transform.position.z);
        }
    }

    private void CheckAnimation()
    {
        anim.SetBool("isMoving", Input.touchCount > 0);
    }
}
