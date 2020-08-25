using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Rejilla:Item
{
    // public string id; //no se utiliza por que se repite nen idItem
    public string nombre;
    public double cfm;
    public bool estado;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6}",id,idItem,idEquipo,conexion, this.nombre, this.cfm,this.estado);
    }
    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            base.FormFill(form, registrar);
        form.AddField("nombre", nombre.ToString());
        form.AddField("cfm", cfm.ToString());
    }
    public override void FormFillElim(WWWForm form)
    {
        form.AddField("id", id.ToString());
        base.FormFillElim(form);
    }
    public override string FormType()
    {
        return "Rejilla";
    }
}

[System.Serializable]
public class ListaRejilla{
    public List<Rejilla> rejillas;
        
    /// <summary>
    /// Asigna a la variable'datos' todos los datos de la tabla 
    /// </summary>
    /// <param name="datos"></param> variable por valor
    public void CargarRejilla(List<Rejilla> datos)
    {
        foreach (Rejilla atributo in rejillas)
        {
            datos.Add(atributo);
        }
    }
}

