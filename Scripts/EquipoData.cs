using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EquipoData
{
    public Mesh mesh;
    public Vector3[] offsets;
    public Vector3[] rotation;
    public Material material;
    public Texture textura;
    public string nombre;

    public Quaternion[] GetRotations()
    {
        Quaternion[] ret = new Quaternion[rotation.Length];
        for (int i = 0; i < rotation.Length; i++)
        {
            ret[i] = Quaternion.Euler(rotation[i]);
        }
        material.mainTexture = textura;
        return ret;
    }
}
