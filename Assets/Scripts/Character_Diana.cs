using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Diana : Character {

    private void Awake()
    {
        hp = 5;
        hp_Max = hp;
        hp_Temp = hp;
        cSpd = 100f;

        if (PlayManager.Instance.p1Character == 2)
            pNum = 1;

        if (PlayManager.Instance.p2Character == 2)
            pNum = 2;

        cNum = 2;
    }

    // Use this for initialization
    void Start()
	{
		uiManagement = gameObject.GetComponent (typeof(UIManagement)) as UIManagement;
		UI_Setting (hp_Max, pNum, cNum);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Z)) {
			hp--;
		}
        AltHP();

        AltSkillGuage();

        InputKey();
    }
}
