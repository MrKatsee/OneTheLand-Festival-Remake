using System.Collections;
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

        nomalBullet = Resources.Load("Characters/Iris/Bullet/Bullet_IrisNomal") as GameObject;
    }

    // Use this for initialization

	void Start () {

		uiManagement = GameObject.Find ("Battle_UI").GetComponent<UIManagement>();
		UI_Setting();
        StartCoroutine(NomalAttack());
    }

    // Update is called once per frame

	void Update () {


		AltHP ();

		AltSkillGuage ();
		NomalAttack();
		InputKey ();

        positionCommu();

    }


    public override IEnumerator NomalAttack()
    {
        while (true)
        {
            FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);

            yield return new WaitForSeconds(1f);
        }
    }

}
