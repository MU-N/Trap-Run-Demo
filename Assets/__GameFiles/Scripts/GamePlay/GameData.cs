using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "SData/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public bool isGameStop;
    public bool isGameWin;
    public bool isGameLose;
}
