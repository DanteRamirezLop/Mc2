using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControlMain : MonoBehaviour
{
    public GameObject atreferencia; //referencia atras, a quien esta conectado este item
    public GameObject adreferencia; //referencia adelante, dejar en desuso para las uniones multiples

    public void SetReferencia(GameObject refer) 
    {
        this.atreferencia = refer;
    }
    protected double pulgadaAmetro(double pulgada)
    {
        return pulgada / 39.37;
    }
    public void setAdReference(GameObject refer)
    {
        this.adreferencia = refer;
    }
    public abstract double getAncho();
    public abstract double getAlto();
    public abstract Vector3 getUbi(int target);
    public abstract Quaternion getRotation(int target);
}
