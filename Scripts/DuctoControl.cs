using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoControl : ObjectControlMain
{
    private DuctoMesh mesh;
    private double alto; //esta en pulgadas
    private double ancho; //esta en pulgadas
    private double longitud; //esta en metros
    private int pass;//si es que se dirige a alguna parte

    public override double getAlto()
    {
        return this.alto;
    }

    public override double getAncho()
    {
        return this.ancho;
    }

    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        Vector3 ret = this.transform.position + this.transform.forward * (float)longitud;
        return ret;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(typeof(DuctoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(DuctoMesh));
        }
        mesh = GetComponent<DuctoMesh>();
    }

    public void Refresh()
    {
        this.mesh.ReCreator((float)longitud);
        this.mesh.ReCreator((float)ancho, (float)alto);
    }
    public void setAlto(double alto)
    {
        this.alto = alto;
    }
    public void setAncho(double ancho)
    {
        this.ancho = ancho;
    }
    public void setLongitud(double longitud)
    {
        this.longitud = longitud;
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        PositionFromReference();
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }
}
