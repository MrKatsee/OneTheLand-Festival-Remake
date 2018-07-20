﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Iris : Character {

    private void Awake()
    {
        hp = 4;
        hp_Max = hp;
        hp_Temp = hp;
        cSpd = 50f;

        if (PlayManager.Instance.p1Character == 1)
            pNum = 1;

        if (PlayManager.Instance.p2Character == 1)
            pNum = 2;

        cNum = 1;

        nomalBullet = Resources.Load("Characters/Iris/Bullet/Bullet_IrisNomalBullet") as GameObject;
    }

    // Use this for initialization

	void Start () {
		uiManagement = gameObject.GetComponent (typeof(UIManagement)) as UIManagement;
		UI_Setting (hp_Max, pNum, cNum);
    }

    // Update is called once per frame

	void Update () {
		NomalAttack();
		AltHP ();

		AltSkillGuage ();

		InputKey ();
	}
	protected override void UI_Setting(int hp_Max, int pNum, int cNum)
	{
		uiManagement.HPUISetting(hp_Max,pNum);
		uiManagement.SkillUISetting (cNum, pNum);
	}

    public override void NomalAttack()
    {
        FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);
    }

}
