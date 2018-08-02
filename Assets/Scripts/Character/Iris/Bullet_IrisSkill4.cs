using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisSkill4 : Bullet {

	// Use this for initialization
	void Start () {
        directionVector = FavoriteFunction.VectorCalculator(pNum_Bullet, transform);
        FavoriteFunction.ObjectRotation(directionVector, gameObject);

        StartCoroutine(Move_IrisSkil4Bullet());
    }
	
	// Update is called once per frame
	void Update () {
        ShootBullet();
	}

    public override void ShootBullet()
    {
        transform.position += directionVector * bSpd * Time.deltaTime;
    }

    IEnumerator Move_IrisSkil4Bullet()
    {
        bSpd = 15f;

        yield return new WaitForSeconds(1f);

        bSpd = 0f;

        yield return new WaitForSeconds(0.3f);

        bSpd = 60f;

        yield return new WaitForSeconds(10f);

        DestroyBullet();

    }
}
