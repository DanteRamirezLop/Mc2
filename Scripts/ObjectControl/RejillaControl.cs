using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejillaControl : ObjectControlMain
{
    public Rejilla rejilla;
    public GameObject caja;
    public GameObject semicaja;
    private GameObject colision;
    private float cachedAncho;
    private void OnEnable()
    {
        colision = new GameObject("colision");
        colision.AddComponent(typeof(MiniColision));
        colision.GetComponent<MiniColision>().SetConexion(0);
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

    public override double getAncho(GameObject rebote)
    {
        if (this.atreferencia.TryGetComponent(typeof(ObjectControlMain), out Component c))
        {
            if (((ObjectControlMain)c).getAncho(this.gameObject) > 0)
            {
                return ((ObjectControlMain)c).getAncho(this.gameObject);
            }
        }
        if (this.adreferencia == rebote)
            return 6;
        if (this.adreferencia.TryGetComponent(typeof(ObjectControlMain), out Component d))
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
        if (this.adreferencia == rebote)
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
        return this.transform.position + this.transform.forward * this.cachedAncho /2;
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
        adreferencia = refer;
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        ObjectControlMain cached = refer.GetComponent<ObjectControlMain>();
        cached.setAdReference(this.gameObject);
        cachedAncho = cached.getPAncho();
        this.transform.localScale = new Vector3(cached.getPAncho(), cached.getPAlto(), cached.getPAncho());
        PositionFromReference();
        dependant = refer.GetComponent<ObjectControlMain>().getTipo() == 0 || refer.GetComponent<ObjectControlMain>().dependant;
        ReDoPosition(cached.getPAncho());
    }
    private void ReDoPosition(float ancho)
    {
        if (atreferencia.GetComponent<ObjectControlMain>().getTipo() == 3) {
            this.transform.Rotate(new Vector3(-90, 0, 0));
            this.caja.SetActive(false);
            this.semicaja.SetActive(true);
        }
        else
        {
            this.transform.Translate(Vector3.forward * ancho / 2);
            this.caja.SetActive(true);
            this.semicaja.SetActive(false);
        }
    }

    protected override void ColliderConnectState()
    {
        if (atreferencia.GetComponent<ObjectControlMain>().getTipo() == 3)
            colision.SetActive(false);
        else
        {
            colision.GetComponent<BoxCollider>().size = new Vector3(1, 1, 0.5f);
            colision.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0.75f);
        }
    }

    protected override void ColliderInspectState()
    {
        colision.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
    }

    public override void PulsoRedimension()
    {
        PositionFromReference();
        ObjectControlMain cached = atreferencia.GetComponent<ObjectControlMain>();
        this.transform.localScale = new Vector3(cached.getPAncho(), cached.getPAlto(), cached.getPAncho());
        ReDoPosition(cached.getPAncho());
        if (this.adreferencia != null)
        {
            this.adreferencia.GetComponent<ObjectControlMain>().PulsoRedimension();
        }
        if (cached.dependant)
        {
            cached.PulsoRedimension();
        }
    }
}
