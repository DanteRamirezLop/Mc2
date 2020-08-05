﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescatarId : MonoBehaviour {


    //*****Script de Pruebas**********

    //public Text cod_id;
    //public EliminarMetradoex ScriptA;
    public RegistroAmbiente ScriptA;
    public RegistroDucto ScriptD;
    public RegistroDuctopass ScriptDP;
    public RegistroEquipo ScriptE;
    public RegistroFiltro ScriptF;
    public RegistroEspfiltro ScriptEF;
    public RegistroMetradoex ScriptME;
    public RegistroMultiple ScriptMU;
    public RegistroRejilla ScriptR;

	void Start () {
     /*   cod_id.text = DatosScena.Id_proyecto;

        //Realizar una prueba
        //Probando las listas de DatosScena

        foreach (Ducto atributo in DatosScena.Ducto)
        {
            Debug.Log("-------");
            Debug.Log(atributo.idItem);
            Debug.Log(atributo.longitud);
            Debug.Log(atributo.estado);
        }*/
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
        varAux.coordenada = "0;0";
        varAux.estado = true;

        DatosScena.Ambiente.Add(varAux);

        Rejilla varAux2 = new Rejilla();
        varAux2.id = 0;
        varAux2.idItem = 4;
        varAux2.idEquipo =1;
        varAux2.conexion = 1;
        varAux2.nombre = "ducto 22";
        varAux2.cfm = 1;
        varAux2.estado = true;

        DatosScena.Rejilla.Add(varAux2);


	}



    public void registrar()
    {
 
        //ScriptA.Eliminar(3);
    }

    public void InsertarBD()
    {
        foreach (Ambiente items in DatosScena.Ambiente)
        {
            if (items.id == 0 && items.estado == true)
                ScriptA.Registrar(items);
        }
        foreach (Ducto items in DatosScena.Ducto)
        {
            if (items.id == 0 && items.estado == true)
                ScriptD.Registrar(items);
        }
        foreach (Ductopass items in DatosScena.Ductopass)
        {
            if (items.idDucto == 0 && items.estado == true)
                ScriptDP.Registrar(items);
        }
        foreach (Equipo items in DatosScena.Equipo)
        {
            if (items.id == 0 && items.estado == true)
                ScriptE.Registrar(items);
        }
        foreach (Filtro items in DatosScena.Filtro)
        {
            if (items.id == 0 && items.estado == true)
                ScriptF.Registrar(items);
        }
        foreach (Espfiltro items in DatosScena.Espfiltro)
        {
            if (items.idEquip == 0 && items.estado == true)
                ScriptEF.Registrar(items);
        }
        foreach (Metradoex items in DatosScena.Metradoex)
        {
            if (items.id == 0 && items.estado == true)
                ScriptME.Registrar(items);
        }
        foreach (Multiple items in DatosScena.Multiple)
        {
            if (items.id == 0 && items.estado == true)
                ScriptMU.Registrar(items);
        }
        foreach (Rejilla items in DatosScena.Rejilla)
        {
            if (items.id == 0 && items.estado == true)
                ScriptR.Registrar(items);
        }

    }

}
