using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public UIManagement uiManagement;
    public int pNum;
    public int cNum;

    public float cSpd;

    public int hp;  //대입은 Character_Iris / Character_Diana 등, 자식 클래스에서 해줌
	protected int hp_Max;
	protected int hp_Temp;

    public float skillGuage;

    public GameObject nomalBullet;

    public Vector3 myPosition;

    protected bool dashCommand = false;
    public int dashInput = 0;

    void Awake()
    {
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () 
	{

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
			skillGuage = skillGuage+Time.deltaTime * 0.2f;
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
			if (Input.GetKey(KeyCode.R))//예시 키 복사하거나 키 수정
			{
				if(skillGuage>0.4f)
					skillGuage -= 0.4f;
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
			if (Input.GetKey(KeyCode.Slash))
			{
				if(skillGuage>0.4f)
					skillGuage -= 0.4f;
			}
        }
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
        if (c.tag == "Bullet" && c.GetComponent<Bullet>().pNum_Bullet != pNum)
        {
            hp -= 1;

            if (c.GetComponent<Bullet>().canDestroy == true)
            {
                c.GetComponent<Bullet>().DestroyBullet();
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
}
