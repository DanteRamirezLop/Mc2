using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;


public class pruebaConstructor : MonoBehaviour
{
    public ConstruirEquipov llamada;

    public void prueba() {
        List<string> prueba = new List<string>();

        prueba=llamada.DatosEquipov("4");
        
        foreach (string item in prueba)
        {
            Debug.Log(item);
        }
        
    }



}
