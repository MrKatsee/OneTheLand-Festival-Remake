using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Diana : Character {

    private void Awake()
    {
        hp = 5;
        hp_Max = hp;
        hp_Temp = hp;
        cSpd = 50f;

        if (PlayManager.Instance.p1Character == 2)
            pNum = 1;

        if (PlayManager.Instance.p2Character == 2)
            pNum = 2;

        cNum = 2;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AltHP();

        AltSkillGuage();

        InputKey();
    }
}
