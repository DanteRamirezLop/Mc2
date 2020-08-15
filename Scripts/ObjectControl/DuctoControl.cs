using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctoControl : ObjectControlMain
{
    private DuctoMesh mesh;

    public Ducto ducto;
    public Ductopass dPass; //instanciar un clon nada mas
    public GameObject continuacion;
    public bool ghost;

    private AmbienteControl amb; //solo si hay un paso
    //solo para formulas, el usuario las cambia

    public override double getAlto(GameObject rebote)
    {
        return this.ducto.dimA;
    }

    public override double getAncho(GameObject rebote)
    {
        return this.ducto.dimB;
    }

    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        Vector3 ret = this.transform.position + this.transform.forward * (float)ducto.longitud;
        return ret;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ducto.dimA = 6;
        ducto.dimB = 6;
        ducto.longitud = 2;
        if (!TryGetComponent(typeof(DuctoMesh), out Component c))
        {
            gameObject.AddComponent(typeof(DuctoMesh));
        }
        mesh = GetComponent<DuctoMesh>();
    }

    public void Refresh()
    {
        if (ducto.longitud < 0.5)
            ducto.longitud = 0.5;
        this.mesh.ReCreator(dPass == null ?1: (float)ducto.longitud);
        this.mesh.ReCreator(getPAncho(), getPAlto());
        PulsoRedimension();
    }

    public override void SetReferencia(GameObject refer)
    {
        atreferencia = refer;
        refer.GetComponent<ObjectControlMain>().setAdReference(this.gameObject);
        PositionFromReference();
        Refresh();
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }

    protected override void ColliderInspectState()
    {
        mesh.ParaInspector();
    }

    protected override void ColliderConnectState()
    {
        mesh.ParaUnir(this.adreferencia == null);
    }

    public override void ChangeLayer(int layer)
    {
        this.mesh.ChangeLayer(layer);
    }

    public override int getTipo()
    {
        return 1;
    }

    public override double CFMreal()
    {
        if (this.adreferencia != null)
            return adreferencia.GetComponent<ObjectControlMain>().CFMreal();
        else
            return 0;
    }

    public override void InitOrder()
    {
        if (DatosScena.Ducto == null)
            DatosScena.Ducto = new List<Ducto>();
        this.ducto = new Ducto();
        DatosScena.Ducto.Add(this.ducto);
    }

    public double DiametroEquivalente()
    {
        return 1.3 * (Math.Pow(ducto.dimA * ducto.dimB, 0.625) /
            Math.Pow(ducto.dimA + ducto.dimB, 0.25));
    }
    public double CaidaPresionUnitaria()
    {
        return 0.109136 * Math.Pow(CFMreal(), 1.9) / Math.Pow(DiametroEquivalente(), 5.02);
    }

    public double CaidaPresionPiso()
    {
        return CaidaPresionUnitaria() / 100 * (ducto.longitud / 0.3048);
    }
    public double Velocidad()
    {
        return CFMreal() / (ducto.dimA * ducto.dimB / 144);
    }
    public double HV()
    {
        return Math.Pow(Velocidad() / 4005, 2);
    }
    public double CaidaPresionH2O()
    {
        double dif = 0;
        double rt = 0;
        double multi = 0;
        double codo = 0;
        if (adreferencia != null)
        {
            switch (adreferencia.GetComponent<ObjectControlMain>().getTipo())
            {
                case 1:
                    break;
                case 2:
                    codo = 1;
                    break;
                case 3:
                    multi = 1;
                    break;
                case 4:
                    if (ducto.tipo == 0)
                        dif = 1;
                    else
                        rt = 1;
                    break;
                default:
                    break;
            }
        }
        return HV() * codo * 0.32 + multi * 0.16 + ducto.damCer50 * 0.2 + ducto.damCer10 * 0.52 +
                ducto.damAb100 * 29 + ducto.tranRec * 0.8 + ducto.conVen * 0.2 + dif * 0.016 +
                0.06 * rt + ducto.lumAli * 0.07;
    }
    public double PerdidaTotal()
    {
        double caida1 = CaidaPresionPiso();
        double caida2 = CaidaPresionH2O();
        if (double.IsNaN(caida1) || double.IsInfinity(caida1))
            caida1 = 0;
        if (Double.IsNaN(caida2) || double.IsInfinity(caida2))
            caida2 = 0;
        return caida1 + caida2;
    }
    public void SetAmbiente(AmbienteControl referencia)
    {
        this.amb = referencia;
    }
    public override void PulsoRedimension()
    {
        PositionFromReference();
        if (this.adreferencia != null)
        {
            this.adreferencia.GetComponent<ObjectControlMain>().PulsoRedimension();
        }
        if (atreferencia.GetComponent<ObjectControlMain>().dependant)
        {
            GetComponent<ObjectControlMain>().PulsoRedimension();
        }
    }

    public override AmbienteControl GetAmbiente()
    {
        return ghost ? amb : atreferencia.GetComponent<ObjectControlMain>().GetAmbiente();
    }
    public GameObject InitDuctoPass(AmbienteControl amb)
    {
        dPass = new Ductopass();
        DatosScena.Ductopass.Add(dPass);
        this.amb = amb;
        this.continuacion = GameObject.Instantiate(this.gameObject);
        this.continuacion.GetComponent<DuctoControl>().ghost = true;
        return this.continuacion;
    }
}
