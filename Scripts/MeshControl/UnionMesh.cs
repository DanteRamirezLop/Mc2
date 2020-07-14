using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionMesh : MonoBehaviour
{
    private float ultancho;
    private float ultalto;
    private Mesh lmesh;
    // Start is called before the first frame update
    void Start()
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
        //GetComponent<MeshRenderer>().material = mat;
        lmesh = GetComponent<MeshFilter>().mesh;
        Creator();
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
        throw new NotImplementedException();
    }

    private void ReCrearVertices()
    {
        
    }
    
}
