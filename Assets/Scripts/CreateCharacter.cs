using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour {

    GameObject[] pr_Character = new GameObject[7];

    // Use this for initialization
    private void Awake()
    {
        pr_Character[0] = Resources.Load ("Characters/Iris/C_Iris") as GameObject;
        pr_Character[1] = Resources.Load("Characters/Diana/C_Diana") as GameObject;
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void C_Create(int p1CNum, int p2CNum)
    {
        GameObject p1, p2;

        p1 = Instantiate(pr_Character[p1CNum - 1], new Vector3(-50f, 0f, -1f), Quaternion.identity);

        p1.transform.localScale = new Vector3(1f, 1f, 1f);
        p2 = Instantiate(pr_Character[p2CNum - 1], new Vector3(50f, 0f, -1f), Quaternion.identity);

        p2.transform.localScale = new Vector3 (-1f, 1f, 1f);
    }
}
