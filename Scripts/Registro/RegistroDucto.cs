﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroDucto : MonoBehaviour {

    //public Text id;
	public InputField longitud;
    public InputField paso;
    public InputField dibujar;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (longitud.text != "" && paso.text != "" && dibujar.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(longitud.text, paso.text, dibujar.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string longitud, string paso, string dibujar)
    {
        WWWForm form = new WWWForm();
        form.AddField("longitud", longitud);
        form.AddField("paso", paso);
        form.AddField("dibujar", dibujar);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Ducto.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{
                Debug.Log(www.downloadHandler.text);
            }
        
        }
    }
}