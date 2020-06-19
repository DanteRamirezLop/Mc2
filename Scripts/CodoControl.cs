using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoControl : MonoBehaviour
{
    private CodoMesh mesh;
    public GameObject referencia;
    public Vector2 angulopr;
    public double anchopr;
    public double altopr;
    public Boolean reset;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<CodoMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            SetReferencia(null);
            reset = false;
        }
    }
    public void SetReferencia(GameObject refer)
    {
        this.referencia = refer;
        if (this.referencia == null)
        {
            mesh.Change(Vector2.zero, pulgadaAmetro(10), pulgadaAmetro(10));
        }
        else
        {

        }
    }
    private double pulgadaAmetro(double pulgada)
    {
        return pulgada / 39.37;
    }
}
