using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class handPrescence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
            
        }
        //print("hello");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
