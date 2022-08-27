using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightFlicker : MonoBehaviour
{

    public Light light;
    public Light light2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.1) //a random chance
        {
            if (light.enabled == true && light2.enabled == true) //if the light is on...
            {
                light.enabled = false; //turn it off
                light2.enabled = false;
            }

            else
            {
                light.enabled = true; //turn it on
                light2.enabled = true;
            }
        }
    }
}
