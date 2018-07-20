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

        nomalBullet = Resources.Load("Characters/Iris/Bullet/Bullet_IrisNomalBullet") as GameObject;
    }

    // Use this for initialization
    void Start () {
        myFunction = gameObject.GetComponent<FavoriteFunction>();
         
    }

    // Update is called once per frame
    void Update () {
        AltHP();

        AltSkillGuage();

        InputKey();

        NomalAttack();

    }

    public override void NomalAttack()
    {
        myFunction.BulletInstantiate(nomalBullet, pNum);
    }

}
