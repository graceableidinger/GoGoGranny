using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField]
    public GameObject Jetpack;
    public GameObject SprayBottle;
    public GameObject Food;
    public GameObject Battery;

    //GameObject powerUp;


    public static bool preRec;

    private float which;

    // Start is called before the first frame update
    void Start()
    {
        preRec = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (preRec)
        {
            spawn();
            preRec = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (string.Equals(collision.gameObject.tag, "jetpack"))
        {
            if (gameObject.activeSelf)
            {
                scoreCalc.score += 400;
                Debug.Log("jetpack");
                powerup.SetActive(false);
            }
           
        }
        else if (string.Equals(collision.gameObject.tag, "no2"))
        {
            if (gameObject.activeSelf)
            {
                scoreCalc.score += 400;
                Debug.Log("sprayBottle");
                powerup.SetActive(false);
            }
        }
        else if (string.Equals(collision.gameObject.tag, "food"))
        {
            if (gameObject.activeSelf)
            {
                scoreCalc.score += 400;
                Debug.Log("food");
                powerup.SetActive(false);
            }
        }
        else if (string.Equals(collision.gameObject.tag, "battery"))
        {
            if (gameObject.activeSelf)
            {
                scoreCalc.score += 400;
                Debug.Log("battery");
                powerup.SetActive(false);
            }
        }
    }
    public static void spawn()
    {
        which = Random.Range(0.0f, 4.0f);
        if (which <= 1.0f)
        {
            sprayBottle();
        }
        else if (which <= 2.0f)
        {
            battery();
        }
        else if (which <= 3.0f)
        {
            food();
        }
        else if (which <= 4.0f)
        {
            jetpack();
        }
        powerup.SetActive(true);
        powerup.transform.position = new Vector3(0, 0, 0);
        StartCoroutine("countdown");
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(10.0f);
        if (gameObject != null)
        {
            powerup.SetActive(false);
        }
    }
    void sprayBottle()
    {
        GameObject powerUp = Instantiate(SprayBottle);
    }
    void battery()
    {
        GameObject powerUp = Instantiate(Battery);
    }
    void food()
    {
        GameObject powerUp = Instantiate(Food);
    }
    void jetpack()
    {
        GameObject powerUp = Instantiate(Jetpack);
    }
}
