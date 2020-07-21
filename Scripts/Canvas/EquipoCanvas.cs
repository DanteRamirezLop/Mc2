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
    public InputField ESensible;
    public InputField ELatente;
    public InputField caudal;
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
        target.velocidadIny = Double.Parse(velocidadIny.text);
        target.velocidadExt = Double.Parse(velocidadExt.text);
        target.porcentajeIny = Double.Parse(porcentajeIny.text);
        target.porcentajeExt = Double.Parse(porcentajeExt.text);
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
            target.potencia = Double.Parse(potencia.text);
            espPotencia.isOn = false;
        }
    }
    public void CambioEsp()
    {
        target.voltaje = Double.Parse(voltaje.text);
        target.sistema = sistema.value == 1;
        target.Hz = Double.Parse(Hz.text);
        target.caudal = Double.Parse(caudal.text);
    }
    public void ChangeTipoEquipo()
    {
        target.SetTipoEsp(tipoEsp.options[tipoEsp.value].text);
    }
    public void ChangeEnfriamiento()
    {
        target.enfEntrada1 = Double.Parse(enfEntrada1.text);
        target.enfEntrada2 = Double.Parse(enfEntrada2.text);
        target.enfSalida1 = Double.Parse(enfSalida1.text);
        target.enfSalida2 = Double.Parse(enfSalida2.text);
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
        ESensible.text = target.ESensible + "";
        ELatente.text = target.ELatente + "";

        Debug.Log("Exploited");
    }
}