using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Diana : Character {

	int bullet_count;//현재 탄환 수
	float probablity;//장전 확률
	int bullet_max =6;//최대 탄환수

	bool skill1_start;//총알이 변화했는지

	GameObject skill3_bullet_parent;
	GameObject normal_bullet_Impact;

	protected Diana_skill1 diana_skill1;


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
		nomalBullet = Resources.Load("Characters/Diana/Bullet/Bullet_DianaNomal") as GameObject;
		skill3_bullet_parent = Resources.Load ("Characters/Diana/Bullet/Diana_skill3_bullet_Parent") as GameObject;


        cNum = 2;

		bullet_count = bullet_max;


		skill1_guage = 0.3f;
		skill2_guage = 0.2f;
		skill3_guage = 0.5f;
		skill4_guage = 0.6f;

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
		while (true) {
			if (bullet_count == 0)
			{
				probablity = Random.Range (0f, 100f);
				if (probablity < 70f) {
					yield return new WaitForSeconds (1.2f);
					bullet_count = bullet_max;
				}
				else {
					yield return new WaitForSeconds (0.6f);
					bullet_count = bullet_max;// 크리티컬 터짐 + 앞으로 임펙트 추가해야함


				}
			}
			else 
			{
				if (skill1_start == true)
				{
					skill1_start = false;
					Debug.Log (skill1_start);
					yield return StartCoroutine (gameObject.GetComponent<Diana_skill1>().skill1_bullet(pNum));
					bullet_count = 0;
				}
				else
				{
					FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);
					bullet_count--;
					yield return new WaitForSeconds (0.2f);
				}
			}
		}
	}

	protected override void skill1()
	{
		skill1_start = true;
	}
	protected override void skill3()
	{
		FavoriteFunction.BulletInstantiate(skill3_bullet_parent, pNum, transform);
	}
}
