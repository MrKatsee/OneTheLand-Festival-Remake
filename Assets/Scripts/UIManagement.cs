﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour {

	GameObject Battle_UI;

	public GameObject[] hp_UI = new GameObject[10];  //이거 써서 HP UI 만드셈 GameObject.Find로

	public GameObject[] SkillGauge_Fill= new GameObject[2];
	public GameObject[] SkillGauge_Empty=new GameObject[2];
	public Sprite[] SkillGauge_Empty_Resources=new Sprite[7];

	void Start () {

	}

<<<<<<< HEAD
	// Update is called once per frame
	void Update () {
	}
	public void HPUISetting(int hp_Max, int pNum)
=======
    // Update is called once per frame
    void Update()
    {

    }

	public void HPUISetting(int hp_max, int pNum)
>>>>>>> 6bddd9de7856d8456031886a529dddc004bf971b
	{
		int p=((pNum-1)*5);
		hp_UI[0].SetActive (true);
		hp_UI[1].SetActive (true);
		hp_UI[2].SetActive (true);
		hp_UI[3].SetActive (true);
		hp_UI[4].SetActive (true);
		hp_UI[5].SetActive (true);
		hp_UI[6].SetActive (true);
		hp_UI[7].SetActive (true);
		hp_UI[8].SetActive (true);
		hp_UI[9].SetActive (true);
		Debug.Log (p+hp_Max-1);
		Debug.Log (p+4);
		for (int i = p + 4; i > p+hp_Max- 1; i--) {
			hp_UI [i].SetActive (false);
		}
	}

	public void SkillUISetting(int cNum, int pNum)
	{
		SkillGauge_Fill[pNum-1].GetComponent<Image> ().fillAmount = 0;
		SkillGauge_Empty [pNum-1].GetComponent<Image>().sprite=SkillGauge_Empty_Resources[cNum-1];
	}

	public void HPUIChange(int currentHP , int pNum)
	{
		int p=((pNum-1)*5);
		Destroy (hp_UI[currentHP-1+p]);
	}

	public void SkillUIChange(float currentSkillGuage, int pNum)
	{
		SkillGauge_Fill[pNum-1].GetComponent<Image> ().fillAmount = currentSkillGuage;
	}

}
