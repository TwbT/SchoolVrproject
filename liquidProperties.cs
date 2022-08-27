using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class liquidProperties : MonoBehaviour
{
    
    public float volume;
    public double Ph;
    private float acidity, alkalinity;
    public  double waterAcidity = 0.0000001;
    public double waterVolume = 0.01;
    public GameObject[] Chemicals;
    List<string> chemicalnames = new List<string>();
    public ArrayList Chemicalplusproperties;
    public List<GameObject> containedChemicals;
    public float concBvar;
    //public Hashtable chemTable = new Hashtable();
    public IDictionary<string, ArrayList> chemDict = new Dictionary<string, ArrayList>();
    public GameObject waterLevels;

    // i need volume, molar mass
    // what type of chemical it is



    // chemicals have roperties of mols acidity strength alkalinity strength 
    //contained chemicals [name of acid: mols acidity strength 
    //simplifiedchemical adds properties together. eg acid will cancel with base acid will add with acid


    // Start is called before the first frame update
    void Start()
    {
        // order of the list 0 is molar mass 1 is chem name 2 is colour  3 is moles 4 is acid 5 is base
        for (int i = 0; i < Chemicals.Length; i++)
        {
            
            ChemCompile(Chemicals[i]);

        }
        ChemicalCalculate();

    }

    // Update is called once per frame
   
    void Update()
    {
        //ChemicalCalculate();
        //print(Ph);
    }

    void waterheight()
    {
        Vector3 waterPos = waterLevels.transform.position;
        //Vector3 waterh = waterLevels.transform.localScale;
        var bheight = gameObject.transform.localScale.y;
        var x = waterLevels.transform.localScale.x;
        var y = (float)(waterVolume / 0.1 * 1);
        var z = waterLevels.transform.localScale.z;
        



        Vector3 waterh = new Vector3(x , y , z );
        waterLevels.transform.localScale = waterh;
        waterLevels.transform.localPosition -= new Vector3(0, waterh.y/2,0);
        

        ///waterLevels.transform.position.y += 0.1;


    }

    public void ChemicalCalculate()
    {
        
        acidity = 0;
        alkalinity = 0; 
        foreach(string v in chemicalnames)
        {
            //print(v);
            // acidicness of slution
            string acids = (chemDict[v][4]).ToString();
            float acidf = float.Parse(acids);
            string molss = (chemDict[v][3]).ToString();
            float molsf = float.Parse(molss);
            acidity += acidf * molsf;

            //basicness of solution
            string baiscs = (chemDict[v][5]).ToString();
            float basicf = float.Parse(baiscs);

            alkalinity += basicf * molsf;


        }
       // print(acidity.ToString()+alkalinity.ToString());
        
        if (acidity > alkalinity)
        {

            double finalAcidity = acidity - alkalinity;
            double conc = (finalAcidity ) / waterVolume;

            Ph = -Math.Log10(conc);
            //chemistry formula
        }
        else if (alkalinity > acidity)
        {
            double finalBasic = (alkalinity - acidity);
            double conc = (finalBasic ) / waterVolume;
            Ph = 14 - -Math.Log10(conc);
            //chemistry formula
        }
        else if (acidity == alkalinity) { Ph = 7; }

    }
    //compiles chemicals to dictionaruy
    public void addMol(string nameOFchem, float amount)
    {
        string tempMol = chemDict[nameOFchem][3].ToString();
        float mol = float.Parse(tempMol);
        var fmol = mol + amount;
        chemDict[nameOFchem][3] = fmol;



    }
    public void ChemCompile(GameObject chemical)
    {
        GameObject tempChem = chemical;
        float tempchemMM = tempChem.GetComponent<chemicalScript>().molarmass;
        string tempchemnName = tempChem.GetComponent<chemicalScript>().chemName;
        Color tempchemColor = tempChem.GetComponent<chemicalScript>().chemColour;
        float tempisAcid = tempChem.GetComponent<chemicalScript>().acid;
        float tempisBase = tempChem.GetComponent<chemicalScript>().alkaline;


        chemicalnames.Add(tempchemnName);
        //containedChemicals.Add(chemical);
        


        // molar mass and volume and other properties
        var properties1 = new ArrayList();
        properties1.Add(tempchemMM);
        properties1.Add(tempchemnName);
        properties1.Add(tempchemColor);
        properties1.Add(0);
        properties1.Add(tempisAcid);
        properties1.Add(tempisBase);

        //connects name to propertu
        chemDict.Add(tempchemnName, properties1);
    }
}
