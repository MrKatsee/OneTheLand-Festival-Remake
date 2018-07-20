using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Iris : Character {

    Character myCharacter;

    private void Awake()
    {
        hp = 4;
        hp_Max = hp;
        cSpd = 100f;

        if (PlayManager.Instance.p1Character == 1)
            pNum = 1;

        if (PlayManager.Instance.p2Character == 1)
            pNum = 2;

        cNum = 1;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        AltHP();

        AltSkillGuage();

        InputKey();
    }



}
