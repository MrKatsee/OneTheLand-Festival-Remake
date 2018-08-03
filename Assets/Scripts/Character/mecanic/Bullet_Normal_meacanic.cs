using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Normal_meacanic : Bullet {

	// Use this for initialization
	void Start () {
		directionVector =FavoriteFunction.VectorCalculator(pNum_Bullet,transform);//총알의 방향 : 쏘는 순간의 상대의 위치로
		bSpd = 30f;
		FavoriteFunction.ObjectRotation(directionVector, gameObject);

		AutoDestroy();
	}

	// Update is called once per frame
	void Update () {
		ShootBullet ();
	}

}
