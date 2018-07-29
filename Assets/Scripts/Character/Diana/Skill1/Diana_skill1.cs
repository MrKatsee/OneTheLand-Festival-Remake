using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana_skill1 : MonoBehaviour {
	public GameObject skill1_Bullet;
	float continue_bullet=0.2f;//총알의 연사 간격
	// Use this for initialization
	int count;
	void Awake () {

		skill1_Bullet = Resources.Load("Characters/Diana/Bullet/skill1_bullet") as GameObject;
		count = 0;
	}

	void Update () {
		
	}
	public IEnumerator skill1_bullet(int pNum)
	{
		while(count<6)
		{
			count++;
			Debug.Log (pNum);
			FavoriteFunction.BulletInstantiate (skill1_Bullet, pNum, transform);
			yield return new WaitForSeconds (continue_bullet);
		}
		count = 0;
	}


}
