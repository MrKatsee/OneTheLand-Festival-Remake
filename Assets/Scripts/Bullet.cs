using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int pNum_Bullet;
    public bool canDestroy = true;
    public float bSpd;
    public Vector3 directionVector;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public virtual void ShootBullet()
    {
        transform.position += directionVector * bSpd;
    }
}
