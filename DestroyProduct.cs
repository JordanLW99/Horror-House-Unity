using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProduct : MonoBehaviour
{
    GameObject objToDestroy;
    bool canDestroy = false;
    public bool drawGUI;
    public float speed;
    public Texture noblood;

    void OnTriggerEnter(Collider other)
    {
        objToDestroy = gameObject;
        canDestroy = true;
        drawGUI = true;
    }

    void OnTriggerExit(Collider theCollider)
    {
        if (theCollider.tag == "MainCamera")
        {
            drawGUI = false;
        }
    }

    void OnGUI()
    {
        if (drawGUI == true)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 51, 200, 120, 22), "Press Q to eat");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && canDestroy)
        {
            /*speed = gameObject.GetComponent<Player>().speed;
            speed = 0.05f;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), noblood);*/
            Destroy(objToDestroy);
            canDestroy = false;
        }
    }
}
