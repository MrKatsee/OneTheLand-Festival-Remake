using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Iris : Character
{
    protected Iris_Passive irisPassive;
    protected Iris_Skill2 irisSkill2;

    private void Awake()
    {
        hp = 4;
        hp_Max = hp;
        hp_Temp = hp;
        cSpd = 50f;


        if (PlayManager.Instance.p1Character == 1)
        {
            PlayManager.Instance.p1Info = GetComponent<Character_Iris>();
            pNum = 1;
        }

        if (PlayManager.Instance.p2Character == 1)
        {
            PlayManager.Instance.p2Info = GetComponent<Character_Iris>();
            pNum = 2;
        }

        cNum = 1;

        nomalBullet = Resources.Load("Characters/Iris/Bullet/Bullet_IrisNomal") as GameObject;

        irisPassive = GetComponent<Iris_Passive>();
        irisSkill2 = GetComponent<Iris_Skill2>();
    }

    // Use this for initialization

    public override void Start()
    {
        base.Start();
        uiManagement = GameObject.Find("Battle_UI").GetComponent<UIManagement>();
        UI_Setting(hp_Max, pNum, cNum);

        //irisSkill2.Start_FenFire(myPosition, pNum);
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

    protected override void InputSkillKey()
    {
        if (pNum == 1)
        {
            if (Input.GetKey(KeyCode.T))
            {
                if (skillGuage > 0.3f)
                {
                    skillGuage -= 0.3f;
                }
            }

            if (Input.GetKey(KeyCode.Y))
            {
                if (skillGuage > 0.2f)
                {
                    skillGuage -= 0.2f;
                    irisSkill2.Start_FenFire(myPosition, pNum);
                }
            }

            if (Input.GetKey(KeyCode.U))
            {
                if (skillGuage > 0.5f)
                {
                    skillGuage -= 0.5f;
                }
            }

            if (Input.GetKey(KeyCode.G))
            {
                if (skillGuage > 0.75f)
                {
                    skillGuage -= 0.75f;
                } 
            }
        }
    }

    public override IEnumerator BattleReady()
    {
        yield return StartCoroutine(base.BattleReady());

        irisPassive.PassiveStart(pNum, oppCharacter);
    }
}
