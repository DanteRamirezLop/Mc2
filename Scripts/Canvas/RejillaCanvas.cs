using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RejillaCanvas : MonoBehaviour
{
    public RejillaControl target;
    public InputField inputNombre;
    public InputField inputCFM;
    public Toggle AutoCFM;
    public Text lblTotal;
    public Text lblDisponible;
    public GameObject controlador;
    private AmbienteControl targetAmb;
    public void InputController(InputField ctrl)
    {
        if (ctrl.text.LastIndexOf(".") == ctrl.text.Length -1)
            ctrl.text = ctrl.text.Substring(0, ctrl.text.Length - 1);
        if (ctrl.text.Equals("") || ctrl.text.Equals(".") || ctrl.text.Equals("0."))
            ctrl.text = "0";
    }
    public void MainChange()
    {
        if (!AutoCFM.isOn)
        {
            double nm = double.Parse(inputCFM.text);
            nm = nm < 0?0:nm;
            nm = nm > targetAmb.GetCFMDisponible()?targetAmb.GetCFMDisponible():nm;
            target.rejilla.cfm = nm;
        }
    }
    public void TgChange()
    {
        if (AutoCFM.isOn)
        {
            target.rejilla.cfm = 0;
            inputCFM.text = targetAmb.GetDefaultCFM() + "";
        }
        else
        {
            target.rejilla.cfm = targetAmb.GetDefaultCFM();
        }
    }
    public void Exploit()
    {
        targetAmb = target.GetAmbiente();
        inputNombre.text = target.rejilla.nombre;
        inputCFM.text = target.rejilla.cfm > 0?target.rejilla.cfm + "":targetAmb.GetDefaultCFM() + "";
        AutoCFM.isOn = target.rejilla.cfm <= 0;
        lblTotal.text = $"CFM total del ambiente: {targetAmb.GetCFMTotal()}";
        lblDisponible.text = $"CFM disponible en el ambiente: {targetAmb.GetCFMDisponible()}";
    }
    public void Close()
    {
        if (controlador != null)
            controlador.SetActive(true);
        controlador.SendMessage("RefreshData");
        this.gameObject.SetActive(false);
    }
}
