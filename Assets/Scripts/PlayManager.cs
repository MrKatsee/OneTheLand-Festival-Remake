using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager
{
    public static PlayManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public static PlayManager Instance
    {
        get { return GetInstance(); }
    }
    public static PlayManager GetInstance()
    {
        if (instance == null)
            instance = new PlayManager();
        return instance;
    }


    PlayManager()
    {
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {

    }

    public int p1Character = 1;
    public int p2Character = 2;

    public float gameTimeScale = 1f;
    //For Test
}