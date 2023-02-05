using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Transform player;
    public GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("Player Collided");
            LayerMask mask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position,Vector3.Distance(player.position,transform.position), mask);
            if (hit.collider.tag == "Player")
            {
                print("Player Detected");
                gc.LostGame();
            }
        }
    }
}
