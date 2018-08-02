using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris_Skill1 : MonoBehaviour {

    GameObject tigerMoth;
    GameObject tigerMothBullet;

    GameObject bulletManager;

	// Use this for initialization
	void Start () {
        tigerMoth = Resources.Load("Characters/Iris/Bullet/Iris_Moth") as GameObject;
        tigerMothBullet = Resources.Load("Characters/Iris/Bullet/Iris_MothBullet") as GameObject;

        bulletManager = GameObject.Find("BulletManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_TigerMoth(Transform myTransform, int pNum)
    {
        StartCoroutine(CreateTigerMoth(myTransform, pNum));

    }

    IEnumerator CreateTigerMoth(Transform myTransform, int pNum)
    {
        GameObject tigerMoth_Temp;

        tigerMoth_Temp = FavoriteFunction.BulletInstantiate(tigerMoth, pNum, myTransform);
        tigerMoth_Temp.GetComponent<Bullet_IrisMoth>().mothBullet = tigerMothBullet;

        yield return new WaitForSeconds(0.5f);

        tigerMoth_Temp = FavoriteFunction.BulletInstantiate(tigerMoth, pNum, myTransform);
        tigerMoth_Temp.GetComponent<Bullet_IrisMoth>().mothBullet = tigerMothBullet;

        yield return new WaitForSeconds(0.5f);

        tigerMoth_Temp = FavoriteFunction.BulletInstantiate(tigerMoth, pNum, myTransform);
        tigerMoth_Temp.GetComponent<Bullet_IrisMoth>().mothBullet = tigerMothBullet;
    }
}
