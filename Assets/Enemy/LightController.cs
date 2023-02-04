using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            LayerMask mask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position,Vector3.Distance(player.position,transform.position), mask);
            if (hit.collider.tag == "Player")
            {
                print("Player Detected");
            }
        }
    }
}
