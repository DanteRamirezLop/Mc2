using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejillaControl : ObjectControlMain
{
    public Rejilla rejilla;
    private GameObject colision;
    private void OnEnable()
    {
        colision = new GameObject("colision");
        colision.transform.SetParent(this.transform);
        colision.transform.localPosition = Vector3.zero;
        colision.AddComponent(typeof(BoxCollider));
        colision.GetComponent<BoxCollider>().size = new Vector3(1,1,1);
    }
    public override double CFMreal()
    {
        return rejilla.cfm;
    }

    public override void ChangeLayer(int layer)
    {
        colision.layer = layer;
    }

    public override double getAncho()
    {
        if (this.atreferencia.TryGetComponent(typeof(ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAncho() > 0)
            {
                return ((ObjectControlMain)c).getAncho();
            }
        }
        if (this.adreferencia.TryGetComponent(typeof(ObjectControlMain), out Component d))
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

    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override int getTipo()
    {
        return 4;
    }

    public override Vector3 getUbi(int target)
    {
        return this.transform.position;
    }

    public override void InitOrder()
    {
        if (DatosScena.Rejilla == null)
            DatosScena.Rejilla = new List<Rejilla>();
        this.rejilla = new Rejilla();
        DatosScena.Rejilla.Add(this.rejilla);
    }

    public override void setAdReference(GameObject refer)
    {
        throw new System.NotImplementedException();
    }

    public override void SetReferencia(GameObject refer)
    {
        throw new System.NotImplementedException();
    }

    protected override void ColliderConnectState()
    {
        throw new System.NotImplementedException();
    }

    protected override void ColliderInspectState()
    {
        colision.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
    }
}
