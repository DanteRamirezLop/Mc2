using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoControl : ObjectControlMain
{
    private CodoMesh mesh;
    public Multiple codo;


    // Start is called before the first frame update
    void OnEnable()
    {
        if (!TryGetComponent(typeof (CodoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(CodoMesh));
        }
        mesh = GetComponent<CodoMesh>();
    }

    public override double getAncho(GameObject rebote)
    {
        if (this.atreferencia.TryGetComponent(typeof (ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAncho(this.gameObject) > 0)
            {
                return ((ObjectControlMain)c).getAncho(this.gameObject);
            }
        }
        if (adreferencia == rebote)
            return 6;
        if (this.adreferencia.TryGetComponent(typeof (ObjectControlMain), out Component d))
        {
            if (((ObjectControlMain)d).getAncho(this.gameObject) > 0)
            {
                return ((ObjectControlMain)d).getAncho(this.gameObject);
            }
        }
        return 6;
    }

    public override double getAlto(GameObject rebote)
    {
        if (this.atreferencia.TryGetComponent(typeof(ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAlto(this.gameObject) > 0)
            {
                return ((ObjectControlMain)c).getAlto(this.gameObject);
            }
        }
        if (adreferencia == rebote)
            return 6; 
        if (this.adreferencia.TryGetComponent(typeof(ObjectControlMain), out Component d))
        {
            if (((ObjectControlMain)d).getAlto(this.gameObject) > 0)
            {
                return ((ObjectControlMain)d).getAlto(this.gameObject);
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
        dependant = refer.GetComponent<ObjectControlMain>().getTipo() == 0 || refer.GetComponent<ObjectControlMain>().dependant;
        RefreshB();
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
        codo.giroX = 90;
        codo.giroY = 0;
    }
    /// <summary>
    /// Actualiza el giro
    /// </summary>
    public void RefreshA()
    {
        mesh.Change(new Vector2(codo.giroX, codo.giroY));
    }
    /// <summary>
    /// Actualiza el alto y ancho
    /// </summary>
    public void RefreshB()
    {
        mesh.Change(getPAncho(), getPAlto());
    }

    public override void PulsoRedimension()
    {
        RefreshB();
        PositionFromReference();
        if (this.adreferencia != null)
        {
            this.adreferencia.GetComponent<ObjectControlMain>().PulsoRedimension();
        }
        if (atreferencia.GetComponent<ObjectControlMain>().dependant)
        {
            GetComponent<ObjectControlMain>().PulsoRedimension();
        }
    }

    public override AmbienteControl GetAmbiente()
    {
        return this.atreferencia.GetComponent<ObjectControlMain>().GetAmbiente();
    }
}
