using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{

    public static Game current;
    public string playerName;
    public int scoreField;

    public Game()
    {
        playerName = " 0";
        scoreField = 0;
        current = this;
    }

    public void InputVarieble(string name, int score)
    {
        playerName = name;
        scoreField = score;
        Debug.Log(current.playerName);
        Debug.Log(current.scoreField);
    }


}
