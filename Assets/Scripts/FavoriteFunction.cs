using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteFunction : MonoBehaviour {

    static GameObject bulletManager;

	// Use this for initialization
	void Start () {
        bulletManager = GameObject.Find("BulletManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void BulletInstantiate(GameObject bulletObject, int pNum, Transform myTransform)
    {
        GameObject bullet;
        Vector3 addPosition = new Vector3(0f, 0f, 0f);

        if (pNum == 1)
        {
            addPosition = new Vector3(5f, 0f, 0f);
        }
        else if (pNum == 2)
        {
            addPosition = new Vector3(-5f, 0f, 0f);
        }

        bullet = Instantiate(bulletObject, myTransform.position + addPosition, Quaternion.identity);
        bullet.transform.parent = bulletManager.transform;
        bullet.GetComponent<Bullet>().pNum_Bullet = pNum;
        
    }

    public void Test()
    {
        Debug.Log("testing");
    }

    public static Vector3 VectorCalculator(int pNum)
    {
        Vector3 resultVector;
        Vector3 p1Vector = PlayManager.Instance.p1Position;
        Vector3 p2Vector = PlayManager.Instance.p2Position;

        resultVector = p2Vector - p1Vector;
        resultVector.Normalize();

        if (pNum == 2)
        {
            resultVector *= -1;
        }

        return resultVector;
    }

    public static void ObjectRotation (Vector3 directionVector, GameObject rotatingObject)
    {
        float rotatingAngle;


        rotatingAngle = Vector3.AngleBetween(Vector2.right, directionVector);

        rotatingAngle = directionVector.y > 0 ? rotatingAngle : -rotatingAngle;

        rotatingObject.transform.RotateAroundLocal(Vector3.forward, rotatingAngle);
    }
}
