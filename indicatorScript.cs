using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] double range = 8.6;
    //public Color gColor, lColor;
    public GameObject Beaker;
    public bool indicorIn = false;
    //public Material changedMaterial;
    [SerializeField] private Renderer myobj;
    void ColorchangeCheck()

    {
        if (indicorIn)
        {
            if (gameObject.GetComponent<liquidProperties>().Ph >= range)
            {

                //print("12");
                myobj.material.color = Color.blue;
            }
            else
            {
                myobj.material.color = Color.red;
                // print("34");
            }
        }
    }
    // Update is called once per frame
    void Start()
    {
         //Material mats = liquid.GetComponent<Material>();
    }
    void Update()
    {
        ColorchangeCheck();
    }
}
