using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KitchenPuzzle : MonoBehaviour
{
    public int itemCounter = 0;
    public GameObject Product;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Object")
        {
            itemCounter += 1;
            Destroy(col.gameObject);
            Debug.Log("score has increased!");
        }
        if (itemCounter == 5)
        {
            Instantiate(Product, new Vector3(-6.514f, 1.905f, 4.579f), Quaternion.identity);
        }
    }
}
