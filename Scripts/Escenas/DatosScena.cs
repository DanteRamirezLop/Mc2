using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosScena : MonoBehaviour {
    //*****El nombre aporpiado deberia ser SingletonProyecto********
    //El valor de un campo estático se comparte entre las instancias, por lo que si se crea una nueva instancia de esta clase
    private static DatosScena _instance; 

    //Dato del proyecto para accesar en la siguiente escena
    public static string Id_proyecto;
    public static List<string> Ambiente;
    public static List<string> Ducto;
    public static List<string> Ductoex;
    public static List<string> Equipo; 
    public static List<string> Filtro;  
    public static List<string> Espfiltro;  
    public static List<string> Item;  
    public static List<string> Metradoex;  
    public static List<string> Multiple;  
    public static List<string> Rejilla;  

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
