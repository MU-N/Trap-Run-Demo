using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour
{
    [SerializeField] GameEvent loseEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loseEvent.Raise();

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
