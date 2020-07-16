using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class cargar : MonoBehaviour {


    public void EjecutarArchivoBat() 
    {
        try
        {
            Process myProcess = new Process();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe"; //Direccion del CMD
            string path = "C:\\Users\\Siddhartha\\Desktop\\comando.bat"; //Direccion del Archivo .bat 
            myProcess.StartInfo.Arguments = "/c" + path;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();
            int ExitCode = myProcess.ExitCode;
            print(ExitCode);
        }
        catch (Exception e)
        {
            print(e);
        }
    }



}
