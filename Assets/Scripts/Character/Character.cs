using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public UIManagement uiManagement;
    public int pNum;
    public int cNum;

    public float cSpd;
    public float skillGuageSpd = 1f;

    public int bomb = 0;

    public int hp;  //대입은 Character_Iris / Character_Diana 등, 자식 클래스에서 해줌
	protected int hp_Max;
	protected int hp_Temp;

    public float skillGuage;

    public GameObject nomalBullet;

    public Vector3 myPosition;

    protected bool dashCommand = false;
    public int dashInput = 0;

    protected Character oppCharacter;

    public int irisStackNum = 0;
    int irisStackNum_Temp;
    public float irisStackTimer = 0f;
    public float cSpd_Temp;

    public bool isSuper = false;

	protected float skill1_guage = 1f;
	protected float skill2_guage = 1f;
	protected float skill3_guage = 1f;
	protected float skill4_guage = 1f;

    void Awake()
    {
    }

    // Use this for initialization
    public virtual void Start () {
        StartCoroutine(NomalAttack());
        StartCoroutine(BattleReady());
        StartCoroutine(BombCharge());
    }

    // Update is called once per frame
    public virtual void Update () 
	{
        AltHP();

        AltSkillGuage();
        NomalAttack();
        InputKey();

        positionCommu();
        DashCommand();
        InputSkillKey();
    }



	public virtual void UI_Setting(int hp_Max, int pNum, int cNum)
	{
		uiManagement.HPUISetting (hp_Max, pNum);
		uiManagement.SkillUISetting ( cNum, pNum);
	}

	public void AltHP()
	{
		if (hp > hp_Max)
		{
			hp = hp_Max;
		}

		if (hp_Temp != hp)
		{
			uiManagement.HPUIChange(hp, pNum);
		}

		hp_Temp = hp;
	}

	public void AltSkillGuage()
	{
		if (skillGuage < 1f)
		{
            skillGuageSpd = 1f;

            if (irisStackNum == 1)
            {
                skillGuageSpd = skillGuageSpd * 0.8f;
            }

            else if (irisStackNum == 2)
            {
                skillGuageSpd = skillGuageSpd * 0.7f;
            }

            else if (irisStackNum == 3)
            {
                skillGuageSpd = skillGuageSpd * 0.6f;
            }

            skillGuage = skillGuage + Time.deltaTime * 0.2f * skillGuageSpd;
        }
		uiManagement.SkillUIChange(skillGuage, pNum);
	}
    protected void InputKey()
    {
        if (pNum == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0f, cSpd * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0f, -cSpd * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-cSpd * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(cSpd * Time.deltaTime, 0f, 0f);
            }
        }

        if (pNum == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0f, cSpd * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0f, -cSpd * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-cSpd * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(cSpd * Time.deltaTime, 0f, 0f);
			}
        }
    }

    protected virtual void InputSkillKey()
    {
        if (pNum == 1)
        {
			if (Input.GetKeyDown(KeyCode.T))
            {
                if (skillGuage > skill1_guage)
                {
					skillGuage -= skill1_guage;
					skill1 ();
                }
            }

			if (Input.GetKeyDown(KeyCode.Y))
            {
				if (skillGuage > skill2_guage)
                {
					skillGuage -= skill2_guage;
					skill2 ();
                }
            }

			if (Input.GetKeyDown(KeyCode.U))
            {
				if (skillGuage > skill3_guage)
                {
					skillGuage -= skill3_guage;
					skill3 ();
                }
            }

			if (Input.GetKeyDown(KeyCode.G))
            {
				if (skillGuage > skill4_guage)
                {
					skillGuage -= skill4_guage;
					skill4 ();
                }
            }
        }

        if (pNum == 2)
        {
			if (Input.GetKeyDown(KeyCode.M))
            {
				if (skillGuage > skill1_guage)
                {
					skillGuage -= skill1_guage;
					skill1 ();
                }
            }
			if (Input.GetKeyDown(KeyCode.Comma))
			{
				if (skillGuage > skill2_guage)
				{
					skillGuage -= skill2_guage;
					skill2 ();
				}
			}
			if (Input.GetKeyDown(KeyCode.Period))
			{
				if (skillGuage > skill3_guage)
				{
					skillGuage -= skill3_guage;
					skill3 ();
				}
			}
			if (Input.GetKeyDown(KeyCode.Slash))
			{
				if (skillGuage > skill4_guage)
				{
					skillGuage -= skill4_guage;
					skill4 ();
				}
			}
        }
    }

	protected virtual void skill1()
	{
	}

	protected virtual void skill2()
	{
	}

	protected virtual void skill3()
	{
	}

	protected virtual void skill4()
	{
	}

    protected void positionCommu()
    {
        myPosition = transform.position;

        if (pNum == 1)
        {
            PlayManager.Instance.p1Info = gameObject.GetComponent<Character>();
        }

        if (pNum == 2)
        {
            PlayManager.Instance.p2Info = gameObject.GetComponent<Character>();
        }
    }

    public virtual IEnumerator NomalAttack()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Bullet" && c.GetComponent<Bullet>().pNum_Bullet != pNum && isSuper == false)
        {
            if (oppCharacter.cNum == 1)
            {
                irisStackNum++;
                irisStackTimer = 7f;

                if (irisStackNum > 3)
                {
                    irisStackNum = 2;
                    hp -= 1;
                }

                if (c.GetComponent<Bullet>().canDestroy == true)
                {
                    c.GetComponent<Bullet>().DestroyBullet();
                }
            }
            else
            {
                hp -= 1;

                if (c.GetComponent<Bullet>().canDestroy == true)
                {
                    c.GetComponent<Bullet>().DestroyBullet();
                }
            }
        }
    }

    protected IEnumerator IrisSkillTimer()
    {
        while(true)
        {
            yield return null;

            irisStackTimer -= Time.deltaTime;

            if (irisStackTimer <= 0f && irisStackNum > 0)
            {
                irisStackTimer = 7f;
                irisStackNum -= 1;
            }
        }

    }

    private void IrisSkillDebuff()
    {
        if (irisStackNum_Temp != irisStackNum)
        {
            if (irisStackNum == 0)
            {

            }
        }
    }

    protected void DashCommand()
    {
        if (pNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) && dashCommand == true && dashInput == 1)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.W) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 1;
            }

            if (Input.GetKeyDown(KeyCode.S) && dashCommand == true && dashInput == 2)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.S) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 2;
            }

            if (Input.GetKeyDown(KeyCode.A) && dashCommand == true && dashInput == 3)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.A) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 3;
            }

            if (Input.GetKeyDown(KeyCode.D) && dashCommand == true && dashInput == 4)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.D) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 4;
            }

        }

        if (pNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && dashCommand == true && dashInput == 1)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 1;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && dashCommand == true && dashInput == 2)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 2;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && dashCommand == true && dashInput == 3)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 3;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && dashCommand == true && dashInput == 4)
            {
                StartCoroutine(Dash(dashInput));
                dashCommand = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && dashCommand == false && dashInput != 5)
            {
                StartCoroutine(DashTimer());
                dashInput = 4;
            }
        }
    }

    protected IEnumerator DashTimer()
    {
        dashCommand = true;

        yield return new WaitForSeconds(0.2f);

        dashCommand = false;
    }

    protected virtual IEnumerator Dash(int input)
    {
        Vector3 tempPosition;
        tempPosition = transform.position;

        dashInput = 5;

        if (pNum == 1)
            transform.Translate(0f, 1000f, 0f);
        if (pNum == 2)
            transform.Translate(0f, -1000f, 0f);

        yield return new WaitForSeconds(0.2f);

        transform.position = tempPosition;

        dashInput = 0;

        if (input == 1)
            transform.Translate(0f, 10f, 0f);
        if (input == 2)
            transform.Translate(0f, -10f, 0f);
        if (input == 3)
            transform.Translate(-10f, 0f, 0f);
        if (input == 4)
            transform.Translate(10f, 0f, 0f);
    }

    protected virtual IEnumerator BombCharge()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);

            bomb++;

            Debug.Log("Bomb: " + bomb);
        }
    }

    public virtual IEnumerator BattleReady()
    {
        yield return new WaitForSeconds(1f);

        if (pNum == 1)
        {
            oppCharacter = PlayManager.Instance.p2Info;
        }

        if (pNum == 2)
        {
            oppCharacter = PlayManager.Instance.p1Info;
        }

        if (oppCharacter.pNum == 1)
        {
            StartCoroutine(IrisSkillTimer());
        }

        cSpd_Temp = cSpd;
        StartCoroutine(AltCSpd());
    }

    public virtual IEnumerator AltCSpd()
    {
        while(true)
        {
            cSpd = cSpd_Temp;

            if (irisStackNum == 1)
            {
                cSpd = cSpd * 0.8f;
            }
            if (irisStackNum == 2)
            {
                cSpd = cSpd * 0.7f;
            }
            if (irisStackNum == 3)
            {
                cSpd = cSpd * 0.6f;
            }

            yield return null;
        }
    }
}
