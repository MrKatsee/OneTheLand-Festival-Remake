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
        {
            PlayManager.Instance.p1Info = GetComponent<Character_Diana>();
            pNum = 1;

        }

        if (PlayManager.Instance.p2Character == 2)
        {
            PlayManager.Instance.p2Info = GetComponent<Character_Diana>();
            pNum = 2;
        }

        cNum = 2;

        nomalBullet = Resources.Load("Characters/Diana/Bullet/Bullet_DianaNomal") as GameObject;
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        uiManagement = GameObject.Find ("Battle_UI").GetComponent<UIManagement>();
		UI_Setting(hp_Max, pNum, cNum);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    public override IEnumerator NomalAttack()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);

            yield return new WaitForSeconds(1f);
        }
    }

}
