using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class EquipoCanvas : MonoBehaviour
{
	public EquipoControl target;
	public InputField codigo;
    public Dropdown calculo;
	public Dropdown tipo;
	public InputField velocidadIny;
    public InputField velocidadExt;
    public InputField porcentajeIny;
    public InputField porcentajeExt;
    public int vinculo;
    public InputField nivel;
    public int idAmbiente;
    //parte de la tabla equipoesp
    public InputField potencia;
    public Toggle espPotencia;
    public InputField voltaje;
    public Dropdown sistema;
    public InputField enfEntrada1;
    public InputField enfEntrada2;
    public InputField enfSalida1;
    public InputField enfSalida2;
    public Dropdown tipoEsp;
    public InputField Hz;

    public InputField CSensible;
    public InputField CLatente;
    public InputField CTotal;

    public InputField ESensible;
    public InputField ELatente;
    public InputField ETotal;

    public InputField caudal;

    public Toggle CS;
    public Toggle CL;
    public Toggle CT;
    public Toggle ES;
    public Toggle EL;
    public Toggle ET;

    public GameObject controlador;

    private bool antiFlow = false;
    /// <summary>
    /// Saca los datos de codigo, a que calculo pertenece y el tipo del equipo (iny o ext)
    /// </summary>
    public void CambioMain()
    {
        if (target == null)
            return;
        target.codigo = codigo.text;
        target.tipo = tipo.value;
        target.calculo = calculo.value == 1;
        Debug.Log("main change");
    }
    public void CambioVelocidad()
    {
        if (target == null)
            return;
        if (Double.TryParse(velocidadIny.text, out double temp))
            target.velocidadIny = temp;
        else
        {
            velocidadIny.text = "0";
            target.velocidadIny = 0;
        }
        if (Double.TryParse(velocidadExt.text, out temp))
            target.velocidadExt = temp;
        else
        {
            velocidadExt.text = "0";
            target.velocidadExt = 0;
        }
        if (Double.TryParse(porcentajeIny.text, out temp))
            target.porcentajeIny = temp;
        else
        {
            porcentajeIny.text = "0";
            target.porcentajeIny = 0;
        }
        if (Double.TryParse(porcentajeExt.text, out temp))
            target.porcentajeExt = temp;
        else
        {
            porcentajeExt.text = "0";
            target.porcentajeExt = 0;
        }
        Debug.Log("vel change");
    }
    public void CambioPotencia(bool orden)
    {
        if (orden)
        {
            if (espPotencia.isOn)
            {
                target.potencia = -1;
                potencia.text = target.getAutoPotencia() + "";
            }
        }
        else
        {
            if (Double.TryParse(potencia.text, out double temp))
                target.potencia = temp;
            else
            {
                potencia.text = "0";
                target.potencia = 0;
            }
            espPotencia.isOn = false;
        }
    }
    public void CambioEsp()
    {
        if (Double.TryParse(voltaje.text, out double temp))
            target.voltaje = temp;
        else
        {
            voltaje.text = "0";
            target.voltaje = 0;
        }
        if (Double.TryParse(Hz.text, out temp))
            target.Hz = temp;
        else
        {
            Hz.text = "0";
            target.Hz = 0;
        }
        if (Double.TryParse(caudal.text, out temp))
            target.caudal = temp;
        else
        {
            caudal.text = "0";
            target.caudal = 0;
        }
        target.sistema = sistema.value == 1;
    }
    public void ChangeTipoEquipo()
    {
        target.SetTipoEsp(tipoEsp.options[tipoEsp.value].text);
    }
    public void ChangeEnfriamiento()
    {
        if (Double.TryParse(enfEntrada1.text, out double temp))
            target.enfEntrada1 = temp;
        else
        {
            enfEntrada1.text = target.enfEntrada1 + "";
            target.enfEntrada1 = 0;
        }
        if (Double.TryParse(enfEntrada2.text, out temp))
            target.enfEntrada2 = temp;
        else
        {
            enfEntrada2.text = target.enfEntrada2 + "";
            target.enfEntrada2 = 0;
        }

        if (Double.TryParse(enfSalida1.text, out temp))
            target.enfSalida1 = temp;
        else
        {
            enfSalida1.text = target.enfSalida1 + "";
            target.enfSalida1 = 0;
        }
        if (Double.TryParse(enfSalida2.text, out temp))
            target.enfSalida2 = temp;
        else
        {
            enfSalida2.text = target.enfSalida2 + "";
            target.enfSalida2 = 0;
        }
    }
    public void ToggleEnfriamiento(Toggle tg)
    {
        if (antiFlow)
            return;
        antiFlow = true;
        ESensible.interactable = !tg.Equals(ES);
        ELatente.interactable = !tg.Equals(EL);
        ETotal.interactable = !tg.Equals(ET);
        ES.interactable = !tg.Equals(ES);
        EL.interactable = !tg.Equals(EL);
        ET.interactable = !tg.Equals(ET);
        ES.isOn = tg.Equals(ES);
        EL.isOn = tg.Equals(EL);
        ET.isOn = tg.Equals(ET);
        antiFlow = false;
    }
    public void ToggleCalentamiento(Toggle tg)
    {
        if (antiFlow)
            return;
        antiFlow = true;
        CSensible.interactable = !tg.Equals(CS);
        CLatente.interactable = !tg.Equals(CL);
        CTotal.interactable = !tg.Equals(CT);
        CS.interactable = !tg.Equals(CS);
        CL.interactable = !tg.Equals(CL);
        CT.interactable = !tg.Equals(CT);
        CS.isOn = tg.Equals(CS);
        CL.isOn = tg.Equals(CL);
        CT.isOn = tg.Equals(CT);
        antiFlow = false;
    }
    public void ChangeCCalentamiento()
    {
        if (Double.TryParse(CSensible.text,out double temp))
            target.CSensible = temp;
        else
        {
            CSensible.text = "0";
            target.CSensible = 0;
        }
        if (Double.TryParse(CLatente.text,out temp))
            target.CLatente = temp;
        else
        {
            CLatente.text = "0";
            target.CLatente = 0;
        }
        if (!Double.TryParse(CTotal.text,out temp))
            CTotal.text = "0";
        if (CS.isOn)
        {
            target.CSensible = temp - target.CLatente;
            CSensible.text = target.CSensible + "";
        }
        else if (CL.isOn)
        {
            target.CLatente = temp - target.CSensible;
            CLatente.text = target.CLatente + "";
        }
        else
            CTotal.text = (target.CSensible + target.CLatente) + "";
        CambioPotencia(true);
    }
    public void ChangeCEnfriamiento()
    {
        if (Double.TryParse(ESensible.text,out double temp))
            target.ESensible = temp;
        else
        {
            ESensible.text = "0";
            target.ESensible = 0;
        }
        if (Double.TryParse(ELatente.text,out temp))
            target.ELatente = temp;
        else
        {
            ELatente.text = "0";
            target.ELatente = 0;
        }
        if (!Double.TryParse(ETotal.text,out temp))
            ETotal.text = "0";
        if (ES.isOn)
        {
            target.ESensible = temp - target.ELatente;
            ESensible.text = target.ESensible + "";
        }
        else if (EL.isOn)
        {
            target.ELatente = temp - target.ESensible;
            ELatente.text = target.ELatente + "";
        }
        else
            ETotal.text = (target.ESensible + target.ELatente) + "";
    }

    /// <summary>
    /// Obtiene los valores del equipo y los pone en el canvas
    /// </summary>
    public void Exploit()
    {
        if (target == null)
            return;
        codigo.text = target.codigo;
        if (target.calculo)
            calculo.value = 1;
        else
            calculo.value = 0;
        tipo.value = target.tipo;

        velocidadIny.text = "" + target.velocidadIny;
        velocidadExt.text = "" + target.velocidadExt;
        porcentajeIny.text = "" + target.porcentajeIny;
        porcentajeExt.text = "" + target.porcentajeExt;

        if (target.potencia < 0)
            potencia.text = target.getAutoPotencia() + "";
        else
            potencia.text = "" + target.potencia;
        espPotencia.isOn = target.potencia < 0;
        if (target.sistema)
            sistema.value = 1;
        else
            sistema.value = 0;
        voltaje.text = target.voltaje + "";
        Hz.text = target.Hz + "";
        caudal.text = target.caudal + "";
        //caution: el tipo de sistema es algo complicado, por el hecho que lo antiguo viene puesto.... y algo mas
        tipoEsp.value = tipoEsp.options.FindIndex(option => option.text == target.GetTipoEsp());

        enfEntrada1.text = target.enfEntrada1 + "";
        enfEntrada2.text = target.enfEntrada2 + "";
        enfSalida1.text = target.enfSalida1 + "";
        enfSalida2.text = target.enfSalida2 + "";

        CSensible.text = target.CSensible + "";
        CLatente.text = target.CLatente + "";
        CTotal.text = (target.CSensible + target.CLatente) + "";
        ESensible.text = target.ESensible + "";
        ELatente.text = target.ELatente + "";
        ETotal.text = (target.ESensible + target.ELatente) + "";

        ToggleEnfriamiento(ET);
        ToggleCalentamiento(CT);

        Debug.Log("Exploited");
    }
    public void Close()
    {
        if (controlador != null)
            controlador.SetActive(true);
        this.gameObject.SetActive(false);
    }
}