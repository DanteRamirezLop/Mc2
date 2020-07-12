using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoMesh : MonoBehaviour
{
    private float ultAncho;
    private float ultLargo; //siempre en metros...
    private float ultAlto;
    private Mesh lmesh;
    public Material mat;
    private GameObject colision;
    // Start is called before the first frame update
    void Start()
    {
        ultAlto = 0.254f;
        ultAncho = 0.254f;
        ultLargo = 1;
        if (!TryGetComponent(typeof(MeshFilter), out Component c))
        {
            gameObject.AddComponent(typeof(MeshFilter));
        }
        if (!TryGetComponent(typeof(MeshRenderer), out Component d))
        {
            gameObject.AddComponent(typeof(MeshRenderer));
        }
        lmesh = GetComponent<MeshFilter>().mesh;

        colision = new GameObject("colision");
        colision.transform.SetParent(this.transform);
        colision.AddComponent(typeof(BoxCollider));
        colision.AddComponent(typeof(MiniColision));
        ParaInspector();

        GetComponent<MeshRenderer>().material = mat;
        Creator();
    }

    public void ReCreator(float largo)
    {
        if (largo == ultAlto)
            return;
        VertexMoveLong();
        lmesh.RecalculateBounds();
        ParaInspector();
    }
    public void ReCreator(float ancho, float alto)
    {
        if (ancho == ultAncho && alto == ultAlto)
            return;
        VertexMoveArea();
        lmesh.RecalculateBounds();
        ParaInspector();
    }

    private void Creator()
    {
        lmesh.Clear();
        VertexMoveArea();
        TriangleCreation();
        VertexMoveLong();
        lmesh.RecalculateBounds();
    }


    private void TriangleCreation()
    {
        lmesh.triangles = new int[] {
            0,2,1,0,3,2, //arriba a
            4,5,6,4,6,7, //abajo a
            2,3,7,2,7,6, //derecha a
            0,1,5,0,5,4, // izquierda a

            0,8,11,0,11,3, //arriba e
            1,10,9,1,2,10, //arriba i
            3,11,15,3,15,7, //derecha e
            2,14,10,2,6,14, //derecha i
            0,12,8,0,4,12, //izquierda e
            1,9,13,1,13,5, //izquierda i
            4,15,12,4,7,15, //abajo e
            5,13,6,6,13,14, //abajo i

            15,14,13,15,13,12, //arriba b
            11,9,10,11,8,9, //abajo b
            13,8,12,13,9,8, //derecha b
            15,10,14,15,11,10 // izquierda b
        };
    }

    private void VertexMoveArea()
    {
        Vector3[] nVertex = new Vector3[16];
        Vector3 pivot = new Vector3(ultAncho, ultAlto);
        pivot /= 2;
        //ArD
        nVertex[3] = pivot;
        nVertex[2] = pivot * 0.95f;
        //ArI
        pivot.x *= -1;
        nVertex[0] = pivot;
        nVertex[1] = pivot * 0.95f;
        //AbD
        pivot.x *= -1;
        pivot.y *= -1;
        nVertex[7] = pivot;
        nVertex[6] = pivot * 0.95f;
        //AbI
        pivot.x *= -1;
        nVertex[4] = pivot;
        nVertex[5] = pivot * 0.95f;
        for (int i = 8; i < 16; i++)
            nVertex[i] = nVertex[i-8];
        lmesh.vertices = nVertex;
    }

    private void VertexMoveLong()
    {
        Vector3[] nVertex = lmesh.vertices;
        for (int i = 8; i < 16; i++)
            nVertex[i].z = (float)ultLargo;
        lmesh.vertices = nVertex;
    }
    public void ParaInspector()
    {
        colision.transform.position = Vector3.zero;
        colision.GetComponent<BoxCollider>().size = lmesh.bounds.size;
    }
    public void ParaUnir()
    {
        colision.transform.position = Vector3.forward * ultLargo;
        colision.GetComponent<BoxCollider>().size = new Vector3(ultAncho,ultAlto,0.5f);
    }
}
