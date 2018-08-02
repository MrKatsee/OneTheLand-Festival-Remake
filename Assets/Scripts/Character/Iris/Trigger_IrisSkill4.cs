using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_IrisSkill4 : Bullet {

    GameObject ectasyBullet;
    GameObject ectasyBullet_Temp;

    GameObject bulletManager;

	// Use this for initialization
	void Start () {
        bulletManager = GameObject.Find("BulletManager");
        ectasyBullet = Resources.Load("Characters/Iris/Bullet/Bullet_IrisSkill4") as GameObject;

        //GetComponent<Rigidbody2D>().velocity = new Vector2(200f, 0f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Bullet" && c.transform.parent == bulletManager.transform)
        {
            ectasyBullet_Temp = Instantiate(ectasyBullet, c.transform.position, Quaternion.identity);
            ectasyBullet_Temp.transform.parent = bulletManager.transform;
            ectasyBullet_Temp.GetComponent<Bullet>().pNum_Bullet = pNum_Bullet;
            Destroy(c.gameObject);
        }
    }
}
