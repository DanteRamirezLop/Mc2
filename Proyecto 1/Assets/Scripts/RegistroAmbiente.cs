using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegistroAmbiente : MonoBehaviour {

    public InputField idProyecto;
    public InputField nAmbiente;
    public InputField largo;
    public InputField ancho;
    public InputField altura;
    public InputField area;
    public InputField recambios;
    public InputField flujo;
    public InputField cfm;
    public Text coordenadas;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {

        if (idProyecto.text != "" && nAmbiente.text != "" && largo.text != "" && ancho.text != "" && altura.text != "" && area.text != "" && recambios.text != "" && flujo.text != "" && cfm.text != "" && coordenadas.text != "")
        {
            Debug.Log("Correcto");
            StartCoroutine(RegistraBD(idProyecto.text, nAmbiente.text, largo.text, ancho.text, altura.text, area.text, recambios.text, flujo.text, cfm.text,coordenadas.text));
            LimpiarCampos();

        }
        else {
            Panel_msj.SetActive(true);
        }
     
    }

    private void LimpiarCampos(){
        idProyecto.text = "";
        nAmbiente.text = "";
        largo.text = "";
        ancho.text = "";
        altura.text = "";
        area.text = "";
        recambios.text = "";
        flujo.text = "";
        cfm.text = "";
        coordenadas.text = "";
    }

    private IEnumerator RegistraBD(string idProyecto, string nAmbiente, string largo, string ancho, string altura, string area, string recambios, string flujo, string cfm, string coordenadas)
    {
        WWWForm form = new WWWForm();
        form.AddField("idProyecto", idProyecto);
        form.AddField("nAmbiente", nAmbiente);
        form.AddField("largo", largo);
        form.AddField("ancho", ancho);
        form.AddField("altura", altura);
        form.AddField("area", area);
        form.AddField("recambios", recambios);
        form.AddField("flujo", flujo);
        form.AddField("cfm", cfm);
        form.AddField("coordenadas", coordenadas);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Ambiente.php", form))
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
