using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static int lap;
    public static int finalPlace;
    public static int place;
    public static bool on;
    public static bool ready;
    public static string name;

    [SerializeField]
    public static GameObject lineObj;
    public static RaycastHit grannyHit;



    // Start is called before the first frame update
    void Start()
    {
        lineObj = GameObject.Find("FinishLineCaster");
        Debug.Log(lineObj.name);
        lap = 0;
        ready = false;
        place = 1;
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
            name = grannyHit.collider.gameObject.tag;
            ready = true;
            on = true;
            Debug.Log("here");

        }
        else
        {
            on = false;
        }
        if (ready == true && on == false)
        {
            Debug.Log("here2");
            ready = false;
            if (lap < 3)
            {
                if (name == "Player")
                {
                    if (lap > 0)
                    {
                        AudioManager.Instance.Play(1);
                    }
                    lap++;
                    UIControls.lap++;
                    UIControls.speed1.SetActive(true);
                    PlayerNav.boost = true;
                    Debug.Log("here3");
                    SpawnerControls.Instance.spawn();
                }
            }
            else
            {
                if (name == "Player")
                {
                    finalPlace = place;
                    UIControls.Pause();
                    if (finalPlace == 1)
                    {
                        AudioManager.win = true;
                        SceneChange.SceneChanger("Win");
                    }
                    else
                    {
                        AudioManager.lose = true;
                        SceneChange.SceneChanger("Lose");
                    }
                }                
            }
        }
    }

}
