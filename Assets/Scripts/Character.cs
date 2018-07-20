using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int pNum;
    public int cNum;

    HPManagement hpUI;

    int hp_Temp;
    public int hp;
    protected int hp_Max;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp > hp_Max)
        {
            hp = hp_Max;
        }

        if (hp_Temp != hp)
        {
            hpUI.HPUIChange(hp);
        }

        hp_Temp = hp;
	}
}
