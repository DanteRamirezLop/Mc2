using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AmbienteMesh : MonoBehaviour
{
    private Vector2[] coordenadas;
    private double ultAlto;
    private Mesh lmesh;
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(typeof(MeshFilter), out Component c))
        {
            gameObject.AddComponent(typeof(MeshFilter));
        }
        if (!TryGetComponent(typeof(MeshRenderer), out Component d))
        {
            gameObject.AddComponent(typeof(MeshRenderer));
        }
        lmesh = GetComponent<MeshFilter>().mesh;
        Beta();
    }
    private void Beta()
    {
        ultAlto = 2;
        Creator(new Vector2[] {
            new Vector2(0,0),
            new Vector2(1.5f,-1),
            new Vector2(3f,0),
            new Vector2(2f,2f),
            new Vector2(0,2f)
        });
    }
    public void Creator(Vector2[] coordenadas)
    {
        this.coordenadas = coordenadas;
        lmesh.Clear();
        CrearVertices();
        CrearTriangulos();
    }

    private void CrearTriangulos()
    {
        List<int> triangulos = new List<int>();
        for (int i = 0; i < lmesh.vertexCount / 2; i++) //cambiar a 4 luego
        {
            triangulos.AddRange(predefTriangulo(true, i));
        }
        for (int i = 0; i < triangulos.Count; i++)
        {
            if (triangulos[i] == lmesh.vertexCount + 1)
                triangulos[i] = 1;
            if (triangulos[i] == lmesh.vertexCount)
                triangulos[i] = 0;
            //Debug.Log(triangulos[i]);
        }
        foreach (var item in lmesh.vertices)
        {
            //Debug.Log("x: " + item.x + " y: " + item.y + " z: " + item.z);
        }
        lmesh.triangles = triangulos.ToArray();
    }
    private List<int> predefTriangulo(bool sentido, int paso)
    {
        List<int> ret = new List<int>();
        if (sentido)
            ret.AddRange(new List<int>() { 0, 2, 1, 1, 2, 3 });
        else
            ret.AddRange(new List<int>() { 0, 2, 1, 1, 3, 2 });
        for (int i = 0; i < ret.Count; i++)
        {
            ret[i] += paso * 2;
        }
        return ret;
    }

    private void CrearVertices()
    {
        float escala = 1f;
        List<Vector3> secondary = new List<Vector3>();
        bool pos = false;
        Vector3 decay = Vector3.zero;
        foreach (var cc in this.coordenadas)
        {
            if (cc == Vector2.zero)
                pos = true;
            if (pos)
            {
                secondary.Add(new Vector3(cc.x, 0, cc.y) - decay);
                decay = new Vector3(cc.x, 0, cc.y);
            }
        }
        foreach (var cc in this.coordenadas)
        {
            if (cc == Vector2.zero)
                break;
            else
            {
                secondary.Add(new Vector3(cc.x, 0, cc.y) - decay);
                decay = new Vector3(cc.x, 0, cc.y);
            }
        }
        decay = Vector3.zero;
        Vector3 decaySec = Vector3.zero;
        List<Vector3> vertex = new List<Vector3>();
        List<Vector3> vertex2 = new List<Vector3>();
        foreach (var trCC in secondary)
        {
            if (trCC == Vector3.zero)
            {
                vertex.Add(trCC);
                vertex2.Add(trCC);
            }
            else
            {
                decay += trCC;
                decaySec += trCC + trCC / Vector3.Distance(Vector3.zero,trCC) * escala;
                vertex.Add(decay);
                vertex2.Add(decaySec);
            }
        }
        foreach (var item in vertex2)
        {
            Debug.Log("x: " + item.x + " y: " + item.y + " z: " + item.z);
        }
        decay = Varicentro(vertex2) - Varicentro(vertex);
        for (int i = 0; i < vertex2.Count; i++)
        {
            vertex2[i] -= decay;
            vertex.Insert(i * 2 + 1, vertex2[i]);
        }

        lmesh.vertices = vertex.ToArray();
    }
    private Vector3 Varicentro(List<Vector3> a)
    {
        Vector3 ret = Vector3.zero;
        foreach (var cc in a)
        {
            ret += cc;
        }
        return ret / a.Count;
    }
}
