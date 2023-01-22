using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class ScreenshotMovie : MonoBehaviour
{
    // The folderfolder we place all screenshots inside.
    // If the  exists we will append numbers to create an empty folder.
    public string folder = "D:\\unity_data\\frames_traj(wo2)_ptrn_20k";
    public int frameRate = 100;
    public int sizeMultiplier = 1;

    private string realFolder = "";


    //code from PlayerController_v2.cs
    float[] x = new float[30000];
    //List<Vector3> pos = new List<Vector3>();
    float[] z = new float[30000];
    float[] vx = new float[30000];
    float[] vz = new float[30000];

    //float[] tangent = new float[60000];
    int i = 0;
    //float angle = 0f;
    float[] angle = new float[30000];
    public Transform target;
    float pangle = 90f;

    public GameObject ChickenBrown;
    //public GameObject 

    void Start()
    {
        
        // Set the playback framerate!
        // (real time doesn't influence time anymore)
        Time.captureFramerate = frameRate;

        // Find a folder that doesn't exist yet by appending numbers!
        realFolder = folder;
        int count = 1;
        while (System.IO.Directory.Exists(realFolder))
        {
            realFolder = folder + count;
            count++;
        }
        // Create the folder
        System.IO.Directory.CreateDirectory(realFolder);

        //code from PlayerController_v2.cs
        ReadCSVFile();
        if(i == 10)
        {
            Application.Quit();
        }
    }

    //code from PlayerController_v2.cs
    void ReadCSVFile()
    {

        int j = 0;
        //StreamReader strReader = new StreamReader("D:\\azra\\Unity files\\VR_navigation_v1\\VVR_input_m1p1_r0.5.csv");
        //StreamReader strReader = new StreamReader("C:\\UnityProjects\\VR_navigation_v1\\VVR_input_m1p1_r0.5.csv");
        //main traj with elevated objects
        StreamReader strReader = new StreamReader("G:\\.shortcut-targets-by-id\\1UnoIOU4TJbVR5tHyY_lCo8tRtDK2sJaf\\Sachin Deshmukh_datafolder1\\traj_wo2_20k.csv");
        //traj with objects on the ground
        //StreamReader strReader = new StreamReader("D:\\UnityProject\\VR_navigation_v1_shortObjects");

        bool endfile = false;
        while (!endfile)
        {
                string data_String = strReader.ReadLine();
                if (data_String == null)
                {
                    endfile = true;
                    //Application.Quit();
                    break;
                }
             var data_values = data_String.Split(',');
                x[j] = float.Parse(data_values[0]);
                z[j] = float.Parse(data_values[1]);
                angle[j] = float.Parse(data_values[2]);

            j = j + 1;
        }
        strReader.Close();



        //for (int i = 0; i < data_values.Length; i++)
        //{
        //    Debug.Log("Value:" + i.ToString() + " " + data_values[i].ToString());
        //}
        //Debug.Log(data_values[1].ToString() + " " + data_values[2].ToString() + " " + data_values[3].ToString());
        //Debug.Log(data_values[1].ToString());
        //pos.Add(new Vector3(float.Parse(data_values[0]), 0.2f, float.Parse(data_values[1])));
            //x[j] = float.Parse(data_values[0]);
            //z[j] = float.Parse(data_values[1]);
            //vx[j] = float.Parse(data_values[2]);
            //vz[j] = float.Parse(data_values[3]);
            //Debug.Log(x[j]);

            //j = j + 1;
            //tangent = Mathf.Atan2(y[j] , x[j]);

            //x = data_values.ConvertAll(data_values.split(','),(double.Parse));
            //double[]  x = Convert.Todouble(data_values);

        
        //strReader.Close();
        //Debug.Log(pos.Count);
        //Debug.Log("############################################################################");
    }
    void Update()
    {

        //var name = string.Format("{0}/shot{1}.png", realFolder, i);
        var name = string.Format("{0}/shot{1:D05}.png", realFolder, Time.frameCount);
        string s1= name;
        Debug.Log(name);
        UnityEngine.ScreenCapture.CaptureScreenshot(s1);
        //float angle = Mathf.Atan2(z[i] - z[i+1], x[i] - x[i+1]) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(pos[i + 1].z - pos[i].z, pos[i + 1].x - pos[i].x) * Mathf.Rad2Deg;

        angle[i] = 270 - angle[i] + 180;
        //angle[i] = angle[i];
        transform.position = new Vector3(x[i], 1.0f, z[i]);
        //transform.position = pos[i];
        // first method of rotation
        //float angle = Mathf.Atan2(vx[i], vz[i]) * Mathf.Rad2Deg;

        //Debug.Log(angle);
        //Debug.Log(x[i]);
        //Debug.Log(z[i]);
        Debug.Log(i);
        //Debug.Log('a');
        
        transform.eulerAngles = transform.TransformDirection(0, angle[i], 0);


        //name is "realFolder/shot 0005.png"

        //Debug.Log(pos.Count);
        // Capture the screenshot
        //Application.CaptureScreenshot(name, sizeMultiplier);
        //if (i == pos.Count)
        //{
            //Application.Quit();
           // enabled = false;
        //}
        i = i + 1;

        if (i > 20003)
        {
            enabled = false;
        }
    }
}