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
<<<<<<< HEAD
		uiManagement = GameObject.Find ("Battle_UI").GetComponent<UIManagement>();
		UI_Setting();
=======
		uiManagement = gameObject.GetComponent (typeof(UIManagement)) as UIManagement;
		UI_Setting (hp_Max, pNum, cNum);

        StartCoroutine(NomalAttack());
>>>>>>> 6bddd9de7856d8456031886a529dddc004bf971b
    }

    // Update is called once per frame

	void Update () {
<<<<<<< HEAD
		AltHP();
=======
		NomalAttack();

		AltHP ();

>>>>>>> 6bddd9de7856d8456031886a529dddc004bf971b
		AltSkillGuage ();
		NomalAttack();
		InputKey ();
<<<<<<< HEAD
=======

        positionCommu();

    }
	protected override void UI_Setting(int hp_Max, int pNum, int cNum)
	{
		uiManagement.HPUISetting(hp_Max,pNum);
		uiManagement.SkillUISetting (cNum, pNum);
>>>>>>> 6bddd9de7856d8456031886a529dddc004bf971b
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
