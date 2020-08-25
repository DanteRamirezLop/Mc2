using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
    
[System.Serializable]
public class Multiple:Item
{
    //public int id; //no se utiliza por que se repite en idItem
    public float giroX;
    public float giroY;
    public bool estado;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6}", id, idItem, idEquipo, conexion, this.giroX, this.giroY, this.estado);
    }
    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            base.FormFill(form,registrar);
        form.AddField("giroX", giroX.ToString());
        form.AddField("giroY", giroY.ToString());
    }
    public override string FormType()
    {
        return "Multiple";
    }
}

[System.Serializable]
public class ListaMultiple
{
    public List<Multiple> multiples;
        
    /// <summary>
    /// Asigna a la variable'datos' todos los datos de la tabla 
    /// </summary>
    /// <param name="datos"></param> variable por valor
    public void CargarMultiple(List<Multiple> datos)
    {
        foreach (Multiple atributo in multiples)
        {
            datos.Add(atributo);
        }
    }
		
}
