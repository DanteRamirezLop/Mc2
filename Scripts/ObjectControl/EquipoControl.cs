using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EquipoControl : ObjectControlMain
{
    public Vector3 offset;
    private GameObject[] colision;
    //parte de la tabla equipov
    public int idProyecto { get; set; }
    public string codigo { get; set; }
    public int tipo { get; set; } //inyeccion, extraccion, ambos
    public double velocidadIny { get; set; }
    public double velocidadExt { get; set; }
    public double porcentaje { get; set; }
    public bool calculo { get; set; }
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
    public string tipoEsp { get; set; }
    public double Hz { get; set; }
    public double CSensible { get; set; }
    public double CLatente { get; set; }
    public double ESensible { get; set; }
    public double ELatente { get; set; }
    public double caudal { get; set; }

    void Start()
    {
        colision = new GameObject[2];
        colision[0] = new GameObject("colision");
        colision[0].transform.SetParent(this.transform);
        colision[0].AddComponent(typeof(BoxCollider));
        colision[0].AddComponent(typeof(MiniColision));
        ColliderInspectState();
    }
    public override Quaternion getRotation(int target)
    {
        if (target == 0)
            return this.transform.rotation * Quaternion.Euler(0,180,0);
        else
            return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        return this.transform.position + offset;
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
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
        if (TryGetComponent(typeof(MeshFilter), out Component e))
        {
            colision[0].GetComponent<BoxCollider>().center = ((MeshFilter)e).mesh.bounds.center;
            colision[0].GetComponent<BoxCollider>().size = ((MeshFilter)e).mesh.bounds.size;
        }
        else
        {
            colision[0].GetComponent<BoxCollider>().center = this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh.bounds.center;
            colision[0].GetComponent<BoxCollider>().size = this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh.bounds.size;
        }
        if (colision[1] != null)
        {
            colision[1].SetActive(false);
        }
    }

    protected override void ColliderConnectState()
    {
        colision[0].GetComponent<BoxCollider>().center = offset;
        colision[0].GetComponent<BoxCollider>().size = new Vector3(2, 2, 1);
        if (colision[1] != null)
        {
            colision[1].SetActive(true);
        }
    }

    public override void ChangeLayer(int layer)
    {
        foreach (var col in colision)
        {
            col.layer = layer;
        }
    }
}
