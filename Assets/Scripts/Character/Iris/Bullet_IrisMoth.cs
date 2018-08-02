using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisMoth : Bullet {

    public GameObject mothBullet;

	// Use this for initialization
	void Start () {
        bSpd = 0.5f;

        StartCoroutine(MoveIrisMoth());
        StartCoroutine(BombIrisMoth());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MoveIrisMoth()
    {
        Vector3 directionVector;

        for (int i = 0; i <= 7; i++)
        {
            directionVector = FavoriteFunction.VectorCalculator(pNum_Bullet, transform);

            transform.position += directionVector * bSpd;

            yield return new WaitForSeconds(0.1f);
        }

        directionVector = FavoriteFunction.VectorCalculator(pNum_Bullet, transform);

        bSpd = 2f;

        while (true)
        {
            transform.position += directionVector * bSpd;

            yield return null;
        }
    }

    IEnumerator BombIrisMoth()
    {
        GameObject[] mothBullet_Temp = new GameObject[6];

        yield return new WaitForSeconds(2f);

        mothBullet_Temp = FavoriteFunction.CreateBulletCircle(0.5f, 8, mothBullet, transform, pNum_Bullet);
        for (int i = 0; i < 8; i++)
        {
            mothBullet_Temp[i].GetComponent<Bullet_IrisMothBullet>().Start_MothBullet(1, i, mothBullet);
            mothBullet_Temp[i].transform.localScale *= 1.2f;

        }

        Destroy(gameObject);
    }
}
