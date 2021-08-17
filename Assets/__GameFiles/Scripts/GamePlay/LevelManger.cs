using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject enemy = ObjectPool.SharedInstance.GetFromPool();
            enemy.SetActive(true);
            enemy.transform.position = new Vector3((-3 + i) * 1.2f, 0.5f, transform.position.z);
        }
    }


}
