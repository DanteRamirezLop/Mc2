using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienteControl : MonoBehaviour
{
    private Vector3[] Cuadrante;
    void Start()
    {
        if (!TryGetComponent(typeof(AmbienteMesh), out Component c))
        {
            gameObject.AddComponent(typeof(AmbienteMesh));
        }
    }
    private void Beta()
    {
        if (true)
        {
            GetComponent<AmbienteMesh>().Creator(new Vector2[] {
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
            GetComponent<AmbienteMesh>().Creator(new Vector2[] {
            new Vector2(0,0),
            new Vector2(0,2f),
            new Vector2(2f,2f),
            new Vector2(3f,0),
            new Vector2(1.5f,0.5f),
            new Vector2(1f,0.5f),
            new Vector2(1f,0)
        });
        }
        GetComponent<AmbienteMesh>().CambiarAlto(2.5f);
        Cuadrante = GetComponent<AmbienteMesh>().ConstruirCuadrante();
    }
    void Update()
    {
        if (Cuadrante == null)
            Beta();
    }
    public void EnterData(Vector2[] coordenadas, double altura)
    {
        GetComponent<AmbienteMesh>().CambiarAlto((float)altura);
        GetComponent<AmbienteMesh>().Creator(coordenadas);
        Cuadrante = GetComponent<AmbienteMesh>().ConstruirCuadrante();
    }
    public void EnterData(Vector2[] coordenadas)
    {
        GetComponent<AmbienteMesh>().Creator(coordenadas);
        Cuadrante = GetComponent<AmbienteMesh>().ConstruirCuadrante();
    }
    public void EnterData(double altura)
    {
        GetComponent<AmbienteMesh>().CambiarAlto((float)altura);
        Cuadrante = GetComponent<AmbienteMesh>().ConstruirCuadrante();
    }
    public Vector3[] getCuadrante()
    {
        return this.Cuadrante;
    }
}
