using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class liquidDisplay : MonoBehaviour
{
    public GameObject liqprop;
    public double watervol;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = watervol.ToString();
        text();
    }
    void text()
    {
        watervol = liqprop.gameObject.GetComponent<liquidProperties>().waterVolume;
    }
}
