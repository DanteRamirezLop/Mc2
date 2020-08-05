using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Equipo
{
    public int id;
    public int idProyecto;
    public string codigo;
    public int tipo; //inyeccion, extraccion, ambos
    public double velocidadIny;
    public double velocidadExt;
    public double porcentajeIny;
    public double porcentajeExt;
    public bool calculo; //aire acondicionado o ventilacion
    public int vinculo;
    public string nivel;
    public int idAmbiente; 
    public float ccx;
    public float ccy;
    public float ccz;
    //public int idEquipoV;//se repite en id
    public double potencia;
    public double voltaje;
    public bool sistema;
    public double enfEntrada1;
    public double enfEntrada2;
    public double enfSalida1;
    public double enfSalida2;
    public string tipo2;//cambien tipo por tipo2 por que en la tabla equipov ya habia un atributo tipo
    public double Hz;
    public double CSensible;
    public double CLatente;
    public double ESensible;
    public double ELatente;
    public double caudal;
    public bool estado;

    public override string ToString()
    {
        return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}"
            ,id, idProyecto, codigo, tipo, velocidadIny, velocidadExt, porcentajeIny, porcentajeExt, calculo, vinculo, nivel,idAmbiente, ccx, ccy, ccz, potencia, voltaje, sistema, enfEntrada1, enfEntrada2, enfSalida1, enfSalida2, tipo2, Hz, CSensible, CLatente, ESensible, ELatente, caudal,estado);
    }
}

[System.Serializable]
public class ListaEquipo
{
    public List<Equipo> equipos;

    /// <summary>
    /// Asigna a la variable'datos' todos los datos de la tabla 
    /// </summary>
    /// <param name="datos"></param> variable por valor
    public void CargarEquipo(List<Equipo> datos)
    {
        foreach (Equipo atributo in equipos)
        {
            datos.Add(atributo);
        }
    }
}