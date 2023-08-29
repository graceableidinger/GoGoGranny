using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyLine1 : MonoBehaviour
{
    public static int lap;
    public static bool on;
    public static bool ready;
    public static string name;

    [SerializeField]
    public static GameObject lineObj;
    public static RaycastHit grannyHit;



    // Start is called before the first frame update
    void Start()
    {
        lineObj = GameObject.Find("Granny1LineCaster");
        Debug.Log(lineObj.name);
        lap = 0;
        ready = false;
    }

    // Update is called once per frame
    void Update()
    {
        line();
    }
    public static void line()
    {
        Debug.DrawRay(lineObj.transform.position, lineObj.transform.TransformDirection(Vector3.forward) * 100, Color.red);
        Vector3 finishLine = lineObj.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(lineObj.transform.position, finishLine, out grannyHit, 50))
        {
            name = grannyHit.collider.gameObject.name;
            ready = true;
            on = true;

        }
        else
        {
            on = false;
        }
        if (ready == true && on == false)
        {
            ready = false;
            if (lap < 3)
            {
                if (name == "Enemy")
                {
                    lap++;
                }
            }
            else
            {
                if (name == "Enemy")
                {
                    FinishLine.place++;
                }

            }
        }
       // Debug.Log("1=" + lap);

    }

}

