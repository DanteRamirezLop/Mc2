using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroEquipov : MonoBehaviour {

     //public InputField id;
	public Text idProyecto;
    public InputField codigo;
    public InputField tipo;
    public InputField velcidadlny;
    public InputField velocidadExt;
    public InputField porcentajelny;
	public InputField porcentajeExt;
    public InputField calculo;
    public InputField vinculo;
    public InputField nivel;
	public InputField idAmbiente;
	public InputField ccx;
	public InputField ccy;
	public InputField ccz;
   

    public GameObject Panel_msj;
    
    public void RegistrarAmbiente()
    {
        if (idProyecto.text != "" && codigo.text != "" && tipo.text != "" && velcidadlny.text != "" && velocidadExt.text != "" && porcentajelny.text != "" && porcentajeExt.text != ""  && calculo.text != "" && vinculo.text != "" && nivel.text != "" && idAmbiente.text != ""&& ccx.text != ""&& ccy.text != ""&& ccz.text != "")
        {
            //validar que solo se ingrese numeros o texto
            StartCoroutine(RegistraBD(idProyecto.text, codigo.text, tipo.text, velcidadlny.text, velocidadExt.text, porcentajelny.text, porcentajeExt.text, calculo.text,vinculo.text, nivel.text, idAmbiente.text,ccx.text,ccy.text,ccz.text));
            SceneManager.LoadScene("EscenaConstruccion");
        }else {
            Panel_msj.SetActive(true);
        }
    }

    private IEnumerator RegistraBD(string idProyecto, string codigo, string tipo, string velcidadlny, string velocidadExt, string porcentajelny, string porcentajeExt, string calculo, string vinculo, string nivel, string idAmbiente, string ccx, string ccy, string ccz)
    {
        WWWForm form = new WWWForm();
        form.AddField("idProyecto", idProyecto);
        form.AddField("codigo", codigo);
        form.AddField("tipo", tipo);
        form.AddField("velcidadlny", velcidadlny);
        form.AddField("velocidadExt", velocidadExt);
        form.AddField("porcentajelny", porcentajelny);
		form.AddField("porcentajeExt", porcentajeExt);
		form.AddField("calculo", calculo);
        form.AddField("vinculo", vinculo);
        form.AddField("nivel", nivel);
        form.AddField("idAmbiente", idAmbiente);
        form.AddField("ccx", ccx);
		form.AddField("ccy", ccy);
	    form.AddField("ccz", ccz);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registro/Equipov.php", form))
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
