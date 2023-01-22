using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerController_v2 : MonoBehaviour
{
    float[] x = new float[30000];
    float[] z = new float[30000];
    float[] vx = new float[30000];
    float[] vz = new float[30000];

    float[] tangent = new float[30000];
    int i = 0;
    //float angle = 0f;
    float[] angle = new float[30000];
    public Transform target;
    float pangle = 90f;


    public GameObject ChickenBrown;

    // Use this for initialization
    void Start ()
    {
        ReadCSVFile();
        if (i == 10)
        {
            Application.Quit();
        }

    }
	
	// Update is called once per frame
	void ReadCSVFile ()
    {

        int j = 0;
        //StreamReader strReader = new StreamReader("D:\\Hippocampus_Project\\Hippocampus_v1\\Traj_generation\\traj2_40k.csv");

        StreamReader strReader = new StreamReader("G:\\.shortcut-targets-by-id\\1UnoIOU4TJbVR5tHyY_lCo8tRtDK2sJaf\\Sachin Deshmukh_datafolder1\\traj_wo2_20k.csv");
        bool endfile = false;
        while(!endfile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            if (data_String == null)
            {
                endfile = true;
                break;
            }
            var data_values = data_String.Split(',');
            //for (int i = 0; i < data_values.Length; i++)
            //{
            //    Debug.Log("Value:" + i.ToString() + " " + data_values[i].ToString());
            //}
            //Debug.Log(data_values[1].ToString() + " " + data_values[2].ToString() + " " + data_values[3].ToString());
            //Debug.Log(data_values[1].ToString());
            
            x[j] = float.Parse(data_values[0]);
            z[j] = float.Parse(data_values[1]);
            angle[j] = float.Parse(data_values[2]);
            //vx[j] = float.Parse(data_values[2]);
            //vz[j] = float.Parse(data_values[3]);
            //Debug.Log(x[j]);

            j = j + 1;
            //tangent = Mathf.Atan2(y[j] , x[j]);

            //x = data_values.ConvertAll(data_values.split(','),(double.Parse));
            //double[]  x = Convert.Todouble(data_values);
            
        }
        strReader.Close();
    }
    private void Update()
    {
        //float angle = Mathf.Atan2(z[i] - z[i + 1], x[i] - x[i + 1]) * Mathf.Rad2Deg;
        //angle[i] = 270 - angle[i] + 180;
        angle[i] = 90 - angle[i];
        transform.position = new Vector3(x[i], 1.0f, z[i]);
        // first method of rotation
        //float angle = Mathf.Atan2(vx[i], vz[i]) * Mathf.Rad2Deg;
        
        Debug.Log(angle);
        Debug.Log(x[i]);
        Debug.Log(z[i]);
        Debug.Log(i);

        

        transform.eulerAngles = transform.TransformDirection(0, angle[i], 0);
       
        i = i + 1;
        if (i > 20003)
        {
            enabled = false;
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }
}
