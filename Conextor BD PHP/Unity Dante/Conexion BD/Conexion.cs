using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine.UI;

public class Conexion : MonoBehaviour {

    public string ServidorBD;  //LOCALHOST O 127.0.0.1 U OTRA RUTA DEL HOST
    public string BaseDatos;
    public string UsuarioBD;
    public string PasswordBD;

    public Text EstadoConex;

    private string DataConecction;

    // Use this for initialization
    void Start()
    {
        conectar();
    }

    private void conectar()
    {
        //connexion de BD MySql
        MySqlConnection conn = new MySqlConnection();
        DataConecction = "Server=" + ServidorBD
                         + ";Database=" + BaseDatos
                         + ";Uid=" + UsuarioBD
                         + ";Pwd=" + PasswordBD
                         + ";";

        conn.ConnectionString = DataConecction;

        try
        {
            conn.Open();
            //Debug.Log("--Activa--");
            EstadoConex.text = "Activa";
        }
        catch (MySqlException error)
        {
            Debug.Log("--Error--" + error);
            EstadoConex.text = "Error";
        }

    }


}
