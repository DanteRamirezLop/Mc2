using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuctoCanvas : MonoBehaviour
{
    public DuctoControl target;
    public GameObject controlador;

    public InputField longitud;
    //public int paso;
    //public int dibujar;

    //public int tipo;
    public InputField nombre;
    public InputField dimA;
    public InputField dimB;
    public Toggle Inyeccion;
    public Toggle Extraccion;
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
        target.ducto.nombre = nombre.text;
        target.ducto.longitud = double.Parse(longitud.text);
        target.ducto.dimA = double.Parse(dimA.text);
        target.ducto.dimB = double.Parse(dimB.text);
        target.Refresh();
    }
    public void ChangeDamp()
    {
        target.ducto.damAb100 = double.Parse(damAb100.text);
        target.ducto.damCer10 = double.Parse(damCer10.text);
        target.ducto.damCer50 = double.Parse(damCer50.text);
    }
    public void ChangeExtra()
    {
        target.ducto.tranRec = double.Parse(tranRec.text);
        target.ducto.conVen = double.Parse(conVen.text);
        target.ducto.lumAli = double.Parse(lumAli.text);
    }
    public void ChangeInyExt(int ext)
    {
        target.ducto.tipo = ext;
    }
    public void Exploit()
    {
        nombre.text = target.ducto.nombre;
        longitud.text = $"{target.ducto.longitud}";
        dimA.text = $"{target.ducto.dimA}";
        dimB.text = $"{target.ducto.dimB}";
        Inyeccion.isOn = target.ducto.tipo == 0;
        Extraccion.isOn = target.ducto.tipo == 1;
        damAb100.text = $"{target.ducto.damAb100}";
        damCer10.text = $"{target.ducto.damCer10}";
        damCer50.text = $"{target.ducto.damCer50}";
        tranRec.text = $"{target.ducto.tranRec}";
        conVen.text = $"{target.ducto.conVen}";
        lumAli.text = $"{target.ducto.lumAli}";
    }
    public void Close()
    {
        if (controlador != null)
            controlador.SetActive(true);
        controlador.SendMessage("RefreshData");
        this.gameObject.SetActive(false);
    }
}
