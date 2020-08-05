using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuctoCanvas : MonoBehaviour
{
    public DuctoControl target;

    public InputField longitud;
    //public int paso;
    //public int dibujar;

    //public int tipo;
    public InputField nombre;
    public InputField dimA;
    public InputField dimB;
    //public InputField flujoCFM;
    public InputField damAb100;
    public InputField damCer10;
    public InputField damCer50;
    public InputField tranRec;
    public InputField conVen;
    public InputField lumAli;

    public void DecimalControl(InputField delta)
    {
        if (delta.text.Equals("") || delta.text.Equals(".") || delta.text.Equals("0."))
            delta.text = "0";
    }
    public void ChangeMain()
    {
        double c = double.Parse(longitud.text);
    }

    public void Exploit()
    {
        
    }
}
