using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;	

[System.Serializable]
public class Metradoex : ConstruirMain
{
    public int id;
    public int idEquipo;
    public int dima;
    public int dimb;
    public int tipo;// bool
    public double multi;
    public bool estado;

    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            form.AddField("id", id.ToString());
        form.AddField("idEquipo", idEquipo.ToString());
        form.AddField("dima", dima.ToString());
        form.AddField("dimb", dimb.ToString());
        form.AddField("tipo", tipo.ToString());
        form.AddField("multi", multi.ToString());
    }

    public override void FormFillElim(WWWForm form)
    {
        form.AddField("id", id.ToString());
    }

    public override string FormType()
    {
        return "Metradoex";
    }

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6}", id, idEquipo, dima, dimb, tipo, multi,estado);
    }
}

[System.Serializable]
public class ListaMetradoex
{
    public List<Metradoex> metradoexs;
   
    /// <summary>
    /// Asigna a la variable'datos' todos los datos de la tabla 
    /// </summary>
    /// <param name="datos"></param> variable por valor
    public void CargarMetradoex(List<Metradoex> datos)
    {
        foreach (Metradoex atributo in metradoexs)
        {
            datos.Add(atributo);
        }
    }		
}

