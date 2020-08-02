using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienteControl : MonoBehaviour
{
    private Vector3[] Cuadrante;

    private List<RejillaControl> rejillas;
    private Ambiente ambiente;

    private void Awake()
    {
        rejillas = new List<RejillaControl>();
    }
    void Start()
    {
        if (Cuadrante == null)
            Beta();
    }
    void OnEnable()
    {
        if (!TryGetComponent(typeof(AmbienteMesh), out Component c))
        {
            gameObject.AddComponent(typeof(AmbienteMesh));
        }
    }
    public void InitOrder()
    {
        if (DatosScena.Ambiente == null)
            DatosScena.Ambiente = new List<Ambiente>();
        this.ambiente = new Ambiente();
        DatosScena.Ambiente.Add(this.ambiente);
    }

    private void Beta()
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
        /*    GetComponent<AmbienteMesh>().Creator(new Vector2[] {
            new Vector2(0,0),
            new Vector2(0,2f),
            new Vector2(2f,2f),
            new Vector2(3f,0),
            new Vector2(1.5f,0.5f),
            new Vector2(1f,0.5f),
            new Vector2(1f,0)
        });
        }*/
        GetComponent<AmbienteMesh>().CambiarAlto(2.5f);
        Cuadrante = GetComponent<AmbienteMesh>().ConstruirCuadrante();
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
