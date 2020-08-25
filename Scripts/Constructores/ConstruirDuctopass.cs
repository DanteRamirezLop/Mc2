using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Ductopass : ConstruirMain
{
    public int idDucto;
    public float ccx;
    public float ccy;
    public float ccz;
    public int paso;
    public int dibujar;// boll
    public bool estado;

    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            form.AddField("idDucto", idDucto.ToString());
        form.AddField("ccx", ccx.ToString());
        form.AddField("ccy", ccy.ToString());
        form.AddField("ccz", ccz.ToString());
        form.AddField("paso", paso.ToString());
        form.AddField("dibujar", dibujar.ToString());
    }

    public override void FormFillElim(WWWForm form)
    {
        form.AddField("idDucto", idDucto.ToString());
    }

    public override string FormType()
    {
        return "Ductopass";
    }

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6}", idDucto, ccx, ccy, ccz, paso, dibujar,estado);
    }
}
	
	
[System.Serializable]
public class ListaDuctopass 
{
	public List<Ductopass> ductopasss;

    public void CargarDuctopass(List<Ductopass> datos)
    {
        foreach (Ductopass atributo in ductopasss)
        {
            datos.Add(atributo);
        }
	}
	 
}

