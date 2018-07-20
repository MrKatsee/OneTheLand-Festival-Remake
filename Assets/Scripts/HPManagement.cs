using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManagement : Character {

    int hp_Temp;
    GameObject[] hp_UI = new GameObject[5];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hp_Temp = hp;
	}
}
