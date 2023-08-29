using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    public float velocity = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(verticalInput > 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        } else if(verticalInput < 0){
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        } 

        if(horizontalInput > 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        } else if(horizontalInput < 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        }
    }
}
