using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject tryAginButton;
    [SerializeField] GameObject handImage;
    private void Start()
    {
        LeanTween.moveX(handImage, 100, 1).setLoopPingPong();
    }
    private void Update()
    {
        
    }

    public void OnGameOver()
    {
        gameOverMenu.SetActive(true);
        LeanTween.scale(gameOverText, new Vector3(1f, 1f, 1f), .5f).setEaseOutBounce() ;
        LeanTween.scale(tryAginButton,new Vector3(1f,1f,1f),.5f).setEaseOutBounce();
    }

    public void OnTryAgin()
    {
        LeanTween.scale(tryAginButton, new Vector3(1.25f, 1.25f, 1.25f), .2f);
        LeanTween.scale(tryAginButton, new Vector3(1f, 1f, 1f), .2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
