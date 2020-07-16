using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionMesh : MonoBehaviour
{
    private float ultancho;
    private float ultalto;
    private Mesh lmesh;
    public Material mat;
    // Start is called before the first frame update
    void OnEnable()
    {
        ultalto = 0.254f;
        ultancho = 0.254f;
        if (!TryGetComponent(typeof(MeshFilter), out Component c))
        {
            gameObject.AddComponent(typeof(MeshFilter));
        }
        if (!TryGetComponent(typeof(MeshRenderer), out Component d))
        {
            gameObject.AddComponent(typeof(MeshRenderer));
        }
        GetComponent<MeshRenderer>().material = mat;
        lmesh = GetComponent<MeshFilter>().mesh;
        Creator();
    }
    public void Change(float ancho, float alto)
    {
        if (ultancho == ancho && ultalto == alto)
        {
            return;
        }
        ultalto = alto;
        ultancho = ancho;
        ReCrearVertices();
        lmesh.RecalculateBounds();
    }
    private void Creator()
    {
        lmesh.Clear();
        ReCrearVertices();
        CrearTriangulos();
        lmesh.RecalculateBounds();
    }

    private void CrearTriangulos()
    {
        int[] ret = new int[] {
            0,1,2,
            2,1,3,
            1,5,7,
            1,7,3,
            0,2,4,
            2,6,4,
            0,4,5,
            0,5,1,
            2,3,7,
            2,7,6,
            4,6,5,
            5,6,7
        };
        lmesh.triangles = ret;
    }

    private void ReCrearVertices()
    {
        Vector3[] vertex = new Vector3[8];
        vertex[0] = new Vector3(ultancho / -2,ultalto / 2,0);
        vertex[1] = new Vector3(ultancho / 2, ultalto / 2);
        vertex[2] = new Vector3(ultancho / -2, ultalto / -2);
        vertex[3] = new Vector3(ultancho / 2, ultalto / -2);
        vertex[4] = new Vector3(ultancho / -2, ultalto / 2, ultancho);
        vertex[5] = new Vector3(ultancho / 2, ultalto / 2, ultancho);
        vertex[6] = new Vector3(ultancho / -2, ultalto / -2, ultancho);
        vertex[7] = new Vector3(ultancho / 2, ultalto / -2, ultancho);
        lmesh.vertices = vertex;
    }
    public Vector3 GetMeshCenter()
    {
        return this.lmesh.bounds.center;
    }
    public Vector3 GetMeshSize()
    {
        return this.lmesh.bounds.size;
    }
}
