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
}
