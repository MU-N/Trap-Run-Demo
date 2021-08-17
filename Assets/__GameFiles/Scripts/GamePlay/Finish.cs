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
            winEvent.Raise();
            Instantiate(particle, new Vector3 (transform.position.x , transform.position.y +10 , transform.position.z ), Quaternion.identity);
            cam1.Priority = 1;
            cam1.Priority = 10;
        }
    }
}
