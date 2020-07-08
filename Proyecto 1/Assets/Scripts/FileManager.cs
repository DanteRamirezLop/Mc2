using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class FileManager : MonoBehaviour {

    string Direccion;
   // public RawImage imagen;
    public Text Txt_Coordenadas;

    public void AbrirExplorador() {
        Direccion = EditorUtility.OpenFilePanel("Overwrite with png", "", "txt");
        ObtenerTexto();
    }

    void ObtenerTexto()
    {
        if (Direccion != null) {
            ActualizarTexto();
        }
    }
    void ActualizarTexto() 
    {
        WWW www = new WWW("file://" + Direccion);

        Txt_Coordenadas.text = www.text;
    }


}
