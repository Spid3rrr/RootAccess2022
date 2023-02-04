using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public string direction = "left";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction=="right"?1:-1,0) * speed;
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag=="FlipWall") {
            direction = direction=="left"?"right":"left";
            if(direction=="right") {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else { 
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

}
