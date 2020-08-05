using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodoCanvas : MonoBehaviour
{
    public Toggle tgDerecha;
    public Toggle tgIzquierda;
    public Toggle tgArriba;
    public Toggle tgAbajo;
    public Toggle tgOtro;
    public InputField inputEjeX;
    public InputField inputEjeY;

    public void InputController(InputField ctrl)
    {
        if (ctrl.text.Equals(""))
            ctrl.text = "0";
        if (double.Parse(ctrl.text) > 180)
            ctrl.text = "180";
    }

    public void ADerecha()
    {

    }
}
