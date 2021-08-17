﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] GameObject gameWonMenu;
    [SerializeField] GameObject[] gameWonMenuElemts;


    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject[] gameOverMenuElemnts;

    [SerializeField] GameObject handImage;

    [SerializeField] GameObject startTouchMenu;

    [SerializeField] TMP_Text crrentLevel;

    private int levelsCount;
    private void Start()
    {
        OnLevelSart();
        LeanTween.moveX(handImage, 100, 1).setLoopPingPong();
        levelsCount = SceneManager.sceneCountInBuildSettings;
        crrentLevel.text = "Level " + (((SceneManager.GetActiveScene().buildIndex + 1) % levelsCount) + 1).ToString("00");
    }


    public void OnGameOver()
    {

        gameOverMenu.SetActive(true);

        for (int i = 0; i < gameOverMenuElemnts.Length; i++)
        {
            LeanTween.scale(gameOverMenuElemnts[i], new Vector3(1f, 1f, 1f), .5f).setEaseOutBounce();
        }
        
        gameData.isGameLose = true;
        gameData.isGameStop = true;
        StartCoroutine(WaitForTime(2));


    }

    public void OnTryAgin()
    {

        LeanTween.scale(gameOverMenuElemnts[1], new Vector3(1.25f, 1.25f, 1.25f), .2f);
        LeanTween.scale(gameOverMenuElemnts[1], new Vector3(1f, 1f, 1f), .2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnGameWon()
    {
        gameWonMenu.SetActive(true);
        for (int i = 0; i < gameOverMenuElemnts.Length; i++)
        {
            LeanTween.scale(gameWonMenuElemts[i], new Vector3(1f, 1f, 1f), .5f).setEaseOutBounce();
        }
        
        gameData.isGameWin = true;
        gameData.isGameStop = true;
    }
    public void OnNextLvel()
    {
        SceneManager.LoadScene(((SceneManager.GetActiveScene().buildIndex + 1) % levelsCount));
    }

    public void OnLevelSart()
    {
        OnChnageTimeScale(0);
        startTouchMenu.SetActive(true);
    }

    public void OnTouchSart()
    {
        OnChnageTimeScale(1f);
        startTouchMenu.SetActive(false);
    }

    private void OnChnageTimeScale(float timeValue)
    {
        Time.timeScale = timeValue;
    }

    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0;
    }
}
