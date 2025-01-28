using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Valve.VR;
using System;
using UnityEngine.SceneManagement;

public class Tracking : MonoBehaviour
{
    public Transform HMD;
    public Transform tracker;
    public TrackingStruct trackOb;
    private int sample;
    private string FileNames;
    private int c;

    public SteamVR_Action_Boolean _trigger;
    public SteamVR_Action_Boolean trackPad;

    [HideInInspector]public string rFolderPath;
    void Start()
    {
        sample = 0;

        FileNames = MovimientosControl._patientID;

        string folferPath = Directory.GetCurrentDirectory();
        Debug.Log(folferPath);

        rFolderPath = folferPath + "/Resultados_CROM";

        if (!Directory.Exists(rFolderPath))
            {
                Directory.CreateDirectory(rFolderPath);
            }

        string path = Path.Combine(@rFolderPath, "Paciente_" + FileNames + ".txt");
        string content = "Sample,Time,Device,X,Y,Z,qW,qX,qY,qZ,aX,aY,aZ";
        File.AppendAllText(path, content + Environment.NewLine);
    }
    public struct TrackingStruct
    {
        public float HMDPosX;
        public float HMDPosY;
        public float HMDPosZ;
        public float HMDQuatW;
        public float HMDQuatX;
        public float HMDQuatY;
        public float HMDQuatZ;
        public float HMDRotX;
        public float HMDRotY;
        public float HMDRotZ;
        public float trackerPosX;
        public float trackerPosY;
        public float trackerPosZ;
        public float trackerQuatW;
        public float trackerQuatX;
        public float trackerQuatY;
        public float trackerQuatZ;
        public float trackerRotX;
        public float trackerRotY;
        public float trackerRotZ;

    };

    // Update is called once per frame
    void FixedUpdate()
    {

        trackOb.HMDPosX = HMD.position.x;
        trackOb.HMDPosY = HMD.position.y;
        trackOb.HMDPosZ = HMD.position.z;
        trackOb.HMDQuatW = HMD.rotation.w;
        trackOb.HMDQuatX = HMD.rotation.x;
        trackOb.HMDQuatY = HMD.rotation.y;
        trackOb.HMDQuatZ = HMD.rotation.z;
        trackOb.HMDRotX = HMD.eulerAngles.x;
        trackOb.HMDRotY = HMD.eulerAngles.y;
        trackOb.HMDRotZ = HMD.eulerAngles.z;

        trackOb.trackerPosX = tracker.position.x;
        trackOb.trackerPosY = tracker.position.y;
        trackOb.trackerPosZ = tracker.position.z;
        trackOb.trackerQuatW = tracker.rotation.w;
        trackOb.trackerQuatX = tracker.rotation.x;
        trackOb.trackerQuatY = tracker.rotation.y;
        trackOb.trackerQuatZ = tracker.rotation.z;
        trackOb.trackerRotX = tracker.eulerAngles.x;
        trackOb.trackerRotY = tracker.eulerAngles.y;
        trackOb.trackerRotZ = tracker.eulerAngles.z;

        c = MovimientosControl._contador;

        SaveFile();
    }

    public void SaveFile()
    {
        
        if (c > 0 && c < 13)
        {
            string path = Path.Combine(@rFolderPath, "Paciente_" + FileNames + ".txt");
            string content = sample + "," + DateTime.Now.ToString("HH:mm:ss.ffff") + "," + "H" + "," + trackOb.HMDPosX + "," + trackOb.HMDPosY + "," + trackOb.HMDPosZ + "," +
                             trackOb.HMDQuatW + "," + trackOb.HMDQuatX + "," + trackOb.HMDQuatY + "," + trackOb.HMDQuatZ + "," + trackOb.HMDRotX + "," + trackOb.HMDRotY + "," + trackOb.HMDRotZ + "\n" +
                             sample + "," + DateTime.Now.ToString("HH:mm:ss.ffff") + "," + "T" + "," + trackOb.trackerPosX + "," + trackOb.trackerPosY + "," + trackOb.trackerPosZ + "," +
                             trackOb.trackerQuatW + "," + trackOb.trackerQuatX + "," + trackOb.trackerQuatY + "," + trackOb.trackerQuatZ + "," + trackOb.trackerRotX + "," + trackOb.trackerRotY + "," + trackOb.trackerRotZ;
            File.AppendAllText(path, content + Environment.NewLine);
        }

       if (MovimientosControl._unBlockTrigger == true && _trigger.stateDown )
       {
            string path = Path.Combine(@rFolderPath, "Paciente_" + FileNames + ".txt");
            string content = sample + "," + DateTime.Now.ToString("HH:mm:ss.ffff") + "," + "Trigger," + c + ",0,0,0,0,0,0,0,0,0";
            File.AppendAllText(path, content + Environment.NewLine);
       
       }

        if (MovimientosControl._contador > 12 && trackPad.stateDown)
        {
            SceneManager.LoadScene(0);
        }
            

        sample++;

    }

}
