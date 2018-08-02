using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_DianaNomal : Bullet {

	// Use this for initialization
	void Start () {
		directionVector =FavoriteFunction.VectorCalculator(pNum_Bullet);//총알의 방향 : 쏘는 순간의 상대의 위치로
        bSpd = 0.5f;
        FavoriteFunction.ObjectRotation(directionVector, gameObject);

        AutoDestroy();
    }
	
	// Update is called once per frame
	void Update () {
		ShootBullet ();
    }

    public override void ShootBullet()
    {
        transform.position += directionVector * bSpd;
    }


}
