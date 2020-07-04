using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoControl : ObjectControlMain
{
    private DuctoMesh mesh;
    private double alto; //esta en pulgadas
    private double ancho; //esta en pulgadas
    private double longitud; //esta en metros

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
}
