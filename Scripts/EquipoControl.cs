using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipoControl : ObjectControlMain
{
    public Vector3 offset;
    public override double getAlto()
    {
        return 0;
    }

    public override double getAncho()
    {
        return 0;
    }

    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        return this.transform.position;
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }

    public override void SetReferencia(GameObject refer)
    {
        Debug.Log("Nope");
    }
}
