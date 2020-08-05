using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class RegistroEquipo : MonoBehaviour {

    public void Registrar(Equipo datos)
    {
		StartCoroutine(RegistraBD(datos));
    }

    private IEnumerator RegistraBD(Equipo datos)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", datos.id.ToString());
        form.AddField("idProyecto", datos.idProyecto.ToString());
        form.AddField("codigo", datos.codigo.ToString());
        form.AddField("tipo", datos.tipo.ToString());
        form.AddField("velocidadIny", datos.velocidadIny.ToString());
        form.AddField("velocidadExt", datos.velocidadExt.ToString());
        form.AddField("porcentajeIny", datos.porcentajeIny.ToString());
		form.AddField("porcentajeExt", datos.porcentajeExt.ToString());
		form.AddField("calculo", datos.calculo.ToString());
        form.AddField("vinculo", datos.vinculo.ToString());
        form.AddField("nivel", datos.nivel.ToString());
        form.AddField("idAmbiente", datos.idAmbiente.ToString());
        form.AddField("ccx", datos.ccx.ToString());
		form.AddField("ccy", datos.ccy.ToString());
	    form.AddField("ccz", datos.ccz.ToString());
		//-------------
		form.AddField("potencia", datos.potencia.ToString());
        form.AddField("voltaje", datos.voltaje.ToString());
        form.AddField("sistema", datos.sistema.ToString());
        form.AddField("enfEntrada1", datos.enfEntrada1.ToString());
        form.AddField("enfEntrada2", datos.enfEntrada2.ToString());
        form.AddField("enfSalida1", datos.enfSalida1.ToString());
        form.AddField("enfSalida2", datos.enfSalida2.ToString());
        form.AddField("tipo2", datos.tipo2.ToString());
        form.AddField("Hz", datos.Hz.ToString());
        form.AddField("CSensible", datos.CSensible.ToString());
		form.AddField("CLatente", datos.CLatente.ToString());
		form.AddField("ESensible", datos.ESensible.ToString());
		form.AddField("ELatente", datos.ELatente.ToString());
		form.AddField("caudal", datos.caudal.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/Registrar/Equipo.php", form))
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
