using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosScena : MonoBehaviour {
    //*****El nombre aporpiado deberia ser SingletonProyecto********
    //El valor de un campo estático se comparte entre las instancias, por lo que si se crea una nueva instancia de esta clase
    private static DatosScena _instance;

    //Dato del proyecto para accesar en la siguiente escena
    public static string Id_proyecto;
    public static List<Ambiente> Ambiente;
    public static List<Ducto> Ducto;
    public static List<Ductopass> Ductopass;
    public static List<Equipo> Equipo;
    public static List<Filtro> Filtro;
    public static List<Espfiltro> Espfiltro;
    //public static List<Item> Item;
    public static List<Metradoex> Metradoex;
    public static List<Multiple> Multiple;
    public static List<Rejilla> Rejilla;
    public static List<clsEliminar> Eliminar = new List<clsEliminar>();

    public static string escenaEdit = "PruebasScriptE";
    public static string URL = "http://localhost:8080/mc2/";

    
    /// <summary>
    /// Evita que el objeto sea destruido al pasar de escena (Singleton)
    /// </summary>
    void Awake()
    {
        // Si, encontrará una referencia al primer objeto Singleton,Si no, destruyendo la nueva instancia
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            //Rest of your Awake code
        }
        else
        {
            Destroy(this);
        }
    }
    public static void CargaProyecto(string idProyecto)
    {
        Id_proyecto = idProyecto;
        PantallaDeCarga.Instancia.CargarEscena(escenaEdit);
    }
/*
    public void InsertarBD() 
    {
        foreach (Ambiente items in Ambiente) 
        {
            if (items.id == 0 && items.estado==true)
                ScriptA.Registrar(items);
        }
        foreach (Ducto items in Ducto)
        {
            if (items.id == 0 && items.estado == true)
                ScriptD.Registrar(items);
        }
        foreach (Ductopass items in Ductopass)
        {
            if (items.idDucto == 0 && items.estado == true)
                ScriptDP.Registrar(items);
        }
        foreach (Equipo items in Equipo)
        {
            if (items.id == 0 && items.estado == true)
                ScriptE.Registrar(items);
        }
        foreach (Filtro items in Filtro)
        {
            if (items.id == 0 && items.estado == true)
                ScriptF.Registrar(items);
        }
        foreach (Espfiltro items in Espfiltro)
        {
            if (items.idEquip == 0 && items.estado == true)
                ScriptEF.Registrar(items);
        }
        foreach (Metradoex items in Metradoex)
        {
            if (items.id == 0 && items.estado == true)
                ScriptME.Registrar(items);
        }
        foreach (Multiple items in Multiple)
        {
            if (items.id == 0 && items.estado == true)
                ScriptMU.Registrar(items);
        }
        foreach (Rejilla items in Rejilla)
        {
            if (items.id == 0 && items.estado == true)
                ScriptR.Registrar(items);
        }
    
    }
    */
}
