using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControlMain : MonoBehaviour
{
    public int id;
    public int conexion = 0;
    public GameObject atreferencia; //referencia atras, a quien esta conectado este item
    public GameObject adreferencia; //referencia adelante, dejar en desuso para las uniones multiples
    protected double pulgadaAmetro(double pulgada)
    {
        return pulgada / 39.37;
    }
    protected void PositionFromReference()
    {
        this.transform.position = atreferencia.GetComponent<ObjectControlMain>().getUbi(conexion);
    }
    public abstract void SetReferencia(GameObject refer);
    public abstract void setAdReference(GameObject refer);
    public abstract double getAncho();
    public abstract double getAlto();
    public abstract Vector3 getUbi(int target);
    public abstract Quaternion getRotation(int target);
    public void setId(int id)
    {
        this.id = id;
    }
    public int getId()
    {
        return this.id;
    }
}
