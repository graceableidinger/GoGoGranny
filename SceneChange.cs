using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{


    void Update()
    {

    }

    public static void SceneChanger(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }
    
}