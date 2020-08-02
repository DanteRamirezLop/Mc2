using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejillaControl : ObjectControlMain
{
    public Rejilla rejilla;
    public override double CFMreal()
    {
        return rejilla.cfm;
    }

    public override void ChangeLayer(int layer)
    {
        throw new System.NotImplementedException();
    }

    public override double getAlto()
    {
        throw new System.NotImplementedException();
    }

    public override double getAncho()
    {
        throw new System.NotImplementedException();
    }

    public override Quaternion getRotation(int target)
    {
        throw new System.NotImplementedException();
    }

    public override int getTipo()
    {
        throw new System.NotImplementedException();
    }

    public override Vector3 getUbi(int target)
    {
        throw new System.NotImplementedException();
    }

    public override void InitOrder()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }
}
