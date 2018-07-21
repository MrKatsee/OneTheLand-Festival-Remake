using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_DianaNomal : Bullet {

	// Use this for initialization
	void Start () {
        directionVector = pNum_Bullet == 1 ? new Vector3(1f, 0f, 0f) : new Vector3(-1f, 0f, 0f);
        bSpd = 0.5f;
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
