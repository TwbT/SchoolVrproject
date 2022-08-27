using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colliderScript : MonoBehaviour
{
    public GameObject chemicalContained;
    public float concentration;
    
    // the chemical


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
        //checks tags then uses public dictionary in liquid properties to then add to the mols of the chemical. you have to do a quick check of the dictionary to see if it already contains the key if not call another public function to add and compile a chemical to the beakers dictionary.
    {
        void adding()
        {
            string tempvol = collision.gameObject.GetComponent<liquidProperties>().chemDict[chemicalContained.transform.name][3].ToString();
            float AddVol = float.Parse(tempvol);
            var FinalVol = AddVol + 0.001 * concentration;
            collision.gameObject.GetComponent<liquidProperties>().chemDict[chemicalContained.transform.name][3] = FinalVol;
            collision.gameObject.GetComponent<liquidProperties>().waterVolume += 0.001;
            collision.gameObject.GetComponent<liquidProperties>().ChemicalCalculate();

        }

        if (collision.gameObject.tag == "vesel")
        {
            //print("collided");
            Destroy(gameObject);

            if (collision.gameObject.GetComponent<liquidProperties>().chemDict.ContainsKey(chemicalContained.transform.name) == false)
            {
                collision.gameObject.GetComponent<liquidProperties>().ChemCompile(chemicalContained);
                print(chemicalContained.transform.name);

            }
            adding();
        }
        else if (collision.gameObject.tag == "buret")
        {
            
            Destroy(gameObject);

            if (collision.gameObject.GetComponent<liquidProperties>().chemDict.Count == 0 )
            {
                collision.gameObject.GetComponent<liquidProperties>().ChemCompile(chemicalContained);
                adding();
                collision.gameObject.GetComponent<liquidProperties>().containedChemicals.Add(chemicalContained);
                collision.gameObject.GetComponent<liquidProperties>().concBvar =concentration;



            }

            else if (collision.gameObject.GetComponent<liquidProperties>().chemDict.ContainsKey(chemicalContained.transform.name) & collision.gameObject.GetComponent<liquidProperties>().chemDict.Count == 1)
            {
                adding();
               // print(2);
            }
            else
            {
                print("too mny cems");
                //print(3);
            }


        }








        }
    }
    

