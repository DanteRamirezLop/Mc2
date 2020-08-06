using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodoCanvas : MonoBehaviour
{
    public CodoControl target;
    public Toggle tgDerecha;
    public Toggle tgIzquierda;
    public Toggle tgArriba;
    public Toggle tgAbajo;
    public Toggle tgOtro;
    public InputField inputEjeX;
    public InputField inputEjeY;
    public GameObject controlador;

    public void InputController(InputField ctrl)
    {
        if (ctrl.text.Equals("") || ctrl.text.Equals("-"))
            ctrl.text = "0";
        if (double.Parse(ctrl.text) > 180)
            ctrl.text = "180";
    }

    public void GetAngle()
    {
        if (tgDerecha.isOn)
        {
            target.codo.giroX = 90;
            target.codo.giroY = 0;
        }
        else if (tgIzquierda.isOn)
        {
            target.codo.giroX = -90;
            target.codo.giroY = 0;
        }
        else if (tgArriba.isOn)
        {
            target.codo.giroX = 0;
            target.codo.giroY = 90;
        }
        else if (tgAbajo.isOn)
        {
            target.codo.giroX = 0;
            target.codo.giroY = -90;
        }
        else
        {
            target.codo.giroX = float.Parse(inputEjeX.text);
            target.codo.giroY = float.Parse(inputEjeY.text);
            inputEjeX.interactable = true;
            inputEjeY.interactable = true;
            target.RefreshA();
            return;
        }
        target.RefreshA();
        inputEjeX.text = target.codo.giroX + "";
        inputEjeY.text = target.codo.giroY + "";
        inputEjeX.interactable = false;
        inputEjeY.interactable = false;
    }
    public void Exploit()
    {
        if (target.codo.giroX == 90 && target.codo.giroY == 0)
        {
            tgDerecha.isOn = true;
        }
        else if (target.codo.giroX == -90 && target.codo.giroY == 0)
        {
            tgIzquierda.isOn = true;
        }
        else if (target.codo.giroX == 0 && target.codo.giroY == 90)
        {
            tgArriba.isOn = true;
        }
        else if (target.codo.giroX == 0 && target.codo.giroY == -90)
        {
            tgAbajo.isOn = true;
        }
        else
        {
            tgOtro.isOn = true;
        }
        inputEjeX.interactable = tgOtro.isOn;
        inputEjeY.interactable = tgOtro.isOn;
        inputEjeX.text = target.codo.giroX + "";
        inputEjeY.text = target.codo.giroY + "";
    }
    public void Close()
    {
        if (controlador != null)
            controlador.SetActive(true);
        controlador.SendMessage("RefreshData");
        this.gameObject.SetActive(false);
    }
}
