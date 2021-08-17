using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Finish : MonoBehaviour
{
    
    [SerializeField] GameEvent winEvent;
    [SerializeField] ParticleSystem particle; 
    [SerializeField] CinemachineVirtualCamera cam1; 
    [SerializeField] CinemachineVirtualCamera cam2; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player");
            winEvent.Raise();
            Instantiate(particle, transform.position,transform.rotation);
            cam1.Priority = 1;
            cam1.Priority = 10;
        }
    }
}
