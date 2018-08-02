using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_skill3_bullet : Bullet{
	protected Vector3 start_position;//발사 시점의 위치

	protected float deltaDistance;//현재위치와 발사 시점의 위치 차

	protected GameObject skill3_bullet;

	void Start () {
		FavoriteFunction.ObjectRotation(directionVector, gameObject);
		bSpd = 0.5f;
		start_position = transform.position;
		skill3_bullet = Resources.Load ("Characters/Diana/Bullet/Diana_skill3_bullet_Child") as GameObject;

	}

	// Update is called once per frame
	void Update () {
		ShootBullet ();
		deltaDistance = Vector3.Distance (start_position, transform.position);
		if (deltaDistance > 20f) {
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
		skill3_bullet.GetComponent<Diana_skill3_child>().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
		angle = Random.Range (20f, 60f);
		Debug.Log (angle);
		skill3_bullet.GetComponent<Diana_skill3_child> ().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
		angle = Random.Range (-60f, -20f);
		skill3_bullet.GetComponent<Diana_skill3_child> ().directionVector=new Vector3(directionVector.x*Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad),0f);
		FavoriteFunction.BulletInstantiate (skill3_bullet, pNum_Bullet, transform);
	}
}
