using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    [SerializeField] TMP_Text fpsText;
    [SerializeField] float deltaTime;
    private void Start()
    {
    }

    void Update()
    {
        
        float fps = 1.0f / Time.deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();

    }
}
