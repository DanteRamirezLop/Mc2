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

        clsEliminar varAux_1 = new clsEliminar();
        varAux_1.id = 5;
        varAux_1.nom_Tabla ="Ducto";
        DatosScena.Eliminar.Add(varAux_1);
        
        /*
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


    }
}
