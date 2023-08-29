using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyPos = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        float angle = Mathf.Rad2Deg * Mathf.Atan2(enemyPos.y - playerPos.y, enemyPos.x - playerPos.x);
        float alteredAngle = angle > 0 ? angle - 180 : angle + 180;
        if (alteredAngle > 90 || alteredAngle < -90)
        {
            changeDirection(false, alteredAngle + 180);
            transform.Translate(new Vector3(-2 * Time.deltaTime, 0));
        }
        else
        {
            changeDirection(true, alteredAngle);
            transform.Translate(new Vector3(2 * Time.deltaTime, 0));
        }
    }

    private void changeDirection(bool positiveDirection, float angle)
    {
        if (positiveDirection)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        } else if (!positiveDirection)
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        this.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angle);
    }
}
