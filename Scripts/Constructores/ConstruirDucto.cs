using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Ducto:Item
{
    //public int id;// se repite en idItem de la tabla item
    public double longitud;
    public int paso;
    public int dibujar;//bool
    //public int idDucto; // se repite en id de la tabla ducto
    public int tipo;//bool
    public string nombre;
    public double dimA;
    public double dimB;
    public double flujoCFM;
    public double damAb100;
    public double damCer10;
    public double damCer50;
    public double tranRec;
    public double conVen;
    public double lumAli;
    public bool estado;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}",
        id, idItem, idEquipo, conexion,this.longitud, this.paso, this.dibujar, this.tipo, this.nombre, this.dimA, this.dimB, this.flujoCFM, this.damAb100, this.damCer10, this.damCer50, this.tranRec, this.conVen, this.lumAli, this.estado);
    }
    public override void FormFill(WWWForm form, bool registrar)
    {
        base.FormFill(form,registrar);
        form.AddField("longitud", longitud.ToString());
        form.AddField("paso", paso.ToString());
        form.AddField("dibujar", dibujar.ToString());
        //-------------
        form.AddField("tipo", tipo.ToString());
        form.AddField("nombre", nombre.ToString());
        form.AddField("dimA", dimA.ToString());
        form.AddField("dimB", dimB.ToString());
        form.AddField("flujoCFM", flujoCFM.ToString());
        form.AddField("damAb100", damAb100.ToString());
        form.AddField("damCer10", damCer10.ToString());
        form.AddField("damCer50", damCer50.ToString());
        form.AddField("tranRec", tranRec.ToString());
        form.AddField("conVen", conVen.ToString());
        form.AddField("lumAli", lumAli.ToString());
    }
    public override string FormType()
    {
        return "Ducto";
    }
}

    [System.Serializable]
    public class ListaDucto
    {
        public List<Ducto> ductos;
       
        /// <summary>
        /// Asigna a la variable'datos' todos los datos de la tabla 
        /// </summary>
        /// <param name="datos"></param> variable por valor
        public void ObtenerDucto(List<Ducto> datos)
        {
            foreach (Ducto atributo in ductos)
            {
                datos.Add(atributo);
            }
        }
    }
