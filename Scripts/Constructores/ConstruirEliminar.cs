using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class clsEliminar
{
    public int id;
    public string nom_Tabla;

    public override string ToString()
    {
        return string.Format("{0},{1}", id, nom_Tabla);
    }
}
