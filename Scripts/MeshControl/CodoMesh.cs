using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodoMesh : MonoBehaviour
{
    private Vector2 angulo;
    private Mesh lmesh;
    private double ultAncho; //en metros
    private double ultAltura; //en metros
    private GameObject pivot;
    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    public Material mat;
    private GameObject colision;
    // Start is called before the first frame update
    void Start()
    {
        angulo = Vector2.zero;
        angulo = new Vector2(0, 0); //pruebas
        ultAncho = 0.254;
        ultAltura = 0.254;
        pivot = new GameObject("pivote");
        pivot.transform.SetParent(this.transform);
        p1 = new GameObject("p1");
        p2 = new GameObject("p2");
        p3 = new GameObject("p3");
        p4 = new GameObject("p4");
        p1.transform.SetParent(pivot.transform);
        p2.transform.SetParent(pivot.transform);
        p3.transform.SetParent(pivot.transform);
        p4.transform.SetParent(pivot.transform);
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

        colision = new GameObject("colision");
        colision.transform.SetParent(this.transform);
        colision.AddComponent(typeof(BoxCollider));
        colision.AddComponent(typeof(MiniColision));
        ParaInspector();
    }

    public void ParaInspector()
    {
        colision.transform.localPosition = lmesh.bounds.center;
        colision.GetComponent<BoxCollider>().size = lmesh.bounds.size;
    }
    public void ParaUnir()
    {
        colision.transform.position = (p1.transform.position + p2.transform.position) /2;
        colision.GetComponent<BoxCollider>().size = new Vector3((float)ultAncho,(float)ultAltura,0.5f);
    }

    public Quaternion getUltRotation()
    {
        return pivot.transform.rotation;
    }
    public Vector3 getUltPosition()
    {
        return (p1.transform.position + p4.transform.position) / 2;
    }
    /**
     * <summary>Cambia el angulo del codo</summary>
     */
    public void Change(Vector2 angulo)
    {
        if (this.angulo == angulo)
            return;
        this.angulo = angulo;
        Creator();
    }
    /**
     * <summary>Cambia ambos tamaños del codo</summary>
     */
    public void Change(double ancho, double alto)
    {
        if (ultAltura == alto && ultAncho == ancho)
            return;
        ultAltura = alto;
        ultAncho = ancho;
        Creator();
    }
    /**
     * <summary>Cambia el angulo y el tamaño del codo</summary>
     */
    public void Change(Vector2 angulo, double ancho, double alto)
    {
        if (ultAltura == alto && ultAncho == ancho && this.angulo == angulo)
            return;
        this.angulo = angulo;
        ultAltura = alto;
        ultAncho = ancho;
        Creator();
    }
    private void Creator()
    {
        lmesh.Clear();
        InitPivot();
        HacerVertices();
        HacerTriangulos();
        lmesh.RecalculateBounds();
    }
    private void HacerVertices()
    {
        List<Vector3> vertices = new List<Vector3>();
        if (angulo == Vector2.zero)
        {
            foreach (var vec in ObtainVertex())
                vertices.Add(vec);
            RotatePivot();
            foreach (var vec in ObtainVertex())
                vertices.Add(vec);
        }
        else
        {
            float ang;
            if (angulo.x != 0)
                ang = angulo.x;
            else
                ang = angulo.y;
            do
            {
                if (vertices.Count != 0)
                    RotatePivot();
                foreach (var vec in ObtainVertex())
                    vertices.Add(vec);
                ang -= 10;
            } while (ang > 0);
        }
        this.lmesh.SetVertices(vertices.ToArray());
    }
    private void HacerTriangulos()
    {
        int tamano = 16 * 3; //el inicio y el fin del mesh
        tamano += (lmesh.vertexCount - 8) * 6; //por la ley de cortes, se quita un paso
        int[] tri = new int[tamano];
        int it = 0; //para iterar
        foreach (var item in TrianguloInFn(false))
        {
            tri[it] = item;
            it += 1;
        }
        for (int i = 0; i < (lmesh.vertexCount / 8) - 1; i++)
        {
            foreach (var item in TrianguloPaso(i))
            {
                tri[it] = item;
                it += 1;
            }
        }
        foreach (var item in TrianguloInFn(true))
        {
            tri[it] = item;
            it += 1;
        }
        lmesh.SetTriangles(tri,0);
    }
    private int[] TrianguloPaso(int paso)
    {
        int[] ret = new int[] { 
            0,8,11,0,11,3, //arriba e
            1,10,9,1,2,10, //arriba i
            3,11,15,3,15,7, //derecha e
            2,14,10,2,6,14, //derecha i
            0,12,8,0,4,12, //izquierda e
            1,9,13,1,13,5, //izquierda i
            4,15,12,4,7,15, //abajo e
            5,13,6,6,13,14 //abajo i
        };
        for (int i = 0; i < ret.Length; i++)
        {
            ret[i] += 8 * paso;
        }
        return ret;
    }
    private int[] TrianguloInFn(Boolean fin)
    {
        int max = lmesh.vertexCount - 1;
        int[] ret = new int[] {0,2,1,0,3,2, //arriba
            4,5,6,4,6,7, //abajo
            2,3,7,2,7,6, //derecha
            0,1,5,0,5,4}; //abajo
        if (fin)
        {
            for (int i = 0; i < ret.Length / 2; i++)
            {
                int t = ret[ret.Length - i - 1];
                ret[ret.Length - i - 1] = ret[i];
                ret[i] = t;
            }
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = max - ret[i];
                //Debug.Log("Vertex M: " + max + " this vertex: " + ret[i]);
            }
        }

        return ret;
    }
    private Vector3[] ObtainVertex()
    {
        Vector3[] ret = new Vector3[8];
        ret[0] = p1.transform.position - this.transform.position;
        ret[1] = p2.transform.position - this.transform.position;
        ret[2] = p3.transform.position - this.transform.position;
        ret[3] = p4.transform.position - this.transform.position;
        ret[4] = p1.transform.position - this.transform.position;
        ret[5] = p2.transform.position - this.transform.position;
        ret[6] = p3.transform.position - this.transform.position;
        ret[7] = p4.transform.position - this.transform.position;
        Vector3 dir;
        if (p1.transform.localPosition.x != 0)
        {
            dir = Vector3.up * (float)ultAltura / 2;
        }
        else
        {
            dir = Vector3.right * (float)ultAncho / 2;
        }
        for (int i = 0; i < 8; i++)
        {
            if (i == 4)
                dir *= -1;
            if (i % 4 == 1 || i % 4 == 2)
                ret[i] += dir * 0.95f;
            else
                ret[i] += dir;
        }
        return ret;
    }

    private void RotatePivot()
    {
        if(angulo == Vector2.zero)
        {
            pivot.transform.Translate(Vector3.forward * 0.5f);
        }
        else
        {
            Vector3 rotationTemp = new Vector3((angulo.y * -1) - pivot.transform.localEulerAngles.x,
                angulo.x - pivot.transform.localEulerAngles.y);
            if (rotationTemp.x < 0 || rotationTemp.y < 0)
            {
                if (rotationTemp.x < -10)
                    rotationTemp.x = -10;
                if (rotationTemp.y < -10)
                    rotationTemp.y = -10;
            }
            if (rotationTemp.x > 0 || rotationTemp.y > 0)
            {
                if (rotationTemp.x > 10)
                    rotationTemp.x = 10;
                if (rotationTemp.y > 10)
                    rotationTemp.y = 10;
            }
            pivot.transform.Rotate(rotationTemp);
        }
    }

    private void InitPivot()
    {
        Vector3 direccion;
        switch (DireccionAngulo())
        {
            case 0:
                pivot.transform.localPosition = new Vector3((float)((ultAncho / 2 + 0.1) * -1), 0, 0);
                direccion = Vector3.right;
                break;
            case 1:
                pivot.transform.localPosition = new Vector3((float)((ultAncho / 2 + 0.1) * 1), 0, 0);
                direccion = Vector3.left;
                break;
            case 2:
                pivot.transform.localPosition = new Vector3(0, (float)((ultAltura / 2 + 0.1) * -1), 0);
                direccion = Vector3.up;
                break;
            case 3:
                pivot.transform.localPosition = new Vector3(0, (float)((ultAltura / 2 + 0.1) * 1), 0);
                direccion = Vector3.down;
                break;
            default:
                pivot.transform.localPosition = new Vector3((float)((ultAncho / 2 + 0.1) * 1), 0, 0);
                direccion = Vector3.left;
                break;
        }
        Vector3 distancia = new Vector3((float)ultAncho, (float)ultAltura);
        if (DireccionAngulo() % 2 != 0 || DireccionAngulo() == 4) //por aca se puede poner el grosor
        {
            p1.transform.localPosition = new Vector3(direccion.x * distancia.x + direccion.x * 0.1f, direccion.y * distancia.y + direccion.y * 0.1f);
            p2.transform.localPosition = new Vector3(direccion.x * distancia.x * 0.95f + direccion.x * 0.1f, direccion.y * distancia.y * 0.95f + direccion.y * 0.1f);
            p3.transform.localPosition = new Vector3(direccion.x * distancia.x * 0.05f + direccion.x * 0.1f, direccion.y * distancia.y * 0.05f + direccion.y * 0.1f);
            p4.transform.localPosition = new Vector3(direccion.x * 0.1f, direccion.y * 0.1f);
        }
        else
        {
            p4.transform.localPosition = new Vector3(direccion.x * distancia.x + direccion.x * 0.1f, direccion.y * distancia.y + direccion.y * 0.1f);
            p3.transform.localPosition = new Vector3(direccion.x * distancia.x * 0.95f + direccion.x * 0.1f, direccion.y * distancia.y * 0.95f + direccion.y * 0.1f);
            p2.transform.localPosition = new Vector3(direccion.x * distancia.x * 0.05f + direccion.x * 0.1f, direccion.y * distancia.y * 0.05f + direccion.y * 0.1f);
            p1.transform.localPosition = new Vector3(direccion.x * 0.1f, direccion.y * 0.1f);
        }
        pivot.transform.rotation = Quaternion.identity;
    }
    //Indica la direccion del angulo, 0 izquierda, 1 derecha, 2 abajo, 3 arriba; tener en cuenta que esto es relativo
    private int DireccionAngulo()
    {
        if (angulo == Vector2.zero)
        {
            return 4;
        }
        if (angulo.x != 0)
        {
            if (angulo.x < 0)
                return 0;
            else
                return 1;
        }
        else
        {
            if (angulo.y < 0)
                return 2;
            else
                return 3;
        }
    }
}
