using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Ambiente : ConstruirMain
{
    public int id;
    public int idProyecto;
    public string nAmbiente;
    public double largo;
    public double ancho;
    public double altura;
    public double area;
    public double recambios;
    public double flujo;
    public double cfm;
    public string coordenada;
    public bool estado;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", id, idProyecto, nAmbiente, largo, ancho, altura, area, recambios, flujo, cfm, coordenada,estado);
    }

    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            form.AddField("id", id.ToString());
        form.AddField("idProyecto", idProyecto.ToString());
        form.AddField("nAmbiente", nAmbiente.ToString());
        form.AddField("largo", largo.ToString());
        form.AddField("ancho", ancho.ToString());
        form.AddField("altura", altura.ToString());
        form.AddField("area", area.ToString());
        form.AddField("recambios", recambios.ToString());
        form.AddField("flujo", flujo.ToString());
        form.AddField("cfm", cfm.ToString());
        form.AddField("coordenada", coordenada.ToString());
    }

    public override void FormFillElim(WWWForm form)
    {
        form.AddField("id", id.ToString());
    }

    public override string FormType()
    {
        return "Ambiente";
    }
}

[System.Serializable]
public class ListaAmbiente
{
    public List<Ambiente> ambientes;
 
    public void CargarAmbiente(List<Ambiente> datos)
    { 
        foreach (Ambiente atributo in ambientes)
        {
            datos.Add(atributo);
        }
                         
    }
}


