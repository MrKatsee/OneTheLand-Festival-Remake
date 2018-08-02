using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisMothBullet : Bullet {

    GameObject mothBulletOb;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_MothBullet(int bombCount, int bulletCount, GameObject mothBulletObject)
    {
        mothBulletOb = mothBulletObject;
        DirectionVectorCal(bulletCount);

        if (bombCount == 1)
        {
            bSpd = 0.85f; //
            StartCoroutine(BombMothBullet1());
        }

        else if (bombCount == 2)
        {
            bSpd = 0.25f;
            StartCoroutine(BombMothBullet2());
        }

        else if (bombCount == 3)
        {
            bSpd = 0.25f;
            StartCoroutine(BombMothBullet3());
        }

        StartCoroutine(MoveMothBullet(bombCount));

    }

    void DirectionVectorCal(int bulletCount)
    {
        directionVector = FavoriteFunction.VectorCalculationCircle(bulletCount, 8);
    }

    IEnumerator MoveMothBullet(int bombCount)
    {
        float colorManage = 1f;

        while(true)
        {
            transform.position += bSpd * directionVector;

            if (bombCount == 3)
            {
                colorManage -= 0.01f;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorManage);
            }
            yield return null;
        }
    }

    IEnumerator BombMothBullet1()
    {
        GameObject[] mothBullet_Temp = new GameObject[6];

        yield return new WaitForSeconds(1.2f); //

        //mothBullet_Temp = FavoriteFunction.CreateBulletCircle(0.1f, 6, mothBulletOb, transform, pNum_Bullet);
        //for (int i = 0; i < 6; i++)
        //{
        //   mothBullet_Temp[i].GetComponent<Bullet_IrisMothBullet>().Start_MothBullet(2, i, mothBulletOb);
        //   mothBullet_Temp[i].transform.localScale *= 1f;
        
        //}

        Destroy(gameObject);
    }

    IEnumerator BombMothBullet2()
    {
        GameObject[] mothBullet_Temp = new GameObject[4];

        yield return new WaitForSeconds(0.1f);

        //mothBullet_Temp = FavoriteFunction.CreateBulletCircle(0.1f, 4, mothBulletOb, transform, pNum_Bullet);
        //for (int i = 0; i < 4; i++)
        //{
        //    mothBullet_Temp[i].GetComponent<Bullet_IrisMothBullet>().Start_MothBullet(3, i, mothBulletOb);
        //    mothBullet_Temp[i].transform.localScale *= 0.5f;
        //}

        Destroy(gameObject);
    }

    IEnumerator BombMothBullet3()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}
