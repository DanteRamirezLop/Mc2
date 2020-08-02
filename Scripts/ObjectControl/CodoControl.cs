using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoControl : ObjectControlMain
{
    private CodoMesh mesh;
    public Vector2 angulo;
    public double anchopr;
    public double altopr;
    private Multiple codo;


    // Start is called before the first frame update
    void OnEnable()
    {
        if (!TryGetComponent(typeof (CodoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(CodoMesh));
        }
        mesh = GetComponent<CodoMesh>();
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

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        PositionFromReference();
        if (atreferencia != null)
        {
            Debug.Log("got it");
            angulo = new Vector2(90, 0);
            this.mesh.Change(angulo, getPAncho(), getPAlto());
        }
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
        //this.mesh.Change(angulo, getPAncho(), getPAlto());
    }

    protected override void ColliderInspectState()
    {
        GetComponent<CodoMesh>().ParaInspector();
    }

    protected override void ColliderConnectState()
    {
        GetComponent<CodoMesh>().ParaUnir();
    }

    public override void ChangeLayer(int layer)
    {
        this.mesh.ChangeLayer(layer);
    }

    public override int getTipo()
    {
        return 2;
    }

    public override double CFMreal()
    {
        if (this.adreferencia != null)
            return adreferencia.GetComponent<ObjectControlMain>().CFMreal();
        else
            return 0;
    }

    public override void InitOrder()
    {
        if (DatosScena.Multiple == null)
            DatosScena.Multiple = new List<Multiple>();
        this.codo = new Multiple();
        DatosScena.Multiple.Add(codo);
    }
}
