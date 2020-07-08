using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoControl : ObjectControlMain
{
    private CodoMesh mesh;
    public Vector2 angulo;
    public double anchopr = 6;
    public double altopr = 6;
    public Boolean reset;
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(typeof (CodoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(CodoMesh));
        }
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
        if (this.atreferencia != null)
        {
            mesh.Change(angulo, pulgadaAmetro(anchopr), pulgadaAmetro(altopr));
        }
        else
        {
            mesh.Change(Vector2.zero, pulgadaAmetro(10), pulgadaAmetro(10));
        }
    }

    public override double getAncho()
    {
        if (this.atreferencia.TryGetComponent(typeof (ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAncho() > 0)
            {
                return ((ObjectControlMain)c).getAncho();
            }
        }
        if (this.adreferencia.TryGetComponent(typeof (ObjectControlMain), out Component d))
        {
            if (((ObjectControlMain)d).getAncho() > 0)
            {
                return ((ObjectControlMain)d).getAncho();
            }
        }
        return 6;
    }

    public override double getAlto()
    {
        if (this.atreferencia.TryGetComponent(typeof(ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAlto() > 0)
            {
                return ((ObjectControlMain)c).getAlto();
            }
        }
        if (this.adreferencia.TryGetComponent(typeof(ObjectControlMain), out Component d))
        {
            if (((ObjectControlMain)d).getAlto() > 0)
            {
                return ((ObjectControlMain)d).getAlto();
            }
        }
        return 6;
    }

    public override Vector3 getUbi(int target)
    {
        return mesh.getUltPosition();
    }

    public override Quaternion getRotation(int target)
    {
        return mesh.getUltRotation();
    }
}
