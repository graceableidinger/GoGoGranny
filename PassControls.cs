using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassControls : MonoBehaviour
{
    public static GameObject lineObj;
    public static RaycastHit grannyHit;
    public static GameObject barrier;

    public static RaycastHit playerHit;
    // Start is called before the first frame update
    void Start()
    {
        lineObj = GameObject.Find("Pass");
        barrier = GameObject.Find("Barrier");

    }

    // Update is called once per frame
    void Update()
    {
        line();
    }
    //IEnumerator open()
    //{
    //    Debug.Log("setting to true");
    //    barrier.SetActive(false);
    //    yield return new WaitForSeconds(0.4f);
    //    barrier.SetActive(true);
    //}
    public void line()
    {

        Debug.DrawRay(lineObj.transform.position, lineObj.transform.TransformDirection(Vector3.forward) * 100, Color.red);
        Vector3 finishLine = lineObj.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(lineObj.transform.position, finishLine, out grannyHit, 50))
        {
            Debug.Log("something hit-");
            string name = grannyHit.collider.gameObject.tag;
            if (name == "Enemy")
            {
                Debug.Log("it was an enemy");
                barrier.SetActive(false);
                grannyHit.collider.gameObject.GetComponent<EnemyDestination>().enemyComing = true;
            }
            if (name == "Player")
            {
                Debug.Log("it was a player");
                barrier.SetActive(false);
            }
            if (name == "Powerup")
            {
                Debug.Log("it was a powerup");
                barrier.SetActive(false);
            }
        }
    }
}
