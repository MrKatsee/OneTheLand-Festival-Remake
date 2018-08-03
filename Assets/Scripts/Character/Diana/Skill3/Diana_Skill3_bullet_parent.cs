using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_Skill3_bullet_parent : Bullet {
	protected Vector3 start_position;//발사 시점의 위치

	protected float deltaDistance;//현재위치와 발사 시점의 위치 차

	protected GameObject skill3_bullet;


	void Start () {
		directionVector =new Vector3(FavoriteFunction.VectorCalculator(pNum_Bullet,transform).x,0f,0f).normalized;//총알의 방향 : 직선
		bSpd = 0.5f;
		FavoriteFunction.ObjectRotation(directionVector, gameObject);
		start_position = transform.position;
		skill3_bullet = Resources.Load ("Characters/Diana/Bullet/Diana_skill3_bullet") as GameObject;
	}

	void Update () {
		ShootBullet ();
		deltaDistance = Vector3.Distance (start_position, transform.position);
		if (deltaDistance > 40f) {
			division ();
			Destroy (gameObject);
		}
	}

	public override void ShootBullet()
	{
		transform.position += directionVector * bSpd;
	}

	protected void division()
	{
		float angle;
		angle = Random.Range (-20f, 20f);
		skill3_bullet.GetComponent<Diana_skill3_bullet> ().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
		angle = Random.Range (20f, 60f);
		Debug.Log (angle);
		skill3_bullet.GetComponent<Diana_skill3_bullet> ().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
		angle = Random.Range (-60f, -20f);
		skill3_bullet.GetComponent<Diana_skill3_bullet> ().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
	}
}
