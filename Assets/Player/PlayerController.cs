using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    public float speed = 1;
    public Animator animator;
    public bool running = false;
    public string direction = "up";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal") * speed;
        v = Input.GetAxisRaw("Vertical") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v);

        Vector3 up = new Vector3(0f, GetComponent<Rigidbody2D>().velocity.y, 0f);
        GetComponent<Rigidbody2D>().velocity = (Vector3.up * v + Vector3.right * h).normalized * speed ;
        if(GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0)) {
            running = true;
        }
        else {
            running = false;
        }
        animator.SetBool("running", running);
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0,0,45);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0,0,135);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0,0,315);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0,0,225);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0,0,270);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        else {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
            
    }
}