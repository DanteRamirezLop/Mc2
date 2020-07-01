using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class AmbienteMesh : MonoBehaviour
{
    private Vector2[] coordenadas;
    private float ultAlto;
    private Mesh lmesh;
    public GameObject trial;
    public Material mat;
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
        ultAlto = 0.1f;
        Beta();
        GetComponent<MeshRenderer>().material = mat;
    }
    private void Beta()
    {
        if (true)
        {
        Creator(new Vector2[] {
            new Vector2(0,0),
            new Vector2(1f,0),
            new Vector2(1f,0.5f),
            new Vector2(1.5f,0.5f),
            new Vector2(3f,0),
            new Vector2(2f,2f),
            new Vector2(0,2f)
        });
        }
        else
        {
        Creator(new Vector2[] {
            new Vector2(0,0),
            new Vector2(0,2f),
            new Vector2(2f,2f),
            new Vector2(3f,0),
            new Vector2(1.5f,0.5f),
            new Vector2(1f,0.5f),
            new Vector2(1f,0)
        });
        }
        CambiarAlto(2.5f);
    }
    public void Creator(Vector2[] coordenadas)
    {
        this.coordenadas = coordenadas;
        lmesh.Clear();
        bool sentido = CrearVertices();
        CrearTriangulos(sentido);
    }

    public void CambiarAlto(float alto)
    {
        if (ultAlto == alto)
        {
            return;
        }
        ultAlto = alto;
        Vector3[] nvertex = lmesh.vertices;
        int flagged = 0;
        for (int i = 0; i < nvertex.Length; i++)
        {
            if (flagged > 1)
            {
                nvertex[i].y = ultAlto;
            }
            flagged++;
            if (flagged == 4)
            {
                flagged = 0;
            }
        }
        lmesh.vertices = nvertex;
    }

    private void CrearTriangulos(bool sentido)
    {
        List<int> triangulos = new List<int>();
        for (int i = 0; i < lmesh.vertexCount / 4; i++)
        {
            triangulos.AddRange(predefTriangulo(sentido, i));
        }
        /*for (int i = 0; i < lmesh.vertexCount / 4 - 1; i++)
        {
            triangulos.AddRange(predefPiso(sentido, i));
        }*/
        for (int i = 0; i < triangulos.Count; i++)
        {
            if (triangulos[i] == lmesh.vertexCount + 3)
                triangulos[i] = 3;
            if (triangulos[i] == lmesh.vertexCount + 2)
                triangulos[i] = 2;
            if (triangulos[i] == lmesh.vertexCount + 1)
                triangulos[i] = 1;
            if (triangulos[i] == lmesh.vertexCount)
                triangulos[i] = 0;
            //Debug.Log(triangulos[i]);
        }
        lmesh.triangles = triangulos.ToArray();
    }
    //no esta funcionando, de nuevo sera un calculo feo, ahi no mas
    private List<int> predefPiso(bool sentido, int paso)
    {
        List<int> ret = new List<int>();
        if (!sentido)
        {
            ret.AddRange(new List<int>() {0, 4, 8 });
        }
        else
        {
            ret.AddRange(new List<int>() {0, 8, 4 });
        }
        for (int i = 0; i < ret.Count; i++)
        {
            ret[i] += paso * 4;
        }
        return ret;
    }
    private List<int> predefTriangulo(bool sentido, int paso)
    {
        List<int> ret = new List<int>();
        if (sentido)
            ret.AddRange(new List<int>() { 0, 1, 4, 1, 5, 4,
                0, 4, 2, 2, 4, 6,
                1, 3, 5, 3, 7, 5,
                2, 6, 3, 3, 6, 7});
        else
            ret.AddRange(new List<int>() { 0, 4, 1, 1, 4, 5,
                0, 2, 4, 2, 6, 4,
                1, 5, 3, 3, 5, 7,
                2, 3, 6, 3, 7, 6});
        for (int i = 0; i < ret.Count; i++)
        {
            ret[i] += paso * 4;
        }
        return ret;
    }

    private bool CrearVertices()
    {
        List<Vector3> mainVertex = new List<Vector3>();
        foreach (var cc in this.coordenadas)
        {
            mainVertex.Add(new Vector3(cc.x, 0, cc.y));
        }
        bool flag1 = mainVertex[1].z < mainVertex[mainVertex.Count - 1].z;
        Debug.Log(flag1);
        List<Vector3> secondaryVertex = new List<Vector3>();
        for (int i = 0; i < mainVertex.Count; i++)
        {
            if (i == 0)
            {
                secondaryVertex.Add(GetOneOff(mainVertex[mainVertex.Count - 1], mainVertex[i + 1], mainVertex[i], false));
                secondaryVertex.Add(GetOneOff(mainVertex[mainVertex.Count - 1], mainVertex[i + 1], mainVertex[i], true));
            }
            else if (i == mainVertex.Count -1)
            {
                secondaryVertex.Add(GetOneOff(mainVertex[i - 1],mainVertex[0], mainVertex[i], false));
                secondaryVertex.Add(GetOneOff(mainVertex[i - 1],mainVertex[0], mainVertex[i], true));
            }
            else
            {
                secondaryVertex.Add(GetOneOff(mainVertex[i - 1],mainVertex[i + 1], mainVertex[i], false));
                secondaryVertex.Add(GetOneOff(mainVertex[i - 1],mainVertex[i + 1], mainVertex[i], true));
            }
        }
        List<Vector3> retVertex = new List<Vector3>();
        float a, b;
        for (int i = 0; i < mainVertex.Count; i++)
        {
            retVertex.Add(mainVertex[i]);
            if (i == 0)
            {
                a = Direccion(mainVertex[i] - mainVertex[mainVertex.Count - 1], secondaryVertex[i * 2] - mainVertex[mainVertex.Count - 1]);
                b = Direccion(mainVertex[i] - mainVertex[mainVertex.Count - 1], secondaryVertex[i * 2 + 1] - mainVertex[mainVertex.Count - 1]);
            }
            else
            {
                a = Direccion(mainVertex[i] - mainVertex[i - 1], secondaryVertex[i * 2] - mainVertex[i - 1]);
                b = Direccion(mainVertex[i] - mainVertex[i - 1], secondaryVertex[i * 2 + 1] - mainVertex[i - 1]);
            }
            //Debug.Log("a: " + a + " b: " + b);
            bool flag2;
            if (flag1)
                flag2 = a > b;
            else
                flag2 = a < b;
            if (flag2)
                retVertex.Add(secondaryVertex[i * 2]);
            else
                retVertex.Add(secondaryVertex[i * 2 + 1]);
            retVertex.Add(retVertex[retVertex.Count - 2] + Vector3.up * ultAlto);
            retVertex.Add(retVertex[retVertex.Count - 2] + Vector3.up * ultAlto);
        }
        /*foreach (var item in mainVertex)
        {
            GameObject.Instantiate(this.trial, item, Quaternion.identity);
        }
        for (int i = 0; i < secondaryVertex.Count; i++)
        {
           GameObject.Instantiate(this.trial, secondaryVertex[i], Quaternion.identity);
        }*/
        lmesh.vertices = retVertex.ToArray();
        return flag1;
    }
    private Vector3 GetOneOff(Vector3 bef, Vector3 aft, Vector3 origen, bool negate)
    {
        Vector3 ret = ((bef - origen).normalized + (aft - origen).normalized) / 2;
        //Debug.Log("x: " + ret.x + " y: " + ret.y + " z: " + ret.z);
        //ret = ret.normalized;
        float other = Vector3.Dot((bef - origen).normalized, (aft - origen).normalized);
        if (other > 0)
        {
            ret += ret * other;
        }
        else
        {
            ret += ret * other * -1;
        }
        //ret += ret * Vector3.Dot((bef - origen).normalized, (aft - origen).normalized);
        if (negate)
            ret *= -1;
        return ret * 0.2f + origen;
    }
    private float Direccion(Vector3 adelante, Vector3 destino)
    {
        Vector3 first = Vector3.Cross(adelante, destino);
        return Vector3.Dot(first,Vector3.up);
    }
}
