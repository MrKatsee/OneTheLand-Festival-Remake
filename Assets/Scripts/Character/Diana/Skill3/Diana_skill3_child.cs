using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_skill3_child : Bullet {
	protected Vector3 start_position;//발사 시점의 위치

	protected float deltaDistance;//현재위치와 발사 시점의 위치 차

	protected GameObject skill3_bullet;

	void Start () {
		FavoriteFunction.ObjectRotation(directionVector, gameObject);
		bSpd = 0.5f;
		start_position = transform.position;
		skill3_bullet = Resources.Load ("Characters/Diana/Bullet/Diana_skill3_bullet_bomb") as GameObject;

		AutoDestroy();
	}

	// Update is called once per frame
	void Update () {
		ShootBullet ();
		deltaDistance = Vector3.Distance (start_position, transform.position);
		if (deltaDistance > 10f) {
			FavoriteFunction.BulletInstantiate(skill3_bullet, pNum_Bullet, transform);
			Destroy (gameObject);
		}
	}

	public override void ShootBullet()
	{
		transform.position += directionVector * bSpd;
	}
}
