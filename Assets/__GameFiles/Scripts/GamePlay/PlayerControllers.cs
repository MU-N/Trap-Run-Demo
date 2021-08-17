using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameEvent touchStart;
    [SerializeField] GameEvent inHelicopter;


    [SerializeField] float moveSpeed = 100;
    [SerializeField] float directinalSpeed = 15;
    [SerializeField] float maxEdgeDis = 3;

    [SerializeField] Transform[] afterWinLocations;

    Vector2 touchValue;

    private bool isInHelicopter;
    Rigidbody rb;
    Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isInHelicopter = false;
        ResetGameData();
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if (!gameData.isGameStop)
        {
            CheckTouchInput();
            CheckAnimation();
        }
        else
        {
            anim.SetBool("isWin", gameData.isGameWin && isInHelicopter);
            anim.SetBool("isDead", gameData.isGameLose);
        }
        if (transform.position == afterWinLocations[0].position)
        {
            anim.SetBool("isWin",true);
            inHelicopter.Raise();
        }

    }



    private void CheckTouchInput()
    {
        touchValue = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 10f));
        if (Input.touchCount > 0)
        {
            touchStart.Raise();
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed * Time.deltaTime);
            if (Input.touches[0].phase == TouchPhase.Moved)
                transform.position = new Vector3(touchValue.x, transform.position.y, transform.position.z);
        }
    }

    private void CheckAnimation()
    {
        anim.SetBool("isMoving", Input.touchCount > 0);
    }

    public void MoveAfterWin(int index)
    {
        LeanTween.move(gameObject, afterWinLocations[index].position, 2.5f);
    }
    public void MoveAfterWinForPlane()
    {
        transform.position = afterWinLocations[1].position;
    }

    public void OnHelicopter()
    {
        isInHelicopter = true;
    }
    private void ResetGameData()
    {
        gameData.isGameLose = false;
        gameData.isGameWin = false;
        gameData.isGameStop = false;
    }

}
