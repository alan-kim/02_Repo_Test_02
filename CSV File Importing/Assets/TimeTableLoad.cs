using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using System;

public class TimeTableLoad : MonoBehaviour
{
    public TextAsset roomData; //read only file such as fbx model not writeable

    List<Timetable> times = new List<Timetable>();

    public GameObject recallTextObject;

    public Transform contentWindow;

    List<string> dayList = new List<string>();

    List<string> startList = new List<string>();

    List<string> endList = new List<string>();

    string currentDay = "";

    string currentTime = "";

    int currentTimeInt;

    List<int> startIntList = new List<int>();

    List<int> endIntList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        string[] data = roomData.text.Split(new char[] { '\n' }); //creating an array for every lines walk through every cahr
        //Debug.Log(data.Length);
        //Debug.Log(data);
      
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

                // read the line in ti.start
                // convert time
            }
        }
        double textGap = 0;
       foreach (Timetable ti in times)
       {
            //textGap+= recallTextObject.
            Instantiate(recallTextObject, contentWindow);
            recallTextObject.GetComponent<Text>().text = ti.Day + "," + ti.Start + "," + ti.End + "," + ti.Duration + "," + ti.Location;
            dayList.Add(ti.Day);
            startList.Add(ti.Start);
            endList.Add(ti.End);


            //////////////////////////////////////// if wanna use debug log instead of the recall text
            /*Debug.Log(ti.Day + "," + ti.Start + "," + ti.End + "," + ti.Duration + "," + ti.Location);
            Debug.Log(ti.Day);
            Debug.Log(ti.Start);
            Debug.Log(ti.End);
            */

            var s = ti.End;
            Console.WriteLine(ConvertTime(s));

            string ConvertTime(string s)
            {
                return DateTime.Parse(s).ToString("HHmm");
            }
            //Debug.Log(DateTime.Parse(s).ToString("HHmm"));
            endIntList.Add(int.Parse(DateTime.Parse(s).ToString("HHmm")));


            var u = ti.Start;
            Console.WriteLine(ConvertTime2(u));

            string ConvertTime2(string u)
            {
                return DateTime.Parse(u).ToString("HHmm");
            }
            //Debug.Log(DateTime.Parse(u).ToString("HHmm"));
            startIntList.Add(int.Parse(DateTime.Parse(u).ToString("HHmm")));
        }

        /*
        for (int i = 0; i < startList.Count; i++)
        {
            string testText = "";
            bool testBool = false;
            testText = startList[i].ToString();
            testText.Replace(":" , "");
            Debug.Log(testText);
            testBool = testText.Contains("pm");
            Debug.Log(testBool.ToString());
        }
        */

        /*
        Debug.Log(dayList);
        Debug.Log(dayList.Count.ToString());

        Debug.Log(startList);
        Debug.Log(startList.Count.ToString());

        Debug.Log(endList);
        Debug.Log(endList.Count.ToString());
        */

        currentDay = System.DateTime.Now.DayOfWeek.ToString();
        currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("HHmm");
        currentTimeInt = int.Parse(currentTime);
        //Debug.Log(currentTimeInt.ToString());
        for (int i = 0; i < dayList.Count; i++)
        {
            if (currentDay == dayList[i])
            {
                for (int j = 0; j < startIntList.Count; j++)
                {
                    if (currentTimeInt < startIntList[j] || currentTimeInt > endIntList[j])
                    {
                        Debug.Log("Free" + " " + dayList[j]);
                    }
                    else
                    {
                        Debug.Log("Occupied" + " " + dayList[j]);
                    }
                }
            }

            else
            {
                Debug.Log("Free" + " " + dayList[i]);
            }
        }
    }
    /*
    private void Update()
    {
        currentDay = System.DateTime.Now.DayOfWeek.ToString();
        currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("HHmm");
        currentTimeInt = int.Parse(currentTime);
        //Debug.Log(currentTimeInt.ToString());
        for(int i = 0; i < dayList.Count; i++)
        {
            if (currentDay == dayList[i])
            {
                for (int j = 0; j < startIntList.Count; j++)
                {
                    if (currentTimeInt < startIntList[j] || currentTimeInt > endIntList[j])
                    {
                        Debug.Log("Free");
                    }
                    else
                    {
                        Debug.Log("Occupied");
                    }
                }
            }

            else
            {
                Debug.Log("Free");
            }
        }
    }
    */
}
