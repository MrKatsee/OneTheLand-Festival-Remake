using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisSkill2 : Bullet {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartMoveFenFire(int pNum, int fenFireNum, Vector3 myPosition)
    {
        StartCoroutine(MoveFenFire(pNum, fenFireNum, myPosition));
    }

    public IEnumerator MoveFenFire(int pNum, int fenFireNum, Vector3 myPosition)
    {
        Vector3 bulletPosition = new Vector3(0f, 0f, 0f);

        float fenFireNum1_Temp = 0f;

        while(true)
        {

            if (pNum == 1)
            {
                bulletPosition = PlayManager.Instance.p1Info.myPosition;
            }

            if (pNum == 2)
            {
                bulletPosition = PlayManager.Instance.p1Info.myPosition;
            }

            if (fenFireNum == 0)
            {
                bulletPosition.x *= -1;
            }

            if (fenFireNum == 1)
            {
                bulletPosition.y -= myPosition.y;
                fenFireNum1_Temp = myPosition.y - bulletPosition.y;

                bulletPosition.x = 2 * -myPosition.x + bulletPosition.x;
                bulletPosition.y = fenFireNum1_Temp;
            }

            if (fenFireNum == 2)
            {
                bulletPosition.y -= myPosition.y;
                fenFireNum1_Temp = myPosition.y - bulletPosition.y;

                bulletPosition.x *= -1;
                bulletPosition.y = fenFireNum1_Temp;
            }

            transform.position = bulletPosition;
            yield return null;
        }
    }
}
