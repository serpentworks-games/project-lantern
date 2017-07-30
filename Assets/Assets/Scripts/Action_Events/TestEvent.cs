///
/// TEST SET UP FOR ACTION EVENTS
/// 
/// This script gives basic functionality to turning switches on and off, represented by a light
/// This can be used as a platform to build other switches
/// Simply duplicate script and change names and add in other functionality
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : InteractableObj {
    public Light switchLight;
   // public float newIntensity = 0;
    public bool toggleLight = true;
    public float origIntensity;

    public override void actionInteract()
    {
        
        if (toggleLight)
        {
            origIntensity = switchLight.intensity;
            switchLight.intensity = 0;
            toggleLight = false;
        }
        else if (!toggleLight)
        {
            switchLight.intensity = origIntensity;
            toggleLight = true;
            Debug.Log(origIntensity);
        }
    }
}
