using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoControl : ObjectControlMain
{
    private CodoMesh mesh;
    public Vector2 angulopr;
    public double anchopr = 6;
    public double altopr = 6;
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
    public new void SetReferencia(GameObject refer)
    {
        base.SetReferencia(refer);
        this.atreferencia = refer;
        if (this.atreferencia == null)
        {
            mesh.Change(angulopr, pulgadaAmetro(anchopr), pulgadaAmetro(altopr));
            //mesh.Change(Vector2.zero, pulgadaAmetro(10), pulgadaAmetro(10));
        }
        else
        {

        }
    }
}
