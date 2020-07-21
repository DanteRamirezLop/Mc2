using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EquipoControl : ObjectControlMain
{
    public Vector3[] offset;
    public Quaternion[] rotacion;
    private GameObject[] colision;
    private GameObject[] adRefers;
    public GameObject coleccionRefer;
    private Mesh lmesh;
    //parte de la tabla equipov
    public int idProyecto { get; set; }
    public string codigo { get; set; }
    public int tipo { get; set; } //inyeccion, extraccion, ambos
    public double velocidadIny { get; set; }
    public double velocidadExt { get; set; }
    public double porcentajeIny { get; set; }
    public double porcentajeExt { get; set; }
    public bool calculo { get; set; } //aire acondicionado o ventilacion
    public int vinculo { get; set; }
    public string nivel { get; set; }
    public int idAmbiente { get; set; }
    //parte de la tabla equipoesp
    public double potencia { get; set; }
    public double voltaje { get; set; }
    public bool sistema { get; set; }
    public double enfEntrada1 { get; set; }
    public double enfEntrada2 { get; set; }
    public double enfSalida1 { get; set; }
    public double enfSalida2 { get; set; }
    private string tipoEsp;
    public double Hz { get; set; }
    public double CSensible { get; set; }
    public double CLatente { get; set; }
    public double ESensible { get; set; }
    public double ELatente { get; set; }
    public double caudal { get; set; }

    void OnEnable()
    {
        adRefers = new GameObject[2];
        offset = new Vector3[2];
        if (!TryGetComponent(typeof(MeshFilter), out Component c))
        {
            gameObject.AddComponent(typeof(MeshFilter));
        }
        if (!TryGetComponent(typeof(MeshRenderer), out Component d))
        {
            gameObject.AddComponent(typeof(MeshRenderer));
        }
        lmesh = GetComponent<MeshFilter>().mesh;
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
        tipoEsp = "";
        CambiarMesh();
        ColliderInspectState();
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
        return 0;
    }

    public override double getAncho()
    {
        return 0;
    }

    protected override void ColliderInspectState()
    {
        colision[0].transform.localPosition = Vector3.zero;
        colision[0].GetComponent<BoxCollider>().center = GetComponent<MeshFilter>().mesh.bounds.center;
        colision[0].GetComponent<BoxCollider>().size = GetComponent<MeshFilter>().mesh.bounds.size;
        colision[1].SetActive(false);
    }

    protected override void ColliderConnectState()
    {
        colision[0].transform.localPosition = offset[0];
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
        return this.tipoEsp;
    }
    public void SetTipoEsp(string tipoEsp)
    {
        this.tipoEsp = tipoEsp;
        CambiarMesh();
    }
    public double getAutoPotencia()
    {
        return (CSensible + CLatente) / 11000 ;
    }
    private void CambiarMesh()
    {
        EquipoData x = coleccionRefer.GetComponent<ColeccionEquipo>().GetData(tipoEsp);
        lmesh.vertices = x.mesh.vertices;
        lmesh.triangles = x.mesh.triangles;
        lmesh.uv = x.mesh.uv;
        lmesh.RecalculateBounds();
        offset = x.offsets;
        rotacion = x.GetRotations();
        GetComponent<MeshRenderer>().material = x.material;
    }
}
