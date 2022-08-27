using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenExit : MonoBehaviour
{
    public GameObject Door;
    public int keyCounter=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            Destroy(Door);
            Destroy(gameObject);
        }

    }
}
