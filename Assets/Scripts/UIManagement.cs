using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour {

	GameObject Battle_UI;

	GameObject[] hp_UI = new GameObject[5];  //이거 써서 HP UI 만드셈 GameObject.Find로
	GameObject hp;

	GameObject SkillGauge_Fill;
	GameObject SkillGauge_Empty;
	GameObject SkillGauge_Fill_Resources;
	GameObject[] SkillGauge_Empty_Resources= new GameObject[7];


	private void Awake()
	{
		hp = Resources.Load ("UI/HP") as GameObject;
		SkillGauge_Fill_Resources = Resources.Load ("UI/SkillGauge_Fill") as GameObject;
		SkillGauge_Empty_Resources[0] = Resources.Load ("UI/SkillGauge_Charater") as GameObject;//캐릭터별 게이지바
		SkillGauge_Empty_Resources[1] = Resources.Load ("UI/SkillGauge_Charater") as GameObject;
		Battle_UI = GameObject.Find ("Battle_UI");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void HPUISetting(int hp_max, int pNum)
	{
		float pRotation=(1.5f-pNum)*2f;
		for (int i = 0; i < hp_max; i++) {
			SkillGauge_Fill=Instantiate(hp);
			SkillGauge_Fill.transform.SetParent(Battle_UI.GetComponent<Canvas> ().transform, false);
			SkillGauge_Fill.GetComponent<RectTransform> ().position = new Vector3 (370f+pRotation*(250f-i*40f), 370f, 0f);
			SkillGauge_Fill.transform.localScale = new Vector3(pRotation, 1f,0f);
		}
	}

	public void SkillUISetting(int cNum, int pNum)
	{
		float pRotation=(1.5f-pNum)*2f;
		SkillGauge_Empty=Instantiate(SkillGauge_Empty_Resources[cNum-1]);
		SkillGauge_Empty.transform.SetParent(Battle_UI.GetComponent<Canvas> ().transform, false);
		SkillGauge_Empty.GetComponent<RectTransform> ().position = new Vector3 (pRotation*(200f)+370f, 390f, 0f);
		SkillGauge_Empty.transform.localScale = new Vector3(pRotation, 1f,0f);
		SkillGauge_Fill=Instantiate(SkillGauge_Fill_Resources);
		SkillGauge_Fill.transform.SetParent(Battle_UI.GetComponent<Canvas> ().transform, false);
		SkillGauge_Fill.GetComponent<RectTransform> ().position = new Vector3 (-pRotation*(200f)+370f, 390f, 0f);
		SkillGauge_Fill.transform.localScale = new Vector3(pRotation, 1f,0f);
	}

    public void HPUIChange(int currentHP)
    {
		Destroy (hp_UI[currentHP--]);
    }

    public void SkillUIChange(float currentSkillGuage)
    {
        Debug.Log("2");

    }
}
