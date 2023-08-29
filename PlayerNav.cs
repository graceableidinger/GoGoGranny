using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNav : MonoBehaviour
{
    [SerializeField]
    public float normalSpeed = 30.0f;
    public float powerupSpeed = 50.0f;
    public static bool havePowerup;

    public static GameObject cineCam;


    public static bool disorient;

    UnityEngine.AI.NavMeshAgent rig;
    Rigidbody nav;
    Rigidbody ours;
    private float turn = 0.0f;
    public static float speed;
    public static float add = 0.5f;
    public static bool boost;
    public static float timeDown;
    //private bool offsetTest;

    string pName;
    private static Collider powerup;
    private static GameObject toAttack;

    // Start is called before the first frame update
    void Start()
    {
        cineCam = GameObject.Find("CM vcam1");
        speed = normalSpeed;
        rig = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ours = GetComponent<Rigidbody>();
        boost = true;

        havePowerup = false;
        transform.localEulerAngles = new Vector3(0, -90, 0);
        disorient = false;        
    }

    // Update is called once per frame
    void Update()
    {
        //if (offsetTest)
        //{
        //    Debug.Log("offset");
        //    powerup.gameObject.transform.position = new Vector3(0, 0, 0.2f);
        ////}
        //if (disorient)
        //{
        //    disoriented();
        //}
        //else
        //{
        //    rotation();
        //}
        //movement();
        //attack();
        ////rig.constraints = RigidbodyConstraints.FreezeRotationZ;
        //rig.constraints = RigidbodyConstraints.FreezeRotationX;
    }
    void FixedUpdate()
    {
        if (disorient)
        {
            disoriented();
        }
        else
        {
            rotation();
        }
        movement();
        attack();
    }
    private void OnTriggerEnter(Collider newCollision)
    {
        if (string.Equals(newCollision.gameObject.tag, "Powerup"))
        {
            if (newCollision.gameObject.transform.parent == null && havePowerup == false)
            {
                newCollision.gameObject.tag = "Thrown";
                AudioManager.Instance.Play(10);
                newCollision.gameObject.GetComponent<PowerupScript>().pickable = true;
                powerup = newCollision;
                havePowerup = true;
                pName = powerup.gameObject.name;
                UIControls.Powerup(pName);
                powerup.gameObject.transform.parent = gameObject.transform;
                powerup.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + -0.5f);
                //offsetTest = true;
            }
        }
        else if (string.Equals(newCollision.gameObject.tag, "EnemyThrown"))
        {
            name = newCollision.gameObject.name;
            Debug.Log(name);
            AudioManager.incoming = false;
            UIControls.incoming = false;
            Destroy(newCollision.gameObject);
            if (name.Contains("Cat"))
            {
                disorient = true;
                StartCoroutine("catanim");
            }
            else if (name.Contains("Phone"))
            {
                StartCoroutine("glassBreak");
            }
            else if (name.Contains("Water"))
            {
                Debug.Log("water!!");
                StartCoroutine("water");
            }
        }
    }
    public static void InRadius(GameObject inRadius)
    {
        toAttack = inRadius;
    }
    IEnumerator powerupLife()
    {
        yield return new WaitForSeconds(4.0f);
        if (powerup.gameObject != null)
        {
            Destroy(powerup.gameObject);
            havePowerup = false;
            UIControls.Powerup(pName);
        }
    }
    public void attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            AudioManager.Instance.Play(5);
            AudioManager.Instance.wait(11);
            if (powerup.gameObject.name.Contains("Cat"))
            {
                AudioManager.Instance.wait(14);
            }
            powerup.gameObject.transform.parent = null;
            powerup.gameObject.AddComponent<SphereCollider>();
            powerup.gameObject.AddComponent<Rigidbody>();
            powerup.gameObject.GetComponent<Rigidbody>().useGravity = false;
            nav = powerup.gameObject.GetComponent<Rigidbody>();
            nav.velocity = transform.forward * powerupSpeed;
            StartCoroutine("powerupLife");
        }
    }
    IEnumerator glassBreak()
    {
        AudioManager.Instance.Play(16);
        UIControls.glassbreak.SetActive(true);
        UIControls.whiteoverlay1.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        UIControls.whiteoverlay2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        UIControls.whiteoverlay3.SetActive(true);
        //UIControls.whiteoverlay4.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        UIControls.glassbreak.SetActive(false);
        UIControls.whiteoverlay1.SetActive(false);
        UIControls.whiteoverlay2.SetActive(false);
        UIControls.whiteoverlay3.SetActive(false);
        //UIControls.whiteoverlay4.SetActive(false);
    }
    IEnumerator water()
    {
        AudioManager.Instance.Play(12);
        AudioListener.volume = 0.5f;
        UIControls.electricity.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        UIControls.electricity.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        AudioListener.volume = 1.0f;
    }
    IEnumerator effect()
    {
        yield return new WaitForSeconds(5.0f);
        disorient = false;
    }
    IEnumerator catanim()
    {
        AudioManager.Instance.Play(6);
        AudioManager.Instance.Play(14);
        AudioManager.Instance.wait(3);
        UIControls.catscratch.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        UIControls.catscratch.SetActive(false);
    }
    private void disoriented()
    {
        StartCoroutine("effect");
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            timeDown += 0.03f;
            if (timeDown > .1)
            {
                timeDown = 1;
            }
            turn += (normalSpeed / 8.0f) * timeDown;
            //turn += (normalSpeed / 3.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            timeDown += 0.03f;
            if (timeDown > .1)
            {
                timeDown = 1;
            }
            turn -= (normalSpeed / 8.0f) * timeDown;
            //turn -= (normalSpeed / 3.0f);
        }
        transform.localEulerAngles = new Vector3(0, turn, 0);
    }
    private void rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            timeDown += 0.03f;
            if(timeDown > .1)
            {
                timeDown = 1;
            }
            turn -= (normalSpeed / 8.0f) * timeDown;
            //turn -= (normalSpeed / 3.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            timeDown += 0.03f;
            if (timeDown > .1)
            {
                timeDown = 1;
            }
            turn += (normalSpeed / 8.0f) * timeDown;
            //turn += (normalSpeed / 3.0f);
        }
        else
        {
            timeDown = 0;
            add = 0.5f;
        }
        transform.localEulerAngles = new Vector3(0, turn, 0);

    }
    IEnumerator Superboost()
    {
        AudioManager.Instance.Play(2);
        boost = false;
        UIControls.super1.SetActive(true);
        speed = 40;
        normalSpeed *= 1.75f;
        UIControls.speed1.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        UIControls.super1.SetActive(false);
        normalSpeed /= 1.75f;
        speed = normalSpeed;
        //yield return new WaitForSeconds(4.0f);
        //UIControls.speed1.SetActive(true);
        //boost = true;
    }
    private void movement()
    {
        if (Input.GetKeyDown(KeyCode.Return) && boost && UIControls.go)
        {
            StartCoroutine("Superboost");
        }
        speed = Mathf.Abs(speed);
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && UIControls.go)
        {
            rig.velocity = transform.forward * speed;
            transform.localEulerAngles = new Vector3(0, turn, 0);
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && UIControls.go)
        {
            rig.velocity = -transform.forward * speed;
            transform.localEulerAngles = new Vector3(0, turn, 0);
        }
    }

}