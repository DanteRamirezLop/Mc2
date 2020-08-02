using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EquipoControl : ObjectControlMain
{
    public Vector3[] offset;
    private GameObject eqMesh;
    public Quaternion[] rotacion;
    private GameObject[] colision;
    private GameObject[] adRefers;
    public GameObject coleccionRefer;
    private Mesh lmesh;

    public Equipo equip;
    //parte de la tabla equipov
    //parte de la tabla equipoesp

    void OnEnable()
    {
        adRefers = new GameObject[2];
        offset = new Vector3[2];
        this.eqMesh = new GameObject("Mesh");
        eqMesh.transform.SetParent(this.transform);
        eqMesh.transform.localPosition = Vector3.zero;
        //eqMesh.transform.localRotation = Quaternion.Euler(-90, 90, 90);
        if (!TryGetComponent(typeof(MeshFilter), out Component c))
        {
            eqMesh.AddComponent(typeof(MeshFilter));
        }
        if (!TryGetComponent(typeof(MeshRenderer), out Component d))
        {
            eqMesh.AddComponent(typeof(MeshRenderer));
        }
        lmesh = eqMesh.GetComponent<MeshFilter>().mesh;
        colision = new GameObject[2];
        colision[0] = new GameObject("colision");
        colision[0].transform.SetParent(this.transform);
        colision[0].AddComponent(typeof(BoxCollider));
        colision[0].AddComponent(typeof(MiniColision));
        colision[0].GetComponent<MiniColision>().SetConexion(0);

        colision[1] = new GameObject("colision2");
        colision[1].transform.SetParent(this.transform);
        colision[1].AddComponent(typeof(BoxCollider));
        colision[1].AddComponent(typeof(MiniColision));
        colision[1].GetComponent<MiniColision>().SetConexion(1);
        equip.tipo2 = "";
        CambiarMesh();
        ColliderInspectState();
    }
    public override void InitOrder()
    {
        equip = new Equipo();
        DatosScena.Equipo = new List<Equipo>();
        DatosScena.Equipo.Add(equip);
        //DatosScena.Equipo[0].ccx = 1;
    }
    public override Quaternion getRotation(int target)
    {
        if (target == 0)
            return this.transform.rotation;
        else
            return this.transform.rotation * Quaternion.Euler(0,180,0);
    }

    public override Vector3 getUbi(int target)
    {
        if (target == 0)
            return this.transform.position + offset[0];
        else
            return this.transform.position + offset[1];
    }

    public override void setAdReference(GameObject refer)
    {
        int con = refer.GetComponent<ObjectControlMain>().conexion;
        adRefers[con] = refer;
    }

    public override void SetReferencia(GameObject refer)
    {
        Debug.Log("Nope");
    }
    public override double getAlto()
    {
        return 6;
    }

    public override double getAncho()
    {
        return 6;
    }

    protected override void ColliderInspectState()
    {
        colision[0].transform.localPosition = Vector3.zero;
        colision[0].transform.localRotation = eqMesh.transform.localRotation;
        colision[0].GetComponent<BoxCollider>().center = eqMesh.GetComponent<MeshFilter>().mesh.bounds.center;
        colision[0].GetComponent<BoxCollider>().size = eqMesh.GetComponent<MeshFilter>().mesh.bounds.size;
        colision[1].SetActive(false);
    }

    protected override void ColliderConnectState()
    {
        colision[0].transform.localPosition = offset[0];
        colision[0].transform.localRotation = Quaternion.identity;
        colision[0].GetComponent<BoxCollider>().center = Vector3.zero;
        colision[0].GetComponent<BoxCollider>().size = new Vector3(2, 2, 1);
        colision[0].SetActive(this.adRefers[0] == null);
        if (offset.Length == 2)
        {
            colision[1].transform.localPosition = offset[1];
            colision[1].GetComponent<BoxCollider>().center = Vector3.zero;
            colision[1].GetComponent<BoxCollider>().size = new Vector3(2, 2, 1);
            colision[1].SetActive(this.adRefers[1] == null);
        }
    }

    public override void ChangeLayer(int layer)
    {
        foreach (var col in colision)
        {
            col.layer = layer;
        }
    }
    public override void PulsoColision(bool modo)
    {
        ChangeColliderState(modo);
        foreach (var refe in adRefers)
        {
            if(refe != null)
                refe.GetComponent<ObjectControlMain>().PulsoColision(modo);
        }
    }
    public string GetTipoEsp()
    {
        return this.equip.tipo2;
    }
    public void SetTipoEsp(string tipoEsp)
    {
        this.equip.tipo2 = tipoEsp;
        CambiarMesh();
    }
    public double getAutoPotencia()
    {
        return (equip.CSensible + equip.CLatente) / 11000 ;
    }
    private void CambiarMesh()
    {
        EquipoData x = coleccionRefer.GetComponent<ColeccionEquipo>().GetData(equip.tipo2);
        eqMesh.transform.localRotation = Quaternion.Euler(x.meshRotation);
        lmesh.vertices = x.mesh.vertices;
        lmesh.triangles = x.mesh.triangles;
        lmesh.uv = x.mesh.uv;
        lmesh.RecalculateBounds();
        offset = x.offsets;
        rotacion = x.GetRotations();
        eqMesh.GetComponent<MeshRenderer>().material = x.material;
    }

    public override int getTipo()
    {
        return 0;
    }

    public override double CFMreal()
    {
        double ret = 0;
        foreach (var item in adRefers)
        {
            if (item != null)
                ret += item.GetComponent<ObjectControlMain>().CFMreal();
        }
        return ret;
    }
}
