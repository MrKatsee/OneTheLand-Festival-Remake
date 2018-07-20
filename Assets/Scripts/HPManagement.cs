using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManagement : MonoBehaviour {

    GameObject[] hp_UI = new GameObject[5];  //이거 써서 HP UI 만드셈 GameObject.Find로

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void HPUIChange (int currentHP)
    {
        //Character 스크립트 AltHP 함수에서 호출
    }
}
