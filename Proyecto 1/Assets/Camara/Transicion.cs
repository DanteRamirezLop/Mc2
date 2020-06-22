using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour {

	public Vector3 posicionInicial;
	public Vector3 posicionFinal;
	public Quaternion rotacionInicial;
	public Quaternion rotacionFinal;
	private float duracion;
	private float tiempo;
	public bool termina;

    public void dTransicion(){
        //la funcion se llamaba Transicion pero se cambio por que la clase tien el mismo nombre
		this.posicionInicial = new Vector3(0,0,0);
		this.posicionFinal = new Vector3(0,0,0);
		this.rotacionInicial = new Quaternion(0, 0, 0, 0);
		this.rotacionFinal = new Quaternion(0, 0, 0, 0);
		duracion = 0;
		tiempo = 0;
		this.termina = false;
	}
	public void dTransicion(Vector3 wPosicionInicial, Vector3 wPosicionFinal,Quaternion wRotacionInicial,Quaternion wRotacionFinal,float wDuracion){
        //la funcion se llamaba Transicion pero se cambio por que la clase tien el mismo nombre
        this.posicionInicial = wPosicionInicial;
		this.posicionFinal = wPosicionFinal;
		this.rotacionInicial = wRotacionInicial;
		this.rotacionFinal = wRotacionFinal;
		duracion = wDuracion;
		tiempo = 0;
		this.termina = false;
	}
	//funciones de tiempo
	public void resetTime(){
		tiempo = 0;
		termina = false;
	}
	public void passTime(){
		if(this.tiempo< this.duracion){
			this.tiempo += Time.deltaTime;
		}
		else{
			this.termina = true;
		}
	}
	//setter
	public void setDuracion(float wDuracion){
		this.duracion = wDuracion;
	}
	//funciones de transicion
	public Vector3 lerpTransPosition(){
		Vector3 ret;
		ret = Vector3.Lerp(this.posicionInicial,this.posicionFinal,transitionCompleted());
		return ret;
	}
	public Vector3 slerpTransPosition(){
		Vector3 ret;
		ret = Vector3.Slerp(this.posicionInicial,this.posicionFinal,transitionCompleted());
		return ret;
	}
	public Quaternion lerpTransRotation(){
		Quaternion ret;
		ret = Quaternion.Lerp(this.rotacionInicial, this.rotacionFinal, this.transitionCompleted());
		return ret;
	}
	public Quaternion slerpTransRotation(){
		Quaternion ret;
		ret = Quaternion.Slerp(this.rotacionInicial, this.rotacionFinal, this.transitionCompleted());
		return ret;
	}
	private float transitionCompleted(){
		float x;
		if(this.tiempo >= this.duracion){
			this.tiempo = this.duracion;
			x = 1;
			return x;
		}else{
			x = this.tiempo/this.duracion;
			return x;
		}
	}


}
