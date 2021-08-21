using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class TimeTableLoad : MonoBehaviour
{
    public TextAsset roomData; //read only file such as fbx model not writeable

    List<Timetable> times = new List<Timetable>();

    public GameObject recallTextObject;

    public Transform contentWindow;

    // Start is called before the first frame update
    void Start()
    {
        string[] data = roomData.text.Split(new char[] { '\n' }); //creating an array for every lines walk through every cahr
        //Debug.Log(data.Length);
      
        for (int i = 1; i < data.Length -1; i++)
        {
           string[] row = data[i].Split(new char[] { ',' }); //creating an array for commas in there

            if (row[1] != "")
            {
                Timetable ti = new Timetable();

                ti.Day = row[0];
                ti.Start = row[1];
                ti.End = row[2];
                ti.Duration = row[3];
                ti.Location = row[4];

                times.Add(ti);
            }
        }    
       foreach (Timetable ti in times)
       {
            Instantiate(recallTextObject, contentWindow);
            recallTextObject.GetComponent<Text>().text = ti.Day + "," + ti.Start + "," + ti.End + "," + ti.Duration + "," + ti.Location;

           Debug.Log(ti.Day + "," + ti.Start + "," + ti.End + "," + ti.Duration + "," + ti.Location);
       }
    }
}
