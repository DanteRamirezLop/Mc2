using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoControl : ObjectControlMain
{
    private DuctoMesh mesh;

    private double longitud = 1; //esta en metros
    private int paso { get; set; }//a que ambiente se dirige, tiene un tipo distinto de guardado
    private bool dibujar { get; set; } //si en autocad se dibuja, usualmente en false
    //nota, las coordenadas van directo al transform
    private bool tipo { get; set; } //0 inyeccion 1 extraccion
    private string nombre { get; set; }
    private double alto { get; set; } //esta en pulgadas, es DimA
    private double ancho { get; set; } //esta en pulgadas, es DimB
    //solo para formulas, el usuario las cambia
    private double damAb100 { get; set; }
    private double damCer10 { get; set; } 
    private double damCer50 { get; set; }
    private double tranRec { get; set; }
    private double conVen { get; set; }
    private double lumAli { get; set; }
    //Fin


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
    void OnEnable()
    {
        alto = 6;
        ancho = 6;
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
}
