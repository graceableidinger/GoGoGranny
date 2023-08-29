using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControls : MonoBehaviour
{
    [SerializeField]
    public GameObject cat;
    public GameObject phone;
    public GameObject water;

    Quaternion cur;


    public static Vector3 position;

    // Start is called before the first frame update
    private static SpawnerControls instance;
    public static SpawnerControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SpawnerControls>();
                if (instance == null)
                {
                    GameObject test = new GameObject();
                    test.hideFlags = HideFlags.HideAndDontSave;
                    instance = test.AddComponent<SpawnerControls>();
                }
            }
            return instance;
        }
    }
    public void spawn()
    {
        int num = Random.Range(0, 9);
        if (num < 3)
        {
            if (num == 0)
            {
                position = new Vector3(-40, 1, 40);
            }
            else if (num == 1)
            {
                position = new Vector3(20, 1, 0);
            }
            else
            {
                position = new Vector3(-20, 1, -40);
            }
            cur.eulerAngles = new Vector3(-90, 0, 0);
            Instantiate(cat, position, cur);

        }
        else if (num > 6)
        {
            if (num == 3)
            {
                position = new Vector3(40, 1, -40);
            }
            else if (num == 4)
            {
                position = new Vector3(0, 1, 60);
            }
            else
            {
                position = new Vector3(0, 1, -20);
            }
            cur.eulerAngles = new Vector3(-90, 0, 0);
            Instantiate(water, position, cur);
        }
        else
        {
            if(num == 6)
            {
                position = new Vector3(-5, 1, 20);
            }
            else if (num == 7)
            {
                position = new Vector3(10, 1, -60);
            }
            else
            {
                position = new Vector3(50, 1, -20);
            }
            cur.eulerAngles = new Vector3(-90, 0, 0);
            Instantiate(phone, position, cur);
        }
    }
}
