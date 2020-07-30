using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionControl : ObjectControlMain
{
    private UnionMesh mesh;
    public double anchopr;
    public double altopr;
    public GameObject[] colisiones;
    public GameObject colMain;
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
                return this.transform.rotation * Quaternion.Euler(-90, 0, 0);
            case 4:
                return this.transform.rotation * Quaternion.Euler(90, 0, 0);
            default:
                return this.transform.rotation;
        }
    }

    public override Vector3 getUbi(int target)
    {
        return this.colisiones[target].transform.position;
    }

    public override void PulsoColision(bool modo)
    {
        ChangeColliderState(modo);
        foreach (var pulsar in referencias)
        {
            if (pulsar != null)
                pulsar.GetComponent<ObjectControlMain>().PulsoColision(modo);
        }
    }
    public override void setAdReference(GameObject refer)
    {
        int con = refer.GetComponent<ObjectControlMain>().conexion;
        referencias[con] = refer;
        Debug.Log("alto: " + getPAlto() + " ancho: " + getPAncho());
        this.mesh.Change(getPAncho(), getPAlto());
        ChangeColision();
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        Debug.Log("alto: " + getPAlto() + " ancho: " + getPAncho());
        this.mesh.Change(getPAncho(), getPAlto());
        ChangeColision();
        PositionFromReference();
    }

    protected override void ColliderConnectState()
    {
        for (int i = 0; i < 5; i++)
        {
            this.colisiones[i].SetActive(this.referencias[i] == null);
            this.colisiones[i].GetComponent<BoxCollider>().size = mesh.GetMeshSize();
        }
        this.colMain.SetActive(false);
    }

    protected override void ColliderInspectState()
    {
        foreach (var col in this.colisiones)
        {
            col.SetActive(false);
        }
        this.colMain.SetActive(true);
    }

    private void ChangeColision()
    {
        this.colisiones[0].transform.localPosition = new Vector3(getPAncho() / 2, 0, getPAncho() / 2);
        this.colisiones[1].transform.localPosition = new Vector3(0, 0, getPAncho());
        this.colisiones[2].transform.localPosition = new Vector3(getPAncho() / -2, 0, getPAncho() / 2);
        this.colisiones[3].transform.localPosition = new Vector3(0, getPAlto() / 2, getPAncho() / 2);
        this.colisiones[4].transform.localPosition = new Vector3(0, getPAlto() / -2, getPAncho() / 2);

        this.colMain.transform.localPosition = mesh.GetMeshCenter();
        this.colMain.GetComponent<BoxCollider>().size = mesh.GetMeshSize();
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

        this.colMain = new GameObject("colisionM");

        foreach (var col in colisiones)
        {
            col.transform.SetParent(this.transform);
            col.AddComponent(typeof(BoxCollider));
            col.AddComponent(typeof(MiniColision));
        }
        colMain.transform.SetParent(this.transform);
        colMain.AddComponent(typeof(BoxCollider));
        colMain.AddComponent(typeof(MiniColision));

        for (int i = 0; i < 5; i++)
            this.colisiones[i].GetComponent<MiniColision>().SetConexion(i);
        ColliderInspectState();
    }

    public override int getTipo()
    {
        return 3;
    }
}
