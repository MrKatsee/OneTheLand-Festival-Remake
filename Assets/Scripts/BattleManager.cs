using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    int p1CNum, p2CNum;

    private void Awake()
    {
        p1CNum = GameManager.Instance.p1Character;
        p2CNum = GameManager.Instance.p2Character;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(GameCount());
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator GameCount()
    {
        yield return new WaitForSeconds(1f);

        GetComponent<CreateCharacter>().C_Create(p1CNum, p2CNum);
    }
}
