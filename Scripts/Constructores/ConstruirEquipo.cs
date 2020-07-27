using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConstruirEquipo : MonoBehaviour{}

[System.Serializable]
public class Equipo
{
    public string id;
    public string idProyecto;
    public string codigo;
    public string tipo;
    public string velocidadIny;
    public string velocidadExt;
    public string porcentajeIny;
    public string porcentajeExt;
    public string calculo;
    public string vinculo;
    public string nivel;
    public string idAmbiente;
    public string ccx;
    public string ccy;
    public string ccz;
    //-----
    public string idEquipoV;
    public string potencia;
    public string voltaje;
    public string sistema;
    public string enfEntrada1;
    public string enfEntrada2;
    public string enfSalida1;
    public string enfSalida2;
    public string tipo2;//cambien tipo por tipo2
    public string Hz;
    public string CSensible;
    public string CLatente;
    public string ESensible;
    public string ELatente;
    public string caudal;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}"
            ,id, idProyecto, codigo, tipo, velocidadIny, velocidadExt, porcentajeIny, porcentajeExt, calculo, vinculo, nivel, idAmbiente, ccx, ccy, ccz, idEquipoV, potencia, voltaje, sistema, enfEntrada1, enfEntrada2, enfSalida1, enfSalida2, tipo2, Hz, CSensible, CLatente, ESensible, ELatente, caudal);
    }//cambien tipo por tipo2
}

[System.Serializable]
public class ListaEquipo
{
    public List<Equipo> equipos;

    /// <summary>
    /// Asigna a la variable'datos' todos los datos de la tabla 
    /// </summary>
    /// <param name="datos"></param> variable por valor
    public void CargarEquipo(List<string> datos)
    {
        foreach (Equipo equipo in equipos)
        {
            datos.Add(equipo.id);
            datos.Add(equipo.idProyecto);
            datos.Add(equipo.codigo);
            datos.Add(equipo.tipo);
            datos.Add(equipo.velocidadIny);
            datos.Add(equipo.velocidadExt);
            datos.Add(equipo.porcentajeIny);
            datos.Add(equipo.porcentajeExt);
            datos.Add(equipo.calculo);
            datos.Add(equipo.vinculo);
            datos.Add(equipo.nivel);
            datos.Add(equipo.idAmbiente);
            datos.Add(equipo.ccx);
            datos.Add(equipo.ccy);
            datos.Add(equipo.ccz);
            //------
            datos.Add(equipo.idEquipoV);
            datos.Add(equipo.potencia);
            datos.Add(equipo.voltaje);
            datos.Add(equipo.sistema);
            datos.Add(equipo.enfEntrada1);
            datos.Add(equipo.enfEntrada2);
            datos.Add(equipo.enfSalida1);
            datos.Add(equipo.enfSalida2);
            datos.Add(equipo.tipo2); //cambien tipo por tipo2
            datos.Add(equipo.Hz);
            datos.Add(equipo.CSensible);
            datos.Add(equipo.CLatente);
            datos.Add(equipo.ESensible);
            datos.Add(equipo.ELatente);
            datos.Add(equipo.caudal);


        }
    }
}