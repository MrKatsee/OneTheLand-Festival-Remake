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

    public void StartMoveFenFire(int pNum, int fenFireNum, Vector3 myPosition, float moveLength)
    {
        StartCoroutine(AccelationFF(pNum, fenFireNum, myPosition, moveLength));
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

    public IEnumerator AccelationFF(int pNum, int fenFireNum, Vector3 myPosition, float moveLength)
    {
        float accelVelocity = 0f;
        float maxVelocity;
        float accelCount = 0f;
        float test;

        maxVelocity = 2 * moveLength / 0.25f;
        test = Time.realtimeSinceStartup;

        while (true)
        {
            if (accelVelocity >= maxVelocity)
            {

                Debug.Log(Time.realtimeSinceStartup - test);
                break;
            }

            accelVelocity = (Mathf.Lerp(0f, maxVelocity, accelCount));
            accelCount += Time.deltaTime * 5f;
            transform.position += transform.right * accelVelocity * Time.deltaTime;

            yield return null;
        }

        accelVelocity = maxVelocity;
        accelCount = 0;


        while (true)
        {

            if (accelVelocity <= 0f)
            {
                break;
            }

            accelVelocity = (Mathf.Lerp(maxVelocity, 0f, accelCount));
            accelCount += Time.deltaTime * 5.0f;
            transform.position += transform.right * accelVelocity * Time.deltaTime;

            yield return null;
        }

        StartCoroutine(MoveFenFire(pNum, fenFireNum, myPosition));
    }
}
