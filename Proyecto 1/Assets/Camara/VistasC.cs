using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistasC :IComparable<VistasC>
{
    //MonoBehaviour
    //IComparable<VistasC>
    public enum camBehaviour { 
        AirView, FollowPlayer, LockOnGameObject, Stationary 
    }

    public Vector3 posicion;
	public Vector3 rotacion;
	public bool activo;
	public KeyCode buttonUsage;
	public float duracion;
	public camBehaviour actAs;  
	public string cullingMaskIgnore;
	public bool singleCall;

	// Use this for initialization

    public void uVistasC()
    {
        //remplace VistaC por que se llamaba igual que la clase
        int cant = 9;//

        posicion = new Vector3(0, 0, 0);
        rotacion = new Vector3(0, 0, 0);
        activo = false;

        buttonUsage = (KeyCode)Enum.Parse(typeof(KeyCode), cant.ToString());// buttonUsage = 9;  //POSIBLE PROBLEMA //(KeyCode)reader.ReadInt32();
         
        actAs = camBehaviour.AirView;
        singleCall = true;
        cullingMaskIgnore = "None";
    }

    public void dVistasC(Vector3 wposicion, Vector3 wrotacion,bool wactivo, KeyCode wbuttonUsage ,camBehaviour wactAs, string wCullingMaskIgnore){
        //remplace VistaC por que se llamaba igual que la clase
		this.posicion = wposicion;
		this.rotacion = wrotacion;
		this.activo = wactivo;
		this.buttonUsage = wbuttonUsage;
		this.actAs = wactAs;
		this.singleCall = true;
		this.cullingMaskIgnore = wCullingMaskIgnore;
	}
	public KeyCode getKey(){
		return buttonUsage;
	}
	public int getBehaviour(){
		if(actAs == camBehaviour.AirView)
			return 0;
		if(actAs == camBehaviour.FollowPlayer)
			return 1;
		if(actAs == camBehaviour.LockOnGameObject)
			return 2;
		if(actAs == camBehaviour.Stationary)
			return 3;
		return 0;
	}
	public Quaternion getQRotation(){
		return Quaternion.Euler(this.rotacion);
	}
	public int CompareTo(VistasC vista){
		if(vista.actAs == this.actAs && this.posicion == vista.posicion)
			return 1;
		else
			return 0;
	}

}

//public enum camBehaviour { AirView, FollowPlayer, LockOnGameObject, Stationary };