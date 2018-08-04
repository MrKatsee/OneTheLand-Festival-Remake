using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteFunction : MonoBehaviour {

    static GameObject bulletManager;

    void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        bulletManager = GameObject.Find("BulletManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameObject BulletInstantiate(GameObject bulletObject, int pNum, Transform myTransform)  //불렛은 플레이어 앞에 생성
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

        return bullet;
    }


    public static Vector3 VectorCalculator(int pNum, Transform myTransform)  //나와 상대 사이의 벡터를 계산
    {
        Vector3 resultVector = new Vector3 (0f, 0f, 0f);
        Vector3 myVector = myTransform.position;
        Vector3 p1Vector = PlayManager.Instance.p1Info.myPosition;
        Vector3 p2Vector = PlayManager.Instance.p2Info.myPosition;


        if (pNum == 1)
        {
            resultVector = p2Vector - myVector;
        }

        else if (pNum == 2)
        {
            resultVector = p1Vector - myVector;
        }

        resultVector.Normalize();

        return resultVector;
        
    }

    public static void ObjectRotation (Vector3 directionVector, GameObject rotatingObject)  //입력받은 벡터를 향해서 회전시킴
    {
        float rotatingAngle;


        rotatingAngle = Vector3.AngleBetween(Vector2.right, directionVector);

        rotatingAngle = directionVector.y > 0 ? rotatingAngle : -rotatingAngle;

        rotatingObject.transform.RotateAroundLocal(Vector3.forward, rotatingAngle);
    }

    public static GameObject[] CreateBulletCircle(float bulletLength, int bulletNum, GameObject bulletObject, Transform myTransform, int pNum)  //입력받은 불렛 갯수만큼 원형으로 불렛 생성
    {
        Vector3 myLocation;
        Vector3 bulletLocation = new Vector3(0f, 0f, 0f);

        float bulletAngle;

        GameObject[] bullet_Temp = new GameObject[36];

        myLocation = myTransform.position;

        for (int i = 0; i < bulletNum; i++)
        {
            bulletAngle = 6.28f * i / bulletNum;

            bulletLocation.x = Mathf.Cos(bulletAngle);
            bulletLocation.y = Mathf.Sin(bulletAngle);

            bulletLocation *= bulletLength;

            bulletLocation += myLocation;

            bulletLocation.z = -1;

            bullet_Temp[i] = Instantiate(bulletObject, bulletLocation, Quaternion.identity);
            bullet_Temp[i].transform.parent = bulletManager.transform;
            bullet_Temp[i].GetComponent<Bullet>().pNum_Bullet = pNum;

        }

        return bullet_Temp;

    }

    public static Vector3 VectorCalculationCircle(float i, float maxNum)  // i / maxNum * 6.28 계산 (maxNum만큼 개수의 점으로 이루어진 원에서 i번째 점의 벡터 계산)
    {
        Vector3 directionVector = new Vector3(0f, 0f, 0f);
        float directionAngle;

        directionAngle = 6.28f * i / maxNum;

        directionVector.x = Mathf.Cos(directionAngle);
        directionVector.y = Mathf.Sin(directionAngle);

        directionVector.Normalize();

        return directionVector;
    }

}
