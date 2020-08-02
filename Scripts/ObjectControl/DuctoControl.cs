using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoControl : ObjectControlMain
{
    private DuctoMesh mesh;

    public Ducto ducto;
    private AmbienteControl amb; //solo si hay un paso
    //solo para formulas, el usuario las cambia

    public override double getAlto()
    {
        return this.ducto.dimA;
    }

    public override double getAncho()
    {
        return this.ducto.dimB;
    }

    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        Vector3 ret = this.transform.position + this.transform.forward * (float)ducto.longitud;
        return ret;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ducto.dimA = 6;
        ducto.dimB = 6;
        ducto.longitud = 2;
        if (!TryGetComponent(typeof(DuctoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(DuctoMesh));
        }
        mesh = GetComponent<DuctoMesh>();
    }

    public void Refresh()
    {
        this.mesh.ReCreator((float)ducto.longitud);
        this.mesh.ReCreator(getPAncho(), getPAlto());
        Debug.Log("an: " + getPAncho() + "al:" + getPAlto());
    }
    public void setAlto(double alto)
    {
        ducto.dimA = alto;
    }
    public void setAncho(double ancho)
    {
        ducto.dimB = ancho;
    }
    public void setLongitud(double longitud)
    {
        ducto.longitud = longitud;
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        PositionFromReference();
        Refresh();
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }

    protected override void ColliderInspectState()
    {
        mesh.ParaInspector();
    }

    protected override void ColliderConnectState()
    {
        mesh.ParaUnir(this.adreferencia == null);
    }

    public override void ChangeLayer(int layer)
    {
        this.mesh.ChangeLayer(layer);
    }

    public override int getTipo()
    {
        return 1;
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
        if (DatosScena.Ducto == null)
            DatosScena.Ducto = new List<Ducto>();
        this.ducto = new Ducto();
        DatosScena.Ducto.Add(this.ducto);
    }
}
