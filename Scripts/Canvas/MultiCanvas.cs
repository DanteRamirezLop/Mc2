using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCanvas : MonoBehaviour
{
    private GameObject grabbed;
    public GameObject texto;
    private List<GameObject> textoSac;
    public GameObject boton;
    public GameObject cEquipo;
    public GameObject cDucto;
    public GameObject cMultiple;
    public GameObject cRejilla;
    public GameObject cCodo;

    private void Awake()
    {
        cEquipo.GetComponent<EquipoCanvas>().controlador = this.gameObject;
        cDucto.GetComponent<DuctoCanvas>().controlador = this.gameObject;
        textoSac = new List<GameObject>();
    }
    public void SetGrab(GameObject gr)
    {
        if (gr == null)
        {
            this.gameObject.SetActive(false);
            cEquipo.SetActive(false);
            cDucto.SetActive(false);
            //hide here
            grabbed = null;
        }
        else
        {
            this.gameObject.SetActive(true);
            grabbed = gr;
            switch (gr.GetComponent<ObjectControlMain>().getTipo())
            {
                case 0:
                    EquipoOrden();
                    break;
                case 1:
                    DuctoOrden();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }

    private void DuctoOrden()
    {
        Refresh();
        DuctoControl dc = grabbed.GetComponent<DuctoControl>();
        texto.GetComponent<Text>().text = $"Nombre : {dc.ducto.nombre}";
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac[0].GetComponent<Text>().text = $"Flujo CFM: {dc.CFMreal()}";
        textoSac[1].GetComponent<Text>().text = $"Diametro equivalente: {dc.DiametroEquivalente()}";
        textoSac[2].GetComponent<Text>().text = $"Caida presión UNIT[in/100fts]: {dc.CaidaPresionUnitaria()}";
        textoSac[3].GetComponent<Text>().text = $"Caida presión PISO[in H2O]: {dc.CaidaPresionUnitaria()}";
        textoSac[4].GetComponent<Text>().text = $"Velocidad [fpm]: {dc.Velocidad()}";
        textoSac[5].GetComponent<Text>().text = $"HV: {dc.HV()}";
        textoSac[6].GetComponent<Text>().text = $"Caida presion UNIT [in H2O]: {dc.CaidaPresionH2O()}";
        textoSac[7].GetComponent<Text>().text = $"Perdida total [in H2O]: {dc.PerdidaTotal()}";
        ReOrderElements();
    }

    private void EquipoOrden()
    {
        Refresh();
        EquipoControl ec = grabbed.GetComponent<EquipoControl>();
        texto.GetComponent<Text>().text = "Nombre: " + ec.equip.codigo;
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac.Add(GameObject.Instantiate(texto, this.gameObject.transform));
        textoSac[0].GetComponent<Text>().text = "Tipo: " + ec.GetTipoEsp();
        textoSac[1].GetComponent<Text>().text = "CFM real: " + ec.CFMreal();
        if (ec.equip.calculo)
            textoSac[2].GetComponent<Text>().text = "Equipo de ventilación";
        else
        {
            textoSac[2].GetComponent<Text>().text = "Equipo de aire acondicionado";
            textoSac[2].GetComponent<RectTransform>().sizeDelta = new Vector2(200, 20);
            textoSac[2].GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 10, 200);
        }
        ReOrderElements();
    }
    private void Refresh()
    {
        while (textoSac.Count > 0)
        {
            Destroy(textoSac[0]);
            textoSac.RemoveAt(0);
        }
    }
    private void ReOrderElements()
    {
        for (int i = 0; i < textoSac.Count; i++)
        {
            textoSac[i].GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 60 + 25 * i, 20);
        }
        boton.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 70 + 25 * textoSac.Count, 30);
        this.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0 , 105 + 25 * textoSac.Count);
    }
    public void OnClickHandler()
    {
        if (grabbed == null)
            return;
        switch (grabbed.GetComponent<ObjectControlMain>().getTipo())
        {
            case 0:
                cEquipo.SetActive(true);
                EquipoCanvas e = cEquipo.GetComponent<EquipoCanvas>();
                e.target = grabbed.GetComponent<EquipoControl>();
                e.Exploit();
                break;
            case 1:
                cDucto.SetActive(true);
                DuctoCanvas d = cDucto.GetComponent<DuctoCanvas>();
                d.target = grabbed.GetComponent<DuctoControl>();
                d.Exploit();
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
        this.gameObject.SetActive(false);
    }
    public void RefreshData()
    {
        if (grabbed != null)
        {
            switch (grabbed.GetComponent<ObjectControlMain>().getTipo())
            {
                case 0:
                    EquipoOrden();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
