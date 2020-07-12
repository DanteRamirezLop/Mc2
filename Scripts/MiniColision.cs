using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniColision : MonoBehaviour
{
    private int conexion = 0;
    public void SetConexion(int c)
    {
        conexion = c;
    }
    public int GetConexion()
    {
        return this.conexion;
    }
    public GameObject GetParent()
    {
        return this.transform.parent.gameObject;
    }

}
