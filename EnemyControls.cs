using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    Rigidbody rigid;
    string name;

    [SerializeField]
    public GameObject player;
    public GameObject lookAt;


    private static Collider item;

    // Start is called before the first frame update
    private static EnemyControls instance;
    public static EnemyControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyControls>();
                if (instance == null)
                {
                    GameObject test = new GameObject();
                    test.hideFlags = HideFlags.HideAndDontSave;
                    instance = test.AddComponent<EnemyControls>();
                }
            }
            return instance;
        }
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Character");
    }
    IEnumerator powerupLife()
    {
        yield return new WaitForSeconds(4.0f);
        if (item.gameObject != null)
        {
            Destroy(item.gameObject);
        }
    }
    IEnumerator cat()
    {
        AudioManager.Instance.wait(4);
        float turn = 30.0f;
        float originalSpeed = GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.0f;
        for (int i = 0; i < 72; i++)
        {
            transform.localEulerAngles = new Vector3(0, turn, 0);
            turn += 30.0f;
            yield return new WaitForSeconds(0.01f);
        }
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = originalSpeed;

    }
    IEnumerator phone()
    {
        AudioManager.Instance.wait(13);
        Debug.Log("inPhone");
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed /= 8.0f;
        yield return new WaitForSeconds(4.0f);
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= 8.0f;
    }
    IEnumerator water()
    {
        AudioManager.Instance.wait(12);
        float originalSpeed = GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0.0f;
        yield return new WaitForSeconds(4.0f);
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = originalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(lookAt.gameObject.transform);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (string.Equals(collision.gameObject.tag, "Thrown"))
        {
            name = collision.gameObject.name;
            UIControls.Powerup(name);
            Debug.Log(name);
            Destroy(collision.gameObject);
            PlayerNav.havePowerup = false;
            if (name.Contains("Cat"))
            {
                StartCoroutine("cat");
            }
            else if (name.Contains("Phone"))
            {
                StartCoroutine("phone");
            }
            else if (name.Contains("Water"))
            {
                StartCoroutine("water");
            }
        }
        else if (string.Equals(collision.gameObject.tag, "Powerup"))
        {
            StartCoroutine(throwit(collision));
        }

    }

    IEnumerator throwit(Collider collision)
    {
        Debug.Log("powerupCollision");
        UIControls.incoming = true;
        UIControls.attackIncoming();
        AudioManager.Instance.Play(17);
        item = collision;
        collision.gameObject.tag = "EnemyThrown";
        collision.gameObject.transform.parent = null;
        collision.gameObject.AddComponent<SphereCollider>().isTrigger = true;
        collision.gameObject.AddComponent<Rigidbody>();
        collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        rigid = collision.gameObject.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        while (collision.gameObject != null)
        {
            yield return new WaitForSeconds(0.1f);
            collision.gameObject.transform.position = Vector3.MoveTowards(collision.gameObject.transform.position, player.transform.position, 30.0f * Time.deltaTime);
        }
        Debug.Log("stopped?");
        //rigid.velocity = transform.forward * -40f;
        StartCoroutine("powerupLife");
    }
}