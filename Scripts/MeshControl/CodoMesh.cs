using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodoMesh : MonoBehaviour
{
    //nuevo funcionamiento eje x -> arriba -, abajo +, eje y -> derecha +, izquierda -
    public Vector2 angulo;
    private Mesh lmesh;
    public double ultAncho; //en metros
    public double ultAltura; //en metros
    private GameObject pivot;
    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    public Quaternion fDirection; //la direccion final
    public Material mat;
    private GameObject colision;
    // Start is called before the first frame update
    void OnEnable()
    {
        angulo = new Vector2();
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
        return this.transform.rotation * Quaternion.Euler(-angulo.y, angulo.x, 0);
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

    public void ChangeLayer(int layer)
    {
        this.colision.layer = layer;
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
        Quaternion temp = this.transform.rotation;
        this.transform.rotation = Quaternion.identity;
        InitPivot();
        HacerVertices();
        this.transform.rotation = temp;
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
            do
            {
                if (vertices.Count != 0)
                    RotatePivot();
                foreach (var vec in ObtainVertex())
                    vertices.Add(vec);
            } while (this.pivot.transform.rotation != this.fDirection);
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
            dir = Vector3.up * (float)ultAncho / 2;
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
            pivot.transform.position = pivot.transform.position + this.transform.forward * 0.5f;
        }
        else
        {
            pivot.transform.rotation = Quaternion.RotateTowards(pivot.transform.rotation, fDirection, 10);
            if (Quaternion.Angle(pivot.transform.rotation,fDirection) < 5)
            {
                pivot.transform.rotation = Quaternion.RotateTowards(pivot.transform.rotation, fDirection, 10);
            }
            //Debug.Log("x: " + pivot.transform.localEulerAngles.x + " y: " + pivot.transform.localEulerAngles.y + " z: " + pivot.transform.localEulerAngles.z);
            //Debug.Log("x: " + pivot.transform.eulerAngles.x + " y: " + pivot.transform.eulerAngles.y + " z: " + pivot.transform.eulerAngles.z);
        }
    }

    private void InitPivot()
    {
        pivot.transform.localPosition = Vector3.zero;
        pivot.transform.localRotation = Quaternion.identity;
        Vector3 direccion = Vector3.forward;
        switch (DireccionAngulo())
        {
            case 0:
                pivot.transform.Translate(((float)ultAncho / 2 + 0.1f) * Vector3.left);
                direccion *= (float)ultAncho;
                break;
            case 1:
                pivot.transform.Translate(((float)ultAncho / 2 + 0.1f) * Vector3.right);
                direccion *= (float)ultAncho;
                break;
            case 2:
                pivot.transform.Translate(((float)ultAltura / 2 + 0.1f) * Vector3.down);
                direccion *= (float)ultAltura;
                break;
            case 3:
                pivot.transform.Translate(((float)ultAltura / 2 + 0.1f) * Vector3.up);
                direccion *= (float)ultAltura;
                break;
            default:
                pivot.transform.Translate(((float)ultAncho / 2 + 0.1f) * Vector3.right);
                direccion *= (float)ultAncho;
                break;
        }
        if (DireccionAngulo() % 2 != 0 || DireccionAngulo() == 4) //por aca se puede poner el grosor
        {
            p1.transform.localPosition = Vector3.forward * 0.1f + direccion;
            p2.transform.localPosition = Vector3.forward * 0.1f + direccion * 0.95f;
            p3.transform.localPosition = Vector3.forward * 0.1f + direccion * 0.05f;
            p4.transform.localPosition = Vector3.forward * 0.1f;
        }
        else
        {
            p4.transform.localPosition = Vector3.forward * 0.1f + direccion;
            p3.transform.localPosition = Vector3.forward * 0.1f + direccion * 0.95f;
            p2.transform.localPosition = Vector3.forward * 0.1f + direccion * 0.05f;
            p1.transform.localPosition = Vector3.forward * 0.1f;
        }
        pivot.transform.LookAt(this.transform);
        //Debug.Log("x: " + pivot.transform.localEulerAngles.x + " y: " + pivot.transform.localEulerAngles.y + " z: " + pivot.transform.localEulerAngles.z);
        pivot.transform.Rotate(-angulo.y, angulo.x, 0);
        fDirection = pivot.transform.rotation;
        //Debug.Log("x: " + pivot.transform.localEulerAngles.x + " y: " + pivot.transform.localEulerAngles.y + " z: " + pivot.transform.localEulerAngles.z);
        pivot.transform.LookAt(this.transform);
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
