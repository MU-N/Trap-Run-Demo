using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsecle : MonoBehaviour
{
    [SerializeField] bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        isRight = transform.position.x > 0;
        if (isRight )
        LeanTween.rotateAroundLocal(gameObject, Vector3.up,-360, 2).setLoopType(LeanTweenType.easeInCirc);
        else
        LeanTween.rotateAroundLocal(gameObject, Vector3.up,360, 2).setLoopType(LeanTweenType.easeInCirc);
        
    }

    
}
