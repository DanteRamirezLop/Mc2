using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;


public class pruebaConstructor : MonoBehaviour
{
    public ConstruirEquipov Tabla_1;
    public ConstruirDucto Tabla_2;
    public ConstruirDuctoex Tabla_3;
    public ConstruirDuctopass Tabla_4;
    public ConstruirFiltro Tabla_5;
    public ConstruirEspfiltro Tabla_6;
    public ConstruirItem Tabla_7;
    public ConstruirEquipoesp Tabla_8;
    public ConstruirMetradoex Tabla_9;
    public ConstruirMultiple Tabla_10;
    public ConstruirRejilla Tabla_11;

    public void prueba() {
        List<string> prueba = new List<string>();

        //prueba=Tabla_1.DatosEquipovId("4");
       //  = Tabla_1.DatosEquipov();

        //prueba = Tabla_2.DatosDuctoId("2");
        //prueba = Tabla_2.DatosDucto();

        //prueba = Tabla_3.DatosDuctoexId("1");
        //prueba = Tabla_3.DatosDuctoex();

        //prueba = Tabla_4.DatosDuctopassId("1");
        //prueba = Tabla_4.DatosDuctopass();

        //prueba = Tabla_5.DatosFiltroId("1");
        //prueba = Tabla_5.DatosFiltro();

        //prueba = Tabla_6.DatosEspfiltroId("1");
        //prueba = Tabla_6.DatosEspfiltro();

        //prueba = Tabla_7.DatosItemId("1");
        //prueba = Tabla_7.DatosItem();

        //prueba = Tabla_8.DatosEquipoespId("1");
        //prueba = Tabla_8.DatosEquipoesp();

        //prueba = Tabla_9.DatosMetradoexId("1");
        //prueba = Tabla_9.DatosMetradoex();

        //prueba = Tabla_10.DatosMultipleId("1");
        //prueba = Tabla_10.DatosMultiple();

        //prueba = Tabla_11.DatosRejillaId("1");
        prueba = Tabla_11.DatosRejilla();

        foreach (string item in prueba)
        {
            Debug.Log(item);
        }
        
    }



}
