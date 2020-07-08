using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;

public class ConstruirAmbiente : MonoBehaviour {

    public string URL;
    public string Id_Foranea;
    public Dropdown ComboAmnietnes;
    public GameObject PrefabPiso;
    public AmbienteControl ScriptAmbCont;

    private Dictionary<string, string> localizedText;

    void Start()
    {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(AmbienteOnReponse(Id_Foranea));
        Debug.Log("En el Star");
    }

    public void seleccionCombo() {
        Id_Foranea = DatosScena.Id_proyecto;
        StartCoroutine(SeleccionarAmbiente(Id_Foranea));	
    }

    private IEnumerator SeleccionarAmbiente(string Id_Foranea) 
    {
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ambiente/" + Id_Foranea))
        {

            yield return req.SendWebRequest();

            //if(www.isNetworkError || www.isHttpError)
            if (!string.IsNullOrEmpty(req.error)){
                Debug.Log(req.error);
            }
            else{

                int Cantidad;
                List<Vector2> Coordenada2 = new List<Vector2>();
                double[] altura2 = new double[1];
                double altura = 0f;
                string NombreAmbiente = "";

                ListaAmbientes listaAmbientes = JsonUtility.FromJson<ListaAmbientes>(req.downloadHandler.text);
                Cantidad = listaAmbientes.ambientes.Count;

                if (Cantidad != 0){

                    NombreAmbiente = ComboAmnietnes.captionText.text;
                    listaAmbientes.AmbientesSeleccionado(altura2, NombreAmbiente, Coordenada2);
                    Vector2[] Coordenada = Coordenada2.ToArray();
                    altura = altura2[0];
                    ScriptAmbCont.EnterData(Coordenada, altura);
                }
                else {
                    Debug.Log("Este Proyecto no tiene ambientes");
                }
            }
        }
    }

    private IEnumerator AmbienteOnReponse(string Id_Foranea)
    {
        Debug.Log("En la corrutina");
        using (UnityWebRequest req = UnityWebRequest.Get(URL + "ambiente/" + Id_Foranea))
      {
          yield return req.SendWebRequest();

         //if(www.isNetworkError || www.isHttpError)
         if (!string.IsNullOrEmpty(req.error)){
            Debug.Log(req.error);

         }else {

            int Cantidad;
            List<Vector2> Coordenada2 = new List<Vector2>();
            double[] altura2 = new double[1];
            double altura = 0f;

            ListaAmbientes listaAmbientes = JsonUtility.FromJson<ListaAmbientes>(req.downloadHandler.text);
            Cantidad = listaAmbientes.ambientes.Count;

            if (Cantidad != 0){
                listaAmbientes.CargarAmbientes(altura2, ComboAmnietnes, Coordenada2);
                Vector2[] Coordenada = Coordenada2.ToArray();
                altura = altura2[0];
                ScriptAmbCont.EnterData(Coordenada, altura);
            }
             else {
                 Debug.Log("Este Proyecto no tiene ambientes");
                 AmbienteVacio();
                 ComboAmnietnes.options.Clear();
             }
        }
      }
    }

    private void AmbienteVacio() {

        GameObject Piso = Instantiate(PrefabPiso, new Vector3(0,0,0),Quaternion.identity);
    }

    [System.Serializable]
    public class Ambiente
    {
        public string id;
        public string idProyecto;
        public string nAmbiente;
        public string largo;
        public string ancho;
        public string altura;
        public string area;
        public string recambios;
        public string flujo;
        public string cfm;
        public string coordenada;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", id, idProyecto, nAmbiente, largo, ancho, altura, area, recambios, flujo, cfm, coordenada);
        }
    }

    [System.Serializable]
    public class ListaAmbientes
    {
        public List<Ambiente> ambientes;

        public void CargarAmbientes(double[] altura, Dropdown ComboAmnietnes, List<Vector2> Coordenada2)
         {
             int count = 0;
            // int cont2 = 0;//*********
             float x = 0.0f;
             float y = 0.0f;

             string Coordenadas;
             string Nombre= "";
             char newLine = '\n';
             char puntoComa = ';';

             ComboAmnietnes.options.Clear();
             List<string> nombres = new List<string>();

             foreach (Ambiente ambiente in ambientes)
             {
                 if (count == 0)
                 {
                     altura[0] = Double.Parse(ambiente.altura);
                     Coordenadas = ambiente.coordenada;
                     string[] split1 = Coordenadas.Split(newLine);

                     foreach (string coordenadaText in split1 )
                     {                 
                         string[] coordenadaPar = coordenadaText.Split(puntoComa);

                         x = Single.Parse(coordenadaPar[0]);
                         y = Single.Parse(coordenadaPar[1]);

                         Coordenada2.Add(new Vector2(x,y));
                         //cont2++;//****
                     }
                 }

                 Nombre = ambiente.nAmbiente;
                 nombres.Add(Nombre);
                 count++;
             }
             ComboAmnietnes.AddOptions(nombres);
         }

        public void AmbientesSeleccionado(double[] altura, string NombreAmbiente, List<Vector2> Coordenada2)
         {
             float x = 0.0f;
             float y = 0.0f;

             string Coordenadas;
             char newLine = '\n';
             char puntoComa = ';';

             foreach (Ambiente ambiente in ambientes)
             {
                 if (NombreAmbiente == ambiente.nAmbiente)
                 {
                     altura[0] = Double.Parse(ambiente.altura);
                     Coordenadas = ambiente.coordenada;
                     string[] split1 = Coordenadas.Split(newLine);

                     foreach (string coordenadaText in split1 )
                     {                 
                         string[] coordenadaPar = coordenadaText.Split(puntoComa);

                         x = Single.Parse(coordenadaPar[0]);
                         y = Single.Parse(coordenadaPar[1]);

                         Coordenada2.Add(new Vector2(x,y));
                     }
                 }
             }
         }
    }
}
