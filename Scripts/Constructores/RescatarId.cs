using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescatarId : MonoBehaviour {


    //*****Script de Pruebas**********

/*
    public RegistroAmbiente ScriptA;
    public RegistroDucto ScriptD;
    public RegistroDuctopass ScriptDP;
    public RegistroEquipo ScriptE;
    public RegistroFiltro ScriptF;
    public RegistroEspfiltro ScriptEF;
    public RegistroMetradoex ScriptME;
    public RegistroMultiple ScriptMU;
    public RegistroRejilla ScriptR;
*/
	void Start () {
/*
        Ambiente varAux = new Ambiente();
        varAux.id = 0;
        varAux.idProyecto = 1;
        varAux.nAmbiente = "lugar yy";
        varAux.largo = 1;
        varAux.ancho = 1;
        varAux.altura = 1;
        varAux.area = 1;
        varAux.recambios = 1;
        varAux.flujo = 1;
        varAux.cfm = 1;
        varAux.coordenada = "agregado";
        varAux.estado = true;

        DatosScena.Ambiente.Add(varAux);

        Rejilla varAux2 = new Rejilla();
        varAux2.id = 0;
        varAux2.idItem = 6;
        varAux2.idEquipo =1;
        varAux2.conexion = 1;
        varAux2.nombre = "ducto agregado";
        varAux2.cfm = 1;
        varAux2.estado = true;

        DatosScena.Rejilla.Add(varAux2);


        foreach (Ambiente items in DatosScena.Ambiente)
        {
            if (items.id == 1)
            {
                items.idProyecto = 1;
                items.nAmbiente = "Sala Principal";
                items.coordenada = "modificado";
                items.estado = true;
            }
        } */

        foreach (Rejilla items in DatosScena.Rejilla)
        {
            if (items.id == 6)
            {
                items.nombre = "ductmoyy";
                items.estado = true;
            }

        }

	}
}
