using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_HarinShip : Character {

    GameObject harinLocation;
    GameObject harinLocation_Temp;

    GameObject bulletManager;

    Vector3 directionVector = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        nomalBullet = Resources.Load("Characters/Harin/Bullet/Bullet_HarinNomal") as GameObject;
        harinLocation = Resources.Load("Characters/Harin/Location_HarinShip") as GameObject;

        bulletManager = GameObject.Find("BulletManager");
    }

    // Use this for initialization
    public override void Start () {
        harinLocation_Temp = Instantiate(harinLocation);

        StartCoroutine(MoveLocation());
        StartCoroutine(NomalAttack());
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

    IEnumerator MoveLocation()
    {
        float i;

        while (true)
        {
            harinLocation_Temp.transform.position = new Vector3(pNum == 1 ? -81f : 81f, i = Random.Range(-45f, 45f), -1f);

            if (i > 30f)
            {
                directionVector = new Vector3(pNum == 1 ? 1f : -1f, Random.Range(-1f, 0f), 0f);
            }

            else if (i < -30f)
            {
                directionVector = new Vector3(pNum == 1 ? 1f : -1f, Random.Range(0f, 1f), 0f);
            }

            else
            {
                directionVector = new Vector3(pNum == 1 ? 1f : -1f, Random.Range(-1f, 1f), 0f);
            }

            yield return null;
        } 
    }

    public override IEnumerator NomalAttack()
    {
        GameObject nomalBullet_Temp;

        while(true)
        {
            nomalBullet_Temp = Instantiate(nomalBullet, harinLocation_Temp.transform.position, Quaternion.identity);
            nomalBullet_Temp.GetComponent<Bullet_HarinNomal>().directionVector = directionVector;
            nomalBullet_Temp.GetComponent<Bullet>().pNum_Bullet = pNum;
            nomalBullet_Temp.transform.parent = bulletManager.transform;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
