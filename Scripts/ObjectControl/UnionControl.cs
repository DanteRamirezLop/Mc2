using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionControl : ObjectControlMain
{
    private UnionMesh mesh;
    public double anchopr;
    public double altopr;
    public GameObject[] colisiones;
    private GameObject[] referencias;
    //acerca de la union: 0 derecha, 1 adelante, 2 izquierda, 3 arriba, 4 abajo
    public override void ChangeLayer(int layer)
    {
        foreach (var col in colisiones)
        {
            col.layer = layer;
        }
    }

    public override double getAlto()
    {
        double ret = 6;
        if (this.atreferencia != null)
            if (ret < atreferencia.GetComponent<ObjectControlMain>().getAlto())
                ret = atreferencia.GetComponent<ObjectControlMain>().getAlto();
        foreach (var refer in referencias)
        {
            if (refer != null)
                if (ret < refer.GetComponent<ObjectControlMain>().getAlto())
                    ret = refer.GetComponent<ObjectControlMain>().getAlto();
        }
        return ret;
    }

    public override double getAncho()
    {
        double ret = 6;
        if (this.atreferencia != null)
            if (ret < atreferencia.GetComponent<ObjectControlMain>().getAncho())
                ret = atreferencia.GetComponent<ObjectControlMain>().getAncho();
        foreach (var refer in referencias)
        {
            if (refer != null)
                if (ret < refer.GetComponent<ObjectControlMain>().getAncho())
                    ret = refer.GetComponent<ObjectControlMain>().getAncho();
        }
        return ret;
    }

    public override Quaternion getRotation(int target)
    {
        switch (target)
        {
            case 0:
                return this.transform.rotation * Quaternion.Euler(0, 90, 0);
            case 2:
                return this.transform.rotation * Quaternion.Euler(0, -90, 0);
            case 3:
                return this.transform.rotation * Quaternion.Euler(90, 0, 0);
            case 4:
                return this.transform.rotation * Quaternion.Euler(-90, 0, 0);
            default:
                return this.transform.rotation;
        }
    }

    public override Vector3 getUbi(int target)
    {
        return Locations(target);
    }

    public override void setAdReference(GameObject refer)
    {
        int con = refer.GetComponent<ObjectControlMain>().conexion;
        referencias[con] = refer;
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        PositionFromReference();
    }

    protected override void ColliderConnectState()
    {
        for (int i = 0; i < 5; i++)
        {
            this.colisiones[i].transform.localPosition = Locations(i) - this.transform.position;
            this.colisiones[i].SetActive(this.referencias[i] != null);
        }
    }

    protected override void ColliderInspectState()
    {
        this.colisiones[1].SetActive(false);
        this.colisiones[2].SetActive(false);
        this.colisiones[3].SetActive(false);
        this.colisiones[4].SetActive(false);

        this.colisiones[0].transform.localPosition = Vector3.zero;
        this.colisiones[0].GetComponent<BoxCollider>().size = new Vector3(0,0,0);

    }

    private Vector3 Locations(int con)
    {
        switch (con)
        {
            case 0:
                return this.transform.position + this.transform.right * (float)getAncho() / 2 + this.transform.forward * (float)getAncho() / 2;
            case 2:
                return this.transform.position + this.transform.right * (float)getAncho() / -2 + this.transform.forward * (float)getAncho() / 2;
            case 3:
                return this.transform.position + this.transform.right * (float)getAncho() / 2 + this.transform.forward * (float)getAncho() / 2 + this.transform.up * (float)getAlto() / 2;
            case 4:
                return this.transform.position + this.transform.right * (float)getAncho() / 2 + this.transform.forward * (float)getAncho() / 2 + this.transform.up * (float)getAlto() / 2;
            default:
                return this.transform.position + this.transform.forward * (float)getAncho();
        }
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        this.referencias = new GameObject[5];
        if (!TryGetComponent(typeof(UnionMesh), out Component c))
        {
            gameObject.AddComponent(typeof(UnionMesh));
        }
        mesh = GetComponent<UnionMesh>();
        this.colisiones = new GameObject[5];

        this.colisiones[0] = new GameObject("colision");
        this.colisiones[1] = new GameObject("colision2");
        this.colisiones[2] = new GameObject("colision3");
        this.colisiones[3] = new GameObject("colision4");
        this.colisiones[4] = new GameObject("colision5");
        foreach (var col in colisiones)
        {
            col.AddComponent(typeof(BoxCollider));
            col.AddComponent(typeof(MiniColision));
        }
        for (int i = 0; i < 5; i++)
            this.colisiones[i].GetComponent<MiniColision>().SetConexion(i);
    }

}
