using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_IrisNomal : Bullet {

	// Use this for initialization
	void Start () {
        directionVector = FavoriteFunction.VectorCalculator(pNum_Bullet);
        bSpd = 1f;
        FavoriteFunction.ObjectRotation(directionVector, gameObject);

    }

    // Update is called once per frame
    void Update () {
        ShootBullet();

    }

    public override void ShootBullet()
    {
        transform.position += directionVector * bSpd;
    }
}
