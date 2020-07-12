using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControlMain : MonoBehaviour
{
    public int id;
    public int conexion = 0;
    public GameObject atreferencia; //referencia atras, a quien esta conectado este item
    public GameObject adreferencia; //referencia adelante, dejar en desuso para las uniones multiples
    protected double pulgadaAmetro(double pulgada)
    {
        return pulgada / 39.37;
    }
    protected void PositionFromReference()
    {
        this.transform.position = atreferencia.GetComponent<ObjectControlMain>().getUbi(conexion);
        this.transform.rotation = atreferencia.GetComponent<ObjectControlMain>().getRotation(conexion);
    }
    /// <summary>
    /// Emite un pulso advirtiendo a los objetos contiguos a cambiar sus colisiones
    /// </summary>
    /// <param name="modo">true para modo creador (attach), false para inspector</param>
    public virtual void PulsoColision(bool modo)
    {
        ChangeColliderState(modo);
        if (adreferencia != null)
        {
            adreferencia.GetComponent<ObjectControlMain>().PulsoColision(modo);
        }
    }
    public abstract void SetReferencia(GameObject refer);
    public abstract void setAdReference(GameObject refer);
    public abstract double getAncho();
    public abstract double getAlto();
    public abstract Vector3 getUbi(int target);
    public abstract Quaternion getRotation(int target);
    /// <summary>
    /// Cambia los colisionadores
    /// el modo inspeccion cubre todo, el de conexion solo una parte
    /// si no estan conectados siempre deben estar en modo inspeccion
    /// </summary>
    /// <param name="cambio">true para modo conexion, false para inspeccion</param>
    public void ChangeColliderState(bool cambio)
    {
        if (cambio)
            ColliderConnectState();
        else
            ColliderInspectState();
    }
    protected abstract void ColliderInspectState();
    protected abstract void ColliderConnectState();
    public void setId(int id)
    {
        this.id = id;
    }
    public int getId()
    {
        return this.id;
    }
}
