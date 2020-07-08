using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroEquipoesp : MonoBehaviour {

    //public Text idEquipoV;
    public InputField potencia;
    public InputField voltaje;
    public InputField sistema;
    public InputField enfEntrada1;
    public InputField enfEntrada2;
    public InputField enfSalida1;
    public InputField enfSalida2;
    public InputField tipo;
    public InputField Hz;
	public InputField CSensible;
    public InputField CLatente;
	public InputField ESensible;
	public InputField ELatente;
    public InputField caudal;

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (potencia.text != "" && voltaje.text != "" && sistema.text != "" && enfEntrada1.text != "" && enfEntrada2.text != "" && enfSalida1.text != "" && enfSalida2.text != "" && tipo.text != "" && Hz.text != ""&& CSensible.text != "" && CLatente.text != "" && ESensible.text != ""&& ELatente.text != "" && caudal.text != "")
        {
            //validar que solo se ingrese numeros o texto

            StartCoroutine(RegistraBD(potencia.text, voltaje.text, sistema.text, enfEntrada1.text, enfEntrada2.text, enfSalida1.text, enfSalida2.text, tipo.text, Hz.text,CSensible.text,CLatente.text,ESensible.text,ELatente.text,caudal.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string potencia, string voltaje, string sistema, string enfEntrada1, string enfEntrada2, string enfSalida1, string enfSalida2, string tipo, string Hz, string CSensible, string CLatente, string ESensible, string ELatente, string caudal)
    {
        WWWForm form = new WWWForm();
        form.AddField("potencia", potencia);
        form.AddField("voltaje", voltaje);
        form.AddField("sistema", sistema);
        form.AddField("enfEntrada1", enfEntrada1);
        form.AddField("enfEntrada2", enfEntrada2);
        form.AddField("enfSalida1", enfSalida1);
        form.AddField("enfSalida2", enfSalida2);
        form.AddField("tipo", tipo);
        form.AddField("Hz", Hz);
        form.AddField("CSensible", CSensible);
		form.AddField("CLatente", CLatente);
		form.AddField("ESensible", ESensible);
		form.AddField("ELatente", ELatente);
		form.AddField("caudal", caudal);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Equipoesp.php", form))
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
