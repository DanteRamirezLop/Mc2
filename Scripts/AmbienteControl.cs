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
    public void AddRejilla(RejillaControl rej)
    {
        this.rejillas.Add(rej);
    }
    public double GetVolumen()
    {
        if (ambiente.area > 0)
            return ambiente.area * ambiente.altura;
        else
            return ambiente.altura * ambiente.ancho * ambiente.largo;
    }
    public double Getflujo()
    {
        if (ambiente.flujo > 0)
            return ambiente.flujo;
        return ambiente.recambios * GetVolumen();
    }
    public double GetCFMTotal()
    {
        if (ambiente.cfm > 0)
            return ambiente.cfm;
        return Getflujo() * 0.5885;
    }
    public double GetCFMDisponible()
    {
        double ret = GetCFMTotal();
        foreach (var rej in rejillas)
            ret -= rej.rejilla.cfm;
        return ret;
    }
    public double GetDefaultCFM()
    {
        int ret = 0;
        foreach (var rej in rejillas)
            ret += rej.rejilla.cfm == 0?1:0;
        return GetCFMDisponible() / ret;
    }
}
