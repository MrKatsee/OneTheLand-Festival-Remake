using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_skill1_created_bullet : Bullet {

	void Start () {
		bSpd = 0.8f;
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
