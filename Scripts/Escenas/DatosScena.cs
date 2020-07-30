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
    public static List<Item> Item;
    public static List<Metradoex> Metradoex;
    public static List<Multiple> Multiple;
    public static List<Rejilla> Rejilla;  

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
}
