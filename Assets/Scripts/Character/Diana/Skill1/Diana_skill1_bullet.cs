using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_skill1_bullet : Bullet {
	Vector3 create_bullet_vector1;//나가는 격로 와 수직인 두 벡터
	Vector3 create_bullet_vector2;

	float reload_bullet_time=0.2f;//총알이 날라가는 간격

	GameObject created_bullet;//생성되는 총알

	void Start () {
		directionVector =FavoriteFunction.VectorCalculator(pNum_Bullet);//총알의 방향 : 쏘는 순간의 상대의 위치로
		bSpd = 0.7f;
		FavoriteFunction.ObjectRotation(directionVector, gameObject);
		created_bullet= Resources.Load("Characters/Diana/Bullet/created_bullet") as GameObject;

		create_bullet_vector1=Vector3.Cross(directionVector,new Vector3(0f,0f,1f)).normalized;
		create_bullet_vector2=Vector3.Cross(directionVector,new Vector3(0f,0f,-1f)).normalized;
		AutoDestroy();
		StartCoroutine (Create_Bullet ());
	}

	// Update is called once per frame
	void Update () {
		ShootBullet ();
	}

	public override void ShootBullet()
	{
		transform.position += directionVector * bSpd;
	}
	IEnumerator Create_Bullet()
	{
		while (true) {
			created_bullet.GetComponent<Diana_skill1_created_bullet>().directionVector = create_bullet_vector1;//방향 선정
			FavoriteFunction.BulletInstantiate (created_bullet, pNum_Bullet, transform);// 총알 생성
			created_bullet.GetComponent<Diana_skill1_created_bullet>().directionVector = create_bullet_vector2;
			FavoriteFunction.BulletInstantiate (created_bullet, pNum_Bullet, transform);
			yield return new WaitForSeconds (reload_bullet_time);//총알이 퍼질때의 간격
		}
	}
	public override void AutoDestroy()
	{
		base.AutoDestroy ();
		Invoke ("clear_coroutine",10f);
	}
	void clear_coroutine()
	{
		StopCoroutine (Create_Bullet ());
	}
}
