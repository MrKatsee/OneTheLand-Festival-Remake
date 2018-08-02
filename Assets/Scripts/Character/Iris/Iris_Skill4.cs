using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris_Skill4 : MonoBehaviour {

    GameObject skillCutIn;
    GameObject iris_Skill4Trigger;

    // Use this for initialization
    void Start () {
        skillCutIn = Resources.Load("Characters/Iris/Iris_SkillCutIn 1") as GameObject;
        iris_Skill4Trigger = Resources.Load("Characters/Iris/Bullet/Iris_Skill4Tirigger") as GameObject;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Start_Ectasy(int pNum)
    {
        StartCoroutine(SkillCutIn(pNum));
    }


    IEnumerator SkillCutIn(int pNum)
    {
        float currentDeltaTime = 0f;
        float duration = 0.5f;

        float colorChange = 0f;
        GameObject InstanSkillC;

        InstanSkillC = Instantiate(skillCutIn) as GameObject;
        InstanSkillC.transform.position = new Vector3(-300f, 30f, -5f);
        InstanSkillC.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        while (currentDeltaTime <= duration)
        {
            if (currentDeltaTime == 0f)
            {
                Time.timeScale = 0f;
            }
            yield return 0;

            colorChange += 2 * Time.unscaledDeltaTime;
            InstanSkillC.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorChange);

            currentDeltaTime += Time.unscaledDeltaTime;
            InstanSkillC.transform.position += new Vector3(600f * Time.unscaledDeltaTime, 0, 0);
        }

        skillCutIn.transform.position = new Vector3(0, 30, -10);

        duration = 0.5f;
        currentDeltaTime = 0f;

        while (currentDeltaTime <= duration)
        {
            yield return 0;
            currentDeltaTime += Time.unscaledDeltaTime;
        }

        duration = 0.5f;
        currentDeltaTime = 0f;

        while (currentDeltaTime <= duration)
        {
            yield return 0;

            colorChange -= 2 * Time.unscaledDeltaTime;
            InstanSkillC.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorChange);

            currentDeltaTime += Time.unscaledDeltaTime;
            InstanSkillC.transform.position += new Vector3(600f * Time.unscaledDeltaTime, 0, 0);
        }

        Destroy(InstanSkillC);

        StartCoroutine(EctasyTrigger(pNum));
    }

    IEnumerator EctasyTrigger(int pNum)
    {
        GameObject ectasyTrigger_Temp;
        float duration = 1f;
        float currentDeltaTime = 0f;

        Time.timeScale = 1f;

        ectasyTrigger_Temp = Instantiate(iris_Skill4Trigger);
        ectasyTrigger_Temp.transform.position = new Vector3(-100f, 0f, -1f);
        ectasyTrigger_Temp.GetComponent<Bullet>().pNum_Bullet = pNum;

        while (currentDeltaTime <= duration)
        {
            yield return 0;

            currentDeltaTime += Time.unscaledDeltaTime;
            ectasyTrigger_Temp.transform.position += new Vector3(500f * Time.unscaledDeltaTime, 0, 0);
        }


        Destroy(ectasyTrigger_Temp);
    }
}
