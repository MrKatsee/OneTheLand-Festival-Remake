﻿using System.Collections;
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

    protected void positionCommu()
    {
        if (pNum == 1)
        {
            PlayManager.Instance.p1Position = transform.position;
        }

        if (pNum == 2)
        {
            PlayManager.Instance.p2Position = transform.position;
        }
    }

    public virtual IEnumerator NomalAttack()
    {
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
}
