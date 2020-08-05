using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectControlMain : MonoBehaviour
{
    public int id;
    public int conexion = 0;
    public GameObject atreferencia; //referencia atras, a quien esta conectado este item
    public GameObject adreferencia; //referencia adelante, dejar en desuso para las uniones multiples
    protected double metroAPulgada(double pulgada)
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
    public void SetConexion(int conexion)
    {
        this.conexion = conexion;
    }
    public abstract void SetReferencia(GameObject refer);
    public abstract void setAdReference(GameObject refer);
    public abstract double getAncho(GameObject rebote);
    public abstract double getAlto(GameObject rebote);
    public float getPAlto()
    {
        return (float)metroAPulgada(getAlto(this.gameObject));
    }
    public float getPAncho()
    {
        return (float)metroAPulgada(getAncho(this.gameObject));
    }
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
    public abstract void ChangeLayer(int layer);
    /// <summary>
    /// Es para identificar la clase hija, lo veo mas facil que un enum
    /// </summary>
    /// <returns>0 si es un equipo, 1 si es un ducto, 2 si es un codo, 3 si es un multiple, 4 si es una rejilla</returns>
    public abstract int getTipo();
    public void setId(int id)
    {
        this.id = id;
    }
    public int getId()
    {
        return this.id;
    }
    public abstract double CFMreal();
    public abstract void InitOrder();
}
