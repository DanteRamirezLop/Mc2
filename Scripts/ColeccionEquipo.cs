using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColeccionEquipo : MonoBehaviour
{
    public EquipoData[] equipos;

    internal EquipoData GetData(string tipoEsp)
    {
        for (int i = 0; i < equipos.Length; i++)
        {
            if (tipoEsp.Equals(equipos[i].nombre))
            {
                return equipos[i];
            }
        }
        return equipos[0];
    }
}
