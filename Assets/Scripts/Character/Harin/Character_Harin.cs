using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Harin : Character {

    Character_HarinShip harinShip;

    GameObject harinShipObject;
    GameObject harinShipObject_Temp;

    private void Awake()
    {
        hp = 4;
        hp_Max = hp;
        hp_Temp = hp;
        cSpd = 50f;

        skill1_guage = 0.2f;
        skill2_guage = 0.1f;
        skill3_guage = 0.4f;
        skill4_guage = 0f;

        if (PlayManager.Instance.p1Character == 3)
        {
            PlayManager.Instance.p1Info = GetComponent<Character_Harin>();
            pNum = 1;
        }

        if (PlayManager.Instance.p2Character == 3)
        {
            PlayManager.Instance.p2Info = GetComponent<Character_Harin>();
            pNum = 2;
        }

        cNum = 3;

        harinShipObject = Resources.Load("Characters/Harin/Harin_Ship") as GameObject;
        harinShipObject_Temp = Instantiate(harinShipObject);

        harinShipObject_Temp.transform.position = pNum == 1 ? new Vector3(-81f, 0f, -1f) : new Vector3(81f, 0f, -1f);
        harinShipObject_Temp.transform.localScale = pNum == 1 ? new Vector3(6.5f, 6.5f, 1f) : new Vector3(-6.5f, 6.5f, 1f);

        harinShipObject_Temp.GetComponent<Character_HarinShip>().pNum = pNum;
    }

    // Use this for initialization
    public override void Start () {
        base.Start();

        uiManagement = GameObject.Find("Battle_UI").GetComponent<UIManagement>();
        UI_Setting(hp_Max, pNum, cNum);
    }

    // Update is called once per frame
    public override void Update () {
        base.Update();
	}


}
