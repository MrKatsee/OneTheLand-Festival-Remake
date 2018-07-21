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

    void Awake()
    {
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

    }
	public void UI_Setting()
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

    public virtual void NomalAttack()
    {
        FavoriteFunction.BulletInstantiate(nomalBullet, pNum, transform);
    }
}
