using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class chemicalSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject chemDrop;
    Vector3 spawnVector;
    public GameObject chemical;
    public float conc;
    void Start()
    {
        //spawnVector = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spawnDrop( )
    {
        
    
        
            GameObject clone = (GameObject)Instantiate(chemDrop, transform.position, transform.rotation);
            clone.GetComponent<colliderScript>().chemicalContained = chemical;
            clone.GetComponent<colliderScript>().concentration = conc;
            Destroy(clone, 2.0f);
        
        
    }
    public void spawnStrem()
    {
        if(gameObject.GetComponentInParent<liquidProperties>().waterVolume > 0)
        {   
           
            //chemical formulas
            if (gameObject.GetComponentInParent<liquidProperties>().containedChemicals[0].GetComponent<chemicalScript>().acid >0)
            {
                double conc = Math.Pow(10, (-gameObject.GetComponentInParent<liquidProperties>().Ph));
               // print("a");
            }else if (gameObject.GetComponentInParent<liquidProperties>().containedChemicals[0].GetComponent<chemicalScript>().alkaline > 0)
            {
                double conc = Math.Pow(10, -(14-gameObject.GetComponentInParent<liquidProperties>().Ph));
                
            }
            //var mols = concent * (gameObject.GetComponentInParent<liquidProperties>().waterVolume);

            //finding the concentration of the burrette to spawn a drop from it
            float concentf = gameObject.GetComponentInParent<liquidProperties>().concBvar;
            GameObject Streamclone = (GameObject)Instantiate(chemDrop, transform.position, transform.rotation);
            GameObject chemy = gameObject.GetComponentInParent<liquidProperties>().containedChemicals[0];
            // applying some properties to the droplet
            Streamclone.GetComponent<colliderScript>().chemicalContained = chemy;
            print(concentf);
            Streamclone.GetComponent<colliderScript>().concentration = concentf;
            gameObject.GetComponentInParent<liquidProperties>().waterVolume -= 0.001;
            // decreasing the volume



        }


    }
   
}
