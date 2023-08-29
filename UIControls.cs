using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static GameObject Count;

    public static GameObject cat1;
    public static GameObject phone1;
    public static GameObject speed1;
    public static GameObject water1;
    public static GameObject countdown1;
    public static GameObject super1;
    public static GameObject warn;
    public static GameObject catscratch;
    public static GameObject electricity;
    public static GameObject glassbreak;
    public static GameObject whiteoverlay1;
    public static GameObject whiteoverlay2;
    public static GameObject whiteoverlay3;
    public static GameObject whiteoverlay4;

    public static bool go;
    public static bool incoming;
    public static bool powerupIcon;
    public static bool next;

    public static int lap;
    public Text Lap_UIText;

    void Start()
    {
        
        lap = 0;
        cat1 = GameObject.Find("CatIcon");
        warn = GameObject.Find("WarningIcon");
        phone1 = GameObject.Find("PhoneIcon");
        speed1 = GameObject.Find("SpeedIcon");
        water1 = GameObject.Find("WaterIcon");
        countdown1 = GameObject.Find("CountIcon");
        super1 = GameObject.Find("Superboost");
        catscratch = GameObject.Find("Cat Scratch");
        electricity = GameObject.Find("Electricity");
        glassbreak = GameObject.Find("Glass Break");
        whiteoverlay1 = GameObject.Find("White Overlay 1");
        whiteoverlay2 = GameObject.Find("White Overlay 2");
        whiteoverlay3 = GameObject.Find("White Overlay 3");
        whiteoverlay4 = GameObject.Find("White Overlay 4");
        warn.SetActive(false);
        cat1.SetActive(false);
        phone1.SetActive(false);
        water1.SetActive(false);
        super1.SetActive(false);
        catscratch.SetActive(false);
        electricity.SetActive(false);
        glassbreak.SetActive(false);
        whiteoverlay1.SetActive(false);
        whiteoverlay2.SetActive(false);
        whiteoverlay3.SetActive(false);
        whiteoverlay4.SetActive(false);
        StartCoroutine("countdown");
        go = false;
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(0.3f);
        AudioManager.Instance.Play(9);
        yield return new WaitForSeconds(3.7f);
        go = true;
        countdown1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            StartCoroutine("warning");
            next = false;
        }
        string score2 = lap.ToString();
        Lap_UIText.text = "Lap:" + score2;
    }

    public static void Pause()
    {
        Debug.Log("pause");
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }
    public static void Powerup(string Name)
    {
        Debug.Log(Name);
        powerupIcon = !powerupIcon;
        if (Name.Contains("Cat"))
        {
            cat1.SetActive(powerupIcon);
        }
        else if (Name.Contains("Water"))
        {
            water1.SetActive(powerupIcon);
        }
        else if (Name.Contains("Phone"))
        {
            phone1.SetActive(powerupIcon);
        }
    }
    IEnumerator warning()
    {
        Debug.Log("INC");
        while (incoming)
        {
            warn.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            warn.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    public static void attackIncoming()
    {
        next = true;
    }

}
