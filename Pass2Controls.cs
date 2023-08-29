using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass2Controls : MonoBehaviour
{
    public static GameObject lineObj;
    public static RaycastHit grannyHit;

    public static GameObject barrier;
    //public static GameObject barrier2;

    // Start is called before the first frame update
    void Start()
    {
        barrier = GameObject.Find("Barrier");
        //barrier2 = GameObject.Find("Barrier2");
        lineObj = GameObject.Find("Pass2");
    }

    // Update is called once per frame
    void Update()
    {
        line();
    }
    public void line()
    {
        if (EnemyDestination.interim)
        {
            barrier.SetActive(false);
        }
        else
        {
            Debug.DrawRay(lineObj.transform.position, lineObj.transform.TransformDirection(Vector3.forward) * 100, Color.red);
            Vector3 finishLine = lineObj.transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(lineObj.transform.position, finishLine, out grannyHit, 50))
            {
                string name = grannyHit.collider.gameObject.tag;
                if (name == "Enemy")
                {
                    barrier.SetActive(true);
                    //barrier2.SetActive(false);
                    Debug.Log("bruh");
                    grannyHit.collider.gameObject.GetComponent<EnemyDestination>().enemyComing = false;
                }
                if (name == "Player")
                {
                    //barrier2.SetActive(false);
                    barrier.SetActive(true);
                }
            }
        }
    }
}
