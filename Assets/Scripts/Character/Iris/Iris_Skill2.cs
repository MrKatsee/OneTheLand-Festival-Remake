using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris_Skill2 : MonoBehaviour {

    GameObject[] fenFire = new GameObject[3];
    int isFenFire = 0;

    Bullet_IrisSkill2 bulletIrisSkill2;

    GameObject bulletManager;

    private void Awake()
    {
        fenFire[0] = Resources.Load("Characters/Iris/Bullet/Iris_FenFire1") as GameObject;
        fenFire[1] = Resources.Load("Characters/Iris/Bullet/Iris_FenFire2") as GameObject;
        fenFire[2] = Resources.Load("Characters/Iris/Bullet/Iris_FenFire3") as GameObject;

        bulletManager = GameObject.Find("BulletManager");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_FenFire(Vector3 myPosition, int pNum)
    {
        GameObject fenFire_Temp;
        Vector3 createPosition;

        createPosition = myPosition;
        createPosition.x *= -1;

        fenFire_Temp = Instantiate(fenFire[isFenFire], createPosition, Quaternion.identity);
        fenFire_Temp.transform.parent = bulletManager.transform;
        fenFire_Temp.GetComponent<Bullet>().pNum_Bullet = pNum;

        bulletIrisSkill2 = fenFire_Temp.GetComponent<Bullet_IrisSkill2>();
        bulletIrisSkill2.StartMoveFenFire(pNum, isFenFire, myPosition);

        isFenFire++;
        if(isFenFire > 2)
        {
            isFenFire = 0;
        }
    }
}
