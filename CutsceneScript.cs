using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    bool start;
    List<GameObject> scenes = new List<GameObject>();
    int w;
    List<GameObject> words = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        scenes.Add(GameObject.Find("01"));
        scenes.Add(GameObject.Find("02"));
        scenes.Add(GameObject.Find("03"));
        scenes.Add(GameObject.Find("04"));
        scenes.Add(GameObject.Find("05"));
        scenes.Add(GameObject.Find("06"));
        scenes.Add(GameObject.Find("07"));
        scenes.Add(GameObject.Find("08"));
        scenes.Add(GameObject.Find("2"));
        scenes.Add(GameObject.Find("3"));
        scenes.Add(GameObject.Find("4"));
        scenes.Add(GameObject.Find("5"));
        scenes.Add(GameObject.Find("6"));
        scenes.Add(GameObject.Find("7"));
        scenes.Add(GameObject.Find("8"));
        scenes.Add(GameObject.Find("9"));
        scenes.Add(GameObject.Find("10"));

        words.Add(GameObject.Find("Word1"));
        words.Add(GameObject.Find("Word2"));
        words.Add(GameObject.Find("Word3"));
        words.Add(GameObject.Find("Word4"));
        words.Add(GameObject.Find("Word5"));
        words.Add(GameObject.Find("Word6"));
        start = true;
        for (int i = 0; i < 17; i++)
        {
            scenes[i].SetActive(false);
        }
        for (int i = 0; i < 6; i++)
        {
            words[i].SetActive(false);
        }
        w = 0;
    }

    // Update is called once per frame
    IEnumerator origin()
    {
        for(int i = 0; i<8; i++)
        {
            scenes[i].SetActive(true);
            if(i == 0 || i == 2 || i == 5 || i == 6)
            {
                words[w].SetActive(true);
                w++;
            }
            yield return new WaitForSeconds(2.0f);
        }
        for (int i = 0; i < 8; i++)
        {
            scenes[i].SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            words[i].SetActive(false);
        }
        for (int i = 8; i<17; i++)
        {
            if (i == 11 || i == 16)
            {
                words[w].SetActive(true);
                w++;
            }
            scenes[i].SetActive(true);
            yield return new WaitForSeconds(2.0f);
        }
    }
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine("origin");
        }
    }
}
