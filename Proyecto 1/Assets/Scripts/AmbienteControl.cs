using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienteControl : MonoBehaviour
{
    private Vector3[] Cuadrante;
    void Start()
    {
        if (TryGetComponent(typeof(AmbienteMesh), out Component c))
        {
            gameObject.AddComponent(typeof(AmbienteMesh));
        }

    }


    public void datos() {

       // Vector2[] Coordenada = new Vector2[7];
        //double altura = 2.5f;
        Debug.Log("Hola");
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
