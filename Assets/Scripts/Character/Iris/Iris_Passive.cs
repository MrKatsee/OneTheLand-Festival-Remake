using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iris_Passive : MonoBehaviour {

    Character oppCharacter_Iris;
    Vector3 stackPosition;

    public int stackNum;
    int stackNum_Temp;

    GameObject[] stack = new GameObject[3];

    GameObject[] stack_Temp = new GameObject[3];

    private void Awake()
    {

        stack[0] = Resources.Load("Characters/Iris/Bullet/Iris_Stack") as GameObject;
        stack[1] = Resources.Load("Characters/Iris/Bullet/Iris_Stack") as GameObject;
        stack[2] = Resources.Load("Characters/Iris/Bullet/Iris_Stack") as GameObject;

    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
    }

    public void PassiveStart(int pNum, Character oppCharacterInfo)
    {
        Debug.Log(PlayManager.Instance.p2Info.myPosition);


        oppCharacter_Iris = oppCharacterInfo;



        stackPosition = oppCharacter_Iris.transform.position + new Vector3(-2f, -4f, -1f);

        stack_Temp[0] = Instantiate(stack[0], stackPosition, Quaternion.identity);
        stack_Temp[0].transform.parent = PlayManager.Instance.p2Info.transform;

        stackPosition += new Vector3(2f, 0f, 0f);

        stack_Temp[1] = Instantiate(stack[1], stackPosition, Quaternion.identity);
        stack_Temp[1].transform.parent = PlayManager.Instance.p2Info.transform;

        stackPosition += new Vector3(2f, 0f, 0f);

        stack_Temp[2] = Instantiate(stack[2], stackPosition, Quaternion.identity);
        stack_Temp[2].transform.parent = PlayManager.Instance.p2Info.transform;

        
        stack_Temp[0].SetActive(false);
        stack_Temp[1].SetActive(false);
        stack_Temp[2].SetActive(false);

        StartCoroutine(IrisPassiveUpdate());
    }

    IEnumerator IrisPassiveUpdate()
    {

        while(true)
        {
            yield return null;
            stackNum = oppCharacter_Iris.irisStackNum;

            if (stackNum != stackNum_Temp)
            {
                if (stackNum == 0)
                {
                    stack_Temp[0].SetActive(false);
                    stack_Temp[1].SetActive(false);
                    stack_Temp[2].SetActive(false);
                }

                if (stackNum == 1)
                {
                    stack_Temp[0].SetActive(true);
                    stack_Temp[1].SetActive(false);
                    stack_Temp[2].SetActive(false);
                }

                if (stackNum == 2)
                {
                    stack_Temp[0].SetActive(true);
                    stack_Temp[1].SetActive(true);
                    stack_Temp[2].SetActive(false);
                }

                if (stackNum == 3)
                {
                    stack_Temp[0].SetActive(true);
                    stack_Temp[1].SetActive(true);
                    stack_Temp[2].SetActive(true);
                }
            }

            stackNum_Temp = stackNum;
        }
    }
}
