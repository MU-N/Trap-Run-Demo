using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsNewEnemy : MonoBehaviour
{
    WaitForSeconds seconds = new WaitForSeconds(2f);
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitForFewSeconds());
            
        }
    }
    IEnumerator WaitForFewSeconds()
    {

        yield return seconds;
        for (int i = 0; i < 7; i++)
        {
            GameObject enemy = ObjectPool.SharedInstance.GetFromPool();
            enemy.SetActive(true);
            enemy.transform.position = new Vector3((-3 + i) * 1.2f, 0.5f, transform.position.z);
        }
    }
}
