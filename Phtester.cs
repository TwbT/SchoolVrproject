using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Phtester : MonoBehaviour
{

    public string displayVar;
    public TextMeshProUGUI phDisplay; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
       
        if(collision.transform.tag == "vesel")
        {
            collision.gameObject.GetComponent<liquidProperties>().ChemicalCalculate();
            //print("passingthroughhere");
            displayVar = collision.gameObject.GetComponent<liquidProperties>().Ph.ToString();
            //print(displayVar);
            phDisplay.text = displayVar;

        }
        // does a tag check then calls a calculation function then finally displays the ph to a ui element
    }
}
