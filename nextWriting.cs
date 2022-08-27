using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using System.IO;
using System.Linq;
public class nextWriting : MonoBehaviour
{

    public TextMeshProUGUI Title, info1, info2;
    public int SlideNum = -1;
    public List<List<string>> txtinfo = new List<List<string>>();
    public TextAsset txtfile;
    private int slide;
    // Start is called before the first frame update
    void Start()
    {
        string filepath = (AssetDatabase.GetAssetPath(txtfile));
        //string spaths = Application.persistentDataPath + "/HistofacidsText.txt";
        List<string> filelines = File.ReadAllLines(filepath).ToList();
        int count = 0;
        int scount = 0;
        foreach (string line in filelines)
        {
           
            //takes multiples of3 so it can display 3 lines
            
            {
                if (count % 3 == 0)
                {

                    SlideNum++;
                    scount = 0;
                    txtinfo.Add(new List<string>());
                    // print("scount " + SlideNum.ToString());

                }
                //print(line);
                txtinfo[SlideNum].Add(line);
                scount++;
                count++;
                
            }
      
        }

        //print(txtinfo.Count);
        List<string> testvar = txtinfo[0];
        foreach(var line in testvar)
        {
           // print(line);
        }
    }

    void endscreen()
    {
        Title.text = "end of experiment";
        info1.text = "Write out in your books what you have learnt today";
        info2.text = "back to home scren";

    }
    
    public void clicked()
    {
        if (slide+1 < txtinfo.Count)
        {
            slide++;
            Title.text = txtinfo[slide][0];
            info1.text = txtinfo[slide][1];
            info2.text = txtinfo[slide][2];
            
        }
        else {
            //gameObject.GetComponent<buttonDebug>().enabled = false;
        }
    }
    // stop when it goes too far
}
