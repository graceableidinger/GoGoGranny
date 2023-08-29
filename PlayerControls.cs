using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//OLD VERSION DONT USE
public class PlayerControls : MonoBehaviour
{
    public static bool disorient;

    Rigidbody rig;
    public static bool bounceAgain;
    private float turn = 0.0f;
    public static bool bouncing;
    public static float speed = 10.0f;

    string pName;
    private static Collider powerup;
    private static GameObject toAttack;
    public static bool throwing2;

    // Start is called before the first frame update
    void Start()
    {
        throwing2 = false;
        bouncing = false;
        disorient = false;
        rig = GetComponent<Rigidbody>();
        bounceAgain = true;
    }

    // Update is called once per frame
    void Update()
    {
        rig.constraints = RigidbodyConstraints.FreezeRotationZ;
        rig.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    private void FixedUpdate()
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
            powerup = newCollision;
            if (powerup.gameObject.transform.parent == null && throwing2 == false)
            {
                throwing2 = true;
                pName = powerup.gameObject.name;
                powerup.gameObject.transform.parent = gameObject.transform;
                //adjust offset
                //UIControls.Powerup(pName);
            }
        }
    }
    public static void InRadius(GameObject inRadius)
    {
        toAttack = inRadius;
    }
    IEnumerator throwing()
    {
        Debug.Log("throwing");
        throwing2 = false;
        while (powerup.gameObject.transform.position != toAttack.transform.position)
        {
            yield return new WaitForSeconds(0.001f);
            powerup.gameObject.transform.position = Vector3.MoveTowards(powerup.gameObject.transform.position, toAttack.transform.position, 3.0f * Time.deltaTime);
        }
    }
    public void attack()
    {
        if (Input.GetKey(KeyCode.Space)&& powerup.gameObject != null)
        {
            powerup.gameObject.transform.parent = null;
            while (powerup.gameObject.transform.position != toAttack.transform.position)
            {
                powerup.gameObject.transform.position = Vector3.MoveTowards(powerup.gameObject.transform.position, toAttack.transform.position, 3.0f * Time.deltaTime);
            }
            //StartCoroutine("throwing");
            if (powerup.gameObject.transform.position == toAttack.transform.position)
            {
                Debug.Log("hit");
                Destroy(powerup.gameObject);
            }
        }
    }
    IEnumerator effect()
    {
        yield return new WaitForSeconds(5.0f);
        disorient = false;
    }
    private void disoriented()
    {
        StartCoroutine("effect");
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            turn += (speed / 5);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            turn -= (speed / 5);
        }
        transform.localEulerAngles = new Vector3(0, turn, 0);
    }
    private void rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            turn-=(speed / 5);
        }
        else if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            turn+=(speed / 5);
        }
        transform.localEulerAngles = new Vector3(0, turn, 0);
    }
    IEnumerator bounce()
    {
       yield return new WaitForSeconds(1.0f);
       bounceAgain = true;
    }
    private void movement()
    {
        //if (bouncing && bounceAgain)
        //{
        //    bouncing = false;
        //    bounceAgain = false;
        //    speed = -speed;
        //    rig.velocity = transform.forward * speed * 0.2f;
        //    StartCoroutine("bounce");
        //}
        //else if (!bouncing && bounceAgain)
        //{
            speed = Mathf.Abs(speed);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rig.velocity = transform.forward * speed;
                transform.localEulerAngles = new Vector3(0, turn, 0);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rig.velocity = -transform.forward * speed;
                transform.localEulerAngles = new Vector3(0, turn, 0);
            }
        //}
    }

}
