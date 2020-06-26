using System;
using System.Collections;
using System.Collections.Generic;
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
    }
    public void Creator(Vector2[] coordenadas)
    {
        this.coordenadas = coordenadas;
        lmesh.Clear();
        CrearVertices();
    }

    private void CrearVertices()
    {
        List<Vector3> vertex = new List<Vector3>();
        foreach (var cc in this.coordenadas)
        {
            vertex.Add(new Vector3(cc.x, cc.y, 0));
        }

    }
}
