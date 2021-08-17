using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsNewEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitForTime(1.25f));
        }
    }
    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = ObjectPool.SharedInstance.GetFromPool();
            enemy.SetActive(true);
            enemy.transform.position = new Vector3((-3 + i) * 1.2f, 0.5f, transform.position.z);
        }

    }
}
