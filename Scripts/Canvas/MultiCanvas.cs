using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCanvas : MonoBehaviour
{
    private GameObject grabbed;
    public GameObject texto;
    public GameObject boton;
    public GameObject cEquipo;
    public GameObject cDucto;
    public GameObject cMultiple;
    public GameObject cRejilla;
    public GameObject cCodo;
    
    public void SetGrab(GameObject gr)
    {
        if (grabbed == null)
        {
            this.gameObject.SetActive(false);
            //hide here
            grabbed = null;
        }
        else
        {
            grabbed = gr;
            switch (gr.GetComponent<ObjectControlMain>().getTipo())
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

    private void EquipoOrden()
    {
        cEquipo.SetActive(true);
        EquipoCanvas e = cEquipo.GetComponent<EquipoCanvas>();
        e.target = grabbed.GetComponent<EquipoControl>();
        e.Exploit();
        e.controlador = this.gameObject;
        this.gameObject.SetActive(false);
    }
}
