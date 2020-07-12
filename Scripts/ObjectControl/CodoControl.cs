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
    public bool reset;
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
        this.mesh.Change(getAncho(), getAlto());
        PositionFromReference();
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }

    protected override void ColliderInspectState()
    {
        throw new NotImplementedException();
    }

    protected override void ColliderConnectState()
    {
        throw new NotImplementedException();
    }

    public override void ChangeLayer(int layer)
    {
        this.gameObject.layer = layer;
    }
}
