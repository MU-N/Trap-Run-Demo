using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] GameEvent inHelicopter;
    [SerializeField] GameObject[] helicopterParts;

    public void RunWheels()
    {
        for (int i = 0; i < helicopterParts.Length; i++)
        {
            LeanTween.rotateAroundLocal(helicopterParts[i], Vector3.up, -360, 1).setLoopType(LeanTweenType.easeInCirc);
        }
        LeanTween.move(gameObject, Vector3.forward * 10, 5);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RunWheels();
            inHelicopter.Raise();
            
        }
    }
}
