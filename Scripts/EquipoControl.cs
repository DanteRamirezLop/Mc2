using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class EquipoControl : ObjectControlMain
{
    public Vector3 offset;
    //parte de la tabla equipov
    public int idProyecto { get; set; }
    public string codigo { get; set; }
    public int tipo { get; set; }
    public double velocidadIny { get; set; }
    public double velocidadExt { get; set; }
    public double porcentaje { get; set; }
    public bool calculo { get; set; }
    public int vinculo { get; set; }
    public string nivel { get; set; }
    public int idAmbiente { get; set; }
    //parte de la tabla equipoesp
    public double potencia { get; set; }
    public double voltaje { get; set; }
    public bool sistema { get; set; }
    public double enfEntrada1 { get; set; }
    public double enfEntrada2 { get; set; }
    public double enfSalida1 { get; set; }
    public double enfSalida2 { get; set; }
    public string tipoEsp { get; set; }
    public double Hz { get; set; }
    public double CSensible { get; set; }
    public double CLatente { get; set; }
    public double ESensible { get; set; }
    public double ELatente { get; set; }
    public double caudal { get; set; }


    public override Quaternion getRotation(int target)
    {
        return this.transform.rotation;
    }

    public override Vector3 getUbi(int target)
    {
        return this.transform.position;
    }

    public override void setAdReference(GameObject refer)
    {
        adreferencia = refer;
    }

    public override void SetReferencia(GameObject refer)
    {
        Debug.Log("Nope");
    }
    public override double getAlto()
    {
        return 0;
    }

    public override double getAncho()
    {
        return 0;
    }

}
