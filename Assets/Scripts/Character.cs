using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int pNum;
    public int cNum;

    UIManagement uiManage;

    int hp_Temp;
    public int hp;  //대입은 Character_Iris / Character_Diana 등, 자식 클래스에서 해줌
    protected int hp_Max;

    public float skillGuage;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AltHP();

        AltSkillGuage();

        Input();
	}

    void AltHP()
    {
        if (hp > hp_Max)
        {
            hp = hp_Max;
        }

        if (hp_Temp != hp)
        {
            uiManage.HPUIChange(hp);
        }

        hp_Temp = hp;
    }

    void Input()
    {
        
    }

    void AltSkillGuage()
    {
        
    }
}
