using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_HarinNomal : Bullet {

	// Use this for initialization
	void Start () {
        bSpd = 15f;
        FavoriteFunction.ObjectRotation(directionVector, gameObject);

        AutoDestroy();
	}
	
	// Update is called once per frame
	void Update () {
        ShootBullet();
	}
}
