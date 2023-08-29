using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControls : MonoBehaviour
{
    public static bool enemyComing;
    public static bool enemyGone;

    [SerializeField]
    public GameObject phone;
    public GameObject cat;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        enemyComing = false;
        enemyGone = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemyGone);
        //if (enemyComing)
        //{
        //    Debug.Log("coming");
        //    gameObject.SetActive(false);
        //}
        //else
        //{
        //    Debug.Log("gone");
        //    gameObject.SetActive(true);
        //}
    }
    IEnumerator barrier()
    {
        Debug.Log("barrier Down");
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("barrier");
        }
    }
}
