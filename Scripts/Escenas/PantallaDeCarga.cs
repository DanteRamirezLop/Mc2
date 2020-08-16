using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;//-
using UnityEngine.Networking;
using System;//-

public class PantallaDeCarga : MonoBehaviour {

    public static PantallaDeCarga Instancia { get; private set; }

    public Image imageDeCarga;
    [Range(0.01f, 0.1f)]
    public float velocidadAparecer = 0.5f;
    [Range(0.01f, 0.1f)]
    public float velocidadOcultar = 0.5f;
    public float tiempo = 2f;
    private float ContadorTiempo;
    public Text txtCargando;
    public Text txtInfo;
    public string URL;

    void Awake()
    {
        DefinirSingleton();
    }
    /// <summary>
    /// Singleton para evitar que el objeto se destrulla en la siguente escena
    /// </summary>
    private void DefinirSingleton()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(this);
            imageDeCarga.gameObject.SetActive(false);
            txtCargando.gameObject.SetActive(false);
            txtInfo.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// llamar la corrutina
    /// </summary>
    /// <param name="nombreEscena"></param>
    public void CargarEscena(string nombreEscena)
    {
        StartCoroutine(MostrarPantallaDeCarga(nombreEscena));
    }

    /// <summary>
    ///  Corrutina para cargar las escena y los datos defindas en otros scripts
    /// </summary>
    /// <param name="nombreEscena"></param>
    /// <returns></returns>
    private IEnumerator MostrarPantallaDeCarga(string nombreEscena)
    {
        imageDeCarga.gameObject.SetActive(true);
        txtCargando.gameObject.SetActive(true);
        txtInfo.gameObject.SetActive(true);
        Color c = imageDeCarga.color;
        c.a = 0.0f;

        List<Ambiente> ambiente = new List<Ambiente>();
        List<Ducto> ducto = new List<Ducto>();
        List<Ductopass> ductopass = new List<Ductopass>();
        List<Equipo> equipo = new List<Equipo>();
        List<Filtro> filtro = new List<Filtro>();
        List<Espfiltro> espfiltro = new List<Espfiltro>();
        List<Item> item = new List<Item>();
        List<Metradoex> metradoex = new List<Metradoex>();
        List<Multiple> multiple = new List<Multiple>();
        List<Rejilla> rejilla = new List<Rejilla>();

        //Mientras no esté totalmente visible va aumentando su visibilidad
        while (c.a < 1)
        {
            imageDeCarga.color = c;
            c.a += velocidadAparecer;
            yield return null;
        }

        //Cargar el text cargar
        txtCargando.text = "CARGANDO";
        //Solicitar y recepcionar los datos de La BD por medio del protrocolo HTTP y el metodo GET 
        using (UnityWebRequest reqAmbiente = UnityWebRequest.Get(URL + "ambiente"))
        {
            yield return reqAmbiente.SendWebRequest();
            if (!string.IsNullOrEmpty(reqAmbiente.error)) {
                Debug.Log(reqAmbiente.error);
            }
            else {
                ListaAmbiente listaAmbiente = JsonUtility.FromJson<ListaAmbiente>(reqAmbiente.downloadHandler.text);
                listaAmbiente.CargarAmbiente(ambiente);
                DatosScena.Ambiente = ambiente;
                txtInfo.text = txtInfo.text + "Ambiente (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqDucto = UnityWebRequest.Get(URL + "ducto"))
        {
            yield return reqDucto.SendWebRequest();
            if (!string.IsNullOrEmpty(reqDucto.error))
            {
                Debug.Log(reqDucto.error);
            }
            else
            {
                ListaDucto listaDucto = JsonUtility.FromJson<ListaDucto>(reqDucto.downloadHandler.text);
                listaDucto.ObtenerDucto(ducto);
                DatosScena.Ducto = ducto;
                txtInfo.text = txtInfo.text + "Ducto (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqDuctopass = UnityWebRequest.Get(URL + "ductopass"))
        {
            yield return reqDuctopass.SendWebRequest();
            if (!string.IsNullOrEmpty(reqDuctopass.error))
            {
                Debug.Log(reqDuctopass.error);
            }
            else
            {
                ListaDuctopass listaDuctopass = JsonUtility.FromJson<ListaDuctopass>(reqDuctopass.downloadHandler.text);
                listaDuctopass.CargarDuctopass(ductopass);
                DatosScena.Ductopass = ductopass;
                txtInfo.text = txtInfo.text + "Ductoex (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqEquipo = UnityWebRequest.Get(URL + "equipo"))
        {
            yield return reqEquipo.SendWebRequest();
            if (!string.IsNullOrEmpty(reqEquipo.error)) {
                Debug.Log(reqEquipo.error);
            }
            else {
                ListaEquipo listaEquipo = JsonUtility.FromJson<ListaEquipo>(reqEquipo.downloadHandler.text);
                listaEquipo.CargarEquipo(equipo);
                DatosScena.Equipo = equipo;
                txtInfo.text = txtInfo.text + "Equipo (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqFiltro = UnityWebRequest.Get(URL + "filtro"))
        {
            yield return reqFiltro.SendWebRequest();
            if (!string.IsNullOrEmpty(reqFiltro.error)) {
                Debug.Log(reqFiltro.error);
            }
            else {
                ListaFiltro listaFiltro = JsonUtility.FromJson<ListaFiltro>(reqFiltro.downloadHandler.text);
                listaFiltro.CargarFiltro(filtro);
                DatosScena.Filtro = filtro;
                txtInfo.text = txtInfo.text + "Filtro (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqEspfiltro = UnityWebRequest.Get(URL + "espfiltro"))
        {
            yield return reqEspfiltro.SendWebRequest();
            if (!string.IsNullOrEmpty(reqEspfiltro.error))
            {
                Debug.Log(reqEspfiltro.error);
            }
            else {
                ListaEspfiltro listaEspfiltro = JsonUtility.FromJson<ListaEspfiltro>(reqEspfiltro.downloadHandler.text); //error
                listaEspfiltro.CargarEspfiltro(espfiltro);
                DatosScena.Espfiltro = espfiltro;
                txtInfo.text = txtInfo.text + "Espfiltro (CARGADO) \n";
            }
        }
        /*
        using (UnityWebRequest reqItem = UnityWebRequest.Get(URL + "item"))
        {
            yield return reqItem.SendWebRequest();
            if (!string.IsNullOrEmpty(reqItem.error)){
                Debug.Log(reqItem.error);
            }
            else{
                ListaItem listaItem = JsonUtility.FromJson<ListaItem>(reqItem.downloadHandler.text);
                listaItem.CargarItem(item);
                DatosScena.Item = item;
                txtInfo.text = txtInfo.text + "Item (CARGADO) \n";
            }
        }*/

        using (UnityWebRequest reqMetradoex = UnityWebRequest.Get(URL + "metradoex"))
        {
            yield return reqMetradoex.SendWebRequest();
            if (!string.IsNullOrEmpty(reqMetradoex.error)) {
                Debug.Log(reqMetradoex.error);
            }
            else {
                ListaMetradoex listaMetradoex = JsonUtility.FromJson<ListaMetradoex>(reqMetradoex.downloadHandler.text);
                listaMetradoex.CargarMetradoex(metradoex);
                DatosScena.Metradoex = metradoex;
                txtInfo.text = txtInfo.text + "Metradoex (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqMultiple = UnityWebRequest.Get(URL + "multiple"))
        {
            yield return reqMultiple.SendWebRequest();
            if (!string.IsNullOrEmpty(reqMultiple.error)) {
                Debug.Log(reqMultiple.error);
            }
            else {
                ListaMultiple listaMultiple = JsonUtility.FromJson<ListaMultiple>(reqMultiple.downloadHandler.text);
                listaMultiple.CargarMultiple(multiple);
                DatosScena.Multiple = multiple;
                txtInfo.text = txtInfo.text + "Multiple (CARGADO) \n";
            }
        }

        using (UnityWebRequest reqRejilla = UnityWebRequest.Get(URL + "rejilla")) {
            yield return reqRejilla.SendWebRequest();
            if (!string.IsNullOrEmpty(reqRejilla.error)) {
                Debug.Log(reqRejilla.error);
            }
            else {
                ListaRejilla listaRejillas = JsonUtility.FromJson<ListaRejilla>(reqRejilla.downloadHandler.text);
                listaRejillas.CargarRejilla(rejilla);
                DatosScena.Rejilla = rejilla;
                txtInfo.text = txtInfo.text + "Rejillla (CARGADO) \n";
            }
        }

        //Tiempo de carga
        while (ContadorTiempo <= tiempo)
        {
            ContadorTiempo = ContadorTiempo + Time.deltaTime;
            yield return null;
        }

        //Carga la escena
        SceneManager.LoadScene(nombreEscena);

        //Espera a que haya cargado la nueva escena
        while (!nombreEscena.Equals(SceneManager.GetActiveScene().name))
        {
            yield return null;
        }

        //Mientras la imagen de carga siga visible va desvaneciéndola
        while (c.a > 0)
        {
            imageDeCarga.color = c;
            c.a -= velocidadOcultar;
            yield return null;
        }
        // se desactiva la imagen una vez en la otra escena
        txtCargando.text = "";
        txtInfo.text = "";
        imageDeCarga.gameObject.SetActive(false);
        txtCargando.gameObject.SetActive(false);
        txtInfo.gameObject.SetActive(false);
    }
    
}
