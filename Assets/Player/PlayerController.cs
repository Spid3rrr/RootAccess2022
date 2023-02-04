using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal") * speed;
        v = Input.GetAxisRaw("Vertical") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v);
        // Debug.Log(h);
        // Debug.Log(v);
    }
}