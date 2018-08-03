using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_mecanic : Character {

	GameObject android;
	private void Awake()
	{
		hp = 5;
		hp_Max = hp;
		hp_Temp = hp;
		cSpd = 50f;

		if (PlayManager.Instance.p1Character == 7)
		{
			PlayManager.Instance.p1Info = GetComponent<Character_mecanic>();
			pNum = 1;

		}

		if (PlayManager.Instance.p2Character == 7)
		{
			PlayManager.Instance.p2Info = GetComponent<Character_mecanic>();
			pNum = 2;
		}
		nomalBullet = Resources.Load("Characters/Mecanic/Bullet/Bullet_MecanicNormal") as GameObject;

		cNum = 7;

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
		android = Instantiate (Resources.Load<GameObject> ("Characters/Mecanic/Android"),transform);
		android.transform.position = new Vector3 (transform.position.x+20f*(pNum-1.5f),0f,-1f);
		UI_Setting(hp_Max, pNum, cNum);
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
	}

	protected override IEnumerator Dash(int input)
	{
		dashInput = 5;

		yield return new WaitForSeconds(0.2f);

		dashInput = 0;

		if (input == 1)
			android.transform.Translate(0f, 5f, 0f);
		if (input == 2)
			android.transform.Translate(0f, -5f, 0f);
		if (input == 3)
			android.transform.Translate(-5f, 0f, 0f);
		if (input == 4)
			android.transform.Translate(5f, 0f, 0f);
	}
}
