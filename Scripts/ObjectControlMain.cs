using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControlMain : MonoBehaviour
{
    public GameObject atreferencia; //referencia atras, a quien esta conectado este item
    public GameObject[] adreferencia; //referencia adelante, a quien tiene conectado este item, en la division pueden ser varios

    public void SetReferencia(GameObject refer) 
    {
        this.atreferencia = refer;
    }
    protected double pulgadaAmetro(double pulgada)
    {
        return pulgada / 39.37;
    }
}
