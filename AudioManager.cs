using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioSource attackInc;
    public AudioSource playersource;


    //non-diegetic
    public AudioClip click;
    public AudioClip newLap;
    public AudioClip superboost;

    //voice
    public AudioClip MC;
    public AudioClip TTLadies;
    public AudioClip TTMildred;
    public AudioClip TTBethel;
    public AudioClip hiyah;
    public AudioClip argh;
    public AudioClip couponMine;
    public AudioClip chuckle;
    public AudioClip countToGo;

    //powerups
    public AudioClip pickupPowerup;
    public AudioClip throwPowerup;
    public AudioClip water;
    public AudioClip phone;
    public AudioClip cat;
    public AudioClip electricity;
    public AudioClip glass;
    public AudioClip attack;

    List<AudioClip> sounds = new List<AudioClip>();


    public AudioClip after;
    public static bool countdown = false;
    public static bool incoming = false;
    public static bool win = false;
    public static bool lose = false;
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject test = new GameObject();
                    test.hideFlags = HideFlags.HideAndDontSave;
                    instance = test.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }
    IEnumerator oneSec()
    {
        yield return new WaitForSeconds(1.5f);
        Play(sounds.IndexOf(after));
    }
    IEnumerator threeSec()
    {
        yield return new WaitForSeconds(2.5f);
        Play(sounds.IndexOf(after));
    }
    void Start()
    {
        //non-diegetic
        sounds.Add(click);//0
        sounds.Add(newLap);
        sounds.Add(superboost);

        //voice
        sounds.Add(TTMildred);//3
        sounds.Add(TTBethel);
        sounds.Add(hiyah);
        sounds.Add(argh);//6
        sounds.Add(couponMine);
        sounds.Add(chuckle);
        sounds.Add(countToGo);//9

        //powerups
        sounds.Add(pickupPowerup);
        sounds.Add(throwPowerup);
        sounds.Add(water);//12
        sounds.Add(phone);
        sounds.Add(cat);
        sounds.Add(electricity);//15
        sounds.Add(glass);
        sounds.Add(attack);
    }
    void Update()
    {
        if (incoming)
        {
            attackInc.volume = 1.0f;
        }
        else
        {
            attackInc.volume = 0.0f;
        }
    }
    public void Play(int x)
    {
        if(x == 17)
        {
            incoming = true;
        }
        source.clip = sounds[x];
        source.Play();
    }
    public void wait(int y)
    {
        after = sounds[y];
       
            StartCoroutine("oneSec");
    }
    public void waitMore(int y)
    {
        after = sounds[y];

        StartCoroutine("threeSec");
    }
    

}
