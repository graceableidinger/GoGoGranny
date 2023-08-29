using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public bool pickable;

    // Start is called before the first frame update
    private static PowerupScript instance;
    public static PowerupScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PowerupScript>();
                if (instance == null)
                {
                    GameObject test = new GameObject();
                    test.hideFlags = HideFlags.HideAndDontSave;
                    instance = test.AddComponent<PowerupScript>();
                }
            }
            return instance;
        }
    }
    void Start()
    {
        pickable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
