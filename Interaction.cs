using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    public float speed = 1;
    public bool canHold = true;
    public GameObject anyobject;
    public Transform guide;
    public bool Escape;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }//mause If

    
    

        if (!canHold && anyobject)
            anyobject.transform.position = guide.position;

    }
     void Start()
    {
        Escape = false;
    }

    //We can use trigger or Collision
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "WrongObject")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "Object")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "FinalKey")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "Pipe")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "Pickup")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "Key")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        if (col.gameObject.tag == "KeyLivingRoom")
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
        //final key used variable turned on if picked up escape will trigger end of game scene
        if (col.gameObject.tag == "MasterKey")
        {
            if (!anyobject) // if we don't have anything holding
                anyobject = col.gameObject;
            Escape = true;
        }
            
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Object")
        {
            if (canHold)
                anyobject = null;
        }

        if (col.gameObject.tag == "WrongObject")
        {
            if (canHold)
                anyobject = null;
        }

        if (col.gameObject.tag == "Pipe")
        {
            if (canHold)
                anyobject = null;
        }
        if (col.gameObject.tag == "Pickup")
        {
            if (canHold)
                anyobject = null;
        }
        if (col.gameObject.tag == "Key")
        {
            if (canHold)
                anyobject = null;
        }
        if (col.gameObject.tag == "FinalKey")
        {
            if (canHold)
                anyobject = null;
        }
    }

        void Pickup()
    {
        anyobject.GetComponent<Rigidbody>().isKinematic = true;
        if (!anyobject)
            return;

        //We set the object parent to our guide empty object.
        anyobject.transform.SetParent(guide);

        //Set gravity to false while holding it
        anyobject.GetComponent<Rigidbody>().useGravity = false;

        //we apply the same rotation our main object (Camera) has.
        anyobject.transform.localRotation = transform.rotation;
        //We re-position the anyobject on our guide object 
        anyobject.transform.position = guide.position;

        canHold = false;
    }

    void throw_drop()
    {

        //Set our Gravity to true again.
        anyobject.GetComponent<Rigidbody>().isKinematic = false;
        anyobject.GetComponent<Rigidbody>().useGravity = true;
        
        // we don't have anything to do with our anyobject field anymore
        anyobject = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        

        //Unparent our anyobject
        guide.GetChild(0).parent = null;
        canHold = true;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
    }
}