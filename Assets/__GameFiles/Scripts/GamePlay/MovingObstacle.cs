using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    void Start()
    {
        if (transform.position.x < 0)
            LeanTween.move(gameObject, new Vector3(3f, transform.position.y, transform.position.z), 3).setLoopPingPong();
        else
            LeanTween.move(gameObject, new Vector3(-3f, transform.position.y, transform.position.z), 3).setLoopPingPong();

    }


}
