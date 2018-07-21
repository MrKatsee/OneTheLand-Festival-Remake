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

        nomalBullet = Resources.Load("Characters/Diana/Bullet/Bullet_DianaNomal") as GameObject;
    }

    // Use this for initialization
    void Start()
	{
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
    void Update()
    {
<<<<<<< HEAD
		AltHP();
		AltSkillGuage ();
=======
        NomalAttack();

        AltHP();

        AltSkillGuage();

>>>>>>> 6bddd9de7856d8456031886a529dddc004bf971b
        InputKey();

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
