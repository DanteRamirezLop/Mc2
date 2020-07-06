using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamerav3 : MonoBehaviour {
/*variables*/
public GameObject player;
public GameObject camara;
public GameObject lockedOnTarget;
public GameObject conexionMouse;
public List<VistasC> cameraLooks = new List<VistasC>();
private Transicion transicion;   
private Vector3 actualPosition;
private Quaternion actualRotation;
private int actualView = 0;
private bool doNothing = true;
private bool disableUserCameraChange = false;
private GameObject auxiliar;
private float maxDistance;
/*del raycast*/
private RaycastHit hit;
private Ray ray;
/*del keypress*/
private int lastCallView;
private KeyCode keyDetector;
private bool encontrada; 
/*Funciones propias de unity*/


void Start () {
	this.keyDetector = KeyCode.None;
	this.encontrada = false;
	this.auxiliar = new GameObject("PlayerFollow");
	this.auxiliar.transform.SetParent(this.player.transform);
	//this.transicion = new Transicion();  //corregir
	bool z = false;
	if (this.player.GetComponent<MouseControl>()) { //verificar
		GameObject ex;
		ex = new GameObject("MouseCam");
		ex.transform.position = this.player.transform.position;
		ex.transform.rotation = this.player.transform.rotation;
		this.conexionMouse = this.player;
		this.player = ex;
		this.conexionMouse.GetComponent<MouseControl>().juegoCamaraMouse = this.player;
		this.auxiliar.transform.SetParent(this.player.transform);
	}
	if(this.player.transform != null && this.camara != null){
		if(this.cameraLooks.Count == 0){
			this.cameraLooks.Add(new VistasC());
		}else{
			this.doNothing = false;
             foreach (VistasC i in cameraLooks){
				if (i.cullingMaskIgnore == "") {
					i.cullingMaskIgnore = "None";
				}
				if (i.singleCall) {
					z = true;
				}
			}
			if (!z) {
				this.cameraLooks[0].singleCall = true;
				this.cameraLooks[0].activo = true;
				Debug.LogWarning("There must be at least one view with the property Single Call checked, the first view has been automaticly checked and setted as first view");
			}
			for (var i = 0; i < this.cameraLooks.Count; i++) {
				if (this.cameraLooks[i].activo) {
					this.actualView = i;
					this.cameraLooks[i].singleCall = true;
					this.lastCallView = this.actualView;
					//CullingMaskOrder();  //desabilitar
					return;
				}
			}
			Debug.LogError("The first view available has not been set, please check FirstView on any View");
		}
	}

}


// Update is called once per frame


void Update()
{

	if(doNothing){
		return;
	}
	if (this.conexionMouse) {
		this.player.transform.position = this.conexionMouse.transform.position;
		//this.player.transform.eulerAngles.z = 0; // lo reemplace por el codigo de abajo
        this.player.transform.eulerAngles = new Vector3(this.player.transform.eulerAngles.x, this.player.transform.eulerAngles.y, 0); //POSIBLE ERROR
	}
	if(this.disableUserCameraChange){
		ExecuteView();
		return;
	}
	if (Input.anyKeyDown) {
         foreach (VistasC i in cameraLooks){
		//for(var i :VistasC in cameraLooks){
             if (i.buttonUsage != KeyCode.None && i.singleCall) //POSIBLE ERRO POR i.buttonUsage != KeyCode.None
             {
				if(Input.GetKeyDown(i.getKey())){
					if(actualView != cameraLooks.IndexOf(i)){
						this.transicion.ResetTime();//
						this.transicion.SetDuracion(this.cameraLooks[this.actualView].duracion);
						SetOrigin();
					}
					if (this.player.transform.parent) {
						this.player.transform.localRotation = Quaternion.identity;
					}
					actualView = cameraLooks.IndexOf(i);
					this.lastCallView = actualView;
					CullingMaskOrder();
				}
			}
		}
		ExecuteView();
		return;
	}
	if (Input.anyKey) {
        foreach (VistasC i in cameraLooks){
		//for(var i :VistasC in cameraLooks){
            if (i.buttonUsage != KeyCode.None && !i.singleCall)
            {
				if(Input.GetKey(i.getKey())){
					if (this.keyDetector != i.getKey()) {
						this.transicion.SetDuracion(this.cameraLooks[this.actualView].duracion);
						this.keyDetector = i.getKey();
						this.transicion.ResetTime();
						actualView = cameraLooks.IndexOf(i);
						CullingMaskOrder();
						SetOrigin();
					}
					actualView = cameraLooks.IndexOf(i);
					this.encontrada = true;
					ExecuteView();
					return;
				}
				this.encontrada = false;
			}
		}
	}else{
		this.encontrada = false;
	}
	if (!this.encontrada) {
		if (this.keyDetector != KeyCode.None) {
			this.transicion.SetDuracion(this.cameraLooks[this.actualView].duracion);
			this.transicion.ResetTime();
			SetOrigin();
			this.keyDetector = KeyCode.None;
			actualView = this.lastCallView;
			CullingMaskOrder();
		}
	}
	ExecuteView();
}
    /*funciones privadas*/

private void ExecuteView(){
	switch(this.cameraLooks[this.actualView].getBehaviour()){
		case 0:
			AirViewEx();
			break;
		case 1:
			FollowPlayerEx();
			break;
		case 2:
			LockOnGameObjectEx();
			break;
		case 3:
			StationaryEx();
			break;
	}
	MoverCamara();
	this.transicion.PassTime();
}
private void SetOrigin(){
	this.transicion.posicionInicial = this.camara.transform.position;
	this.transicion.rotacionInicial = this.camara.transform.rotation;
}
private void MoverCamara(){
	if (this.transicion.termina) {
		this.camara.transform.position = this.transicion.posicionFinal;
		this.camara.transform.rotation = this.transicion.rotacionFinal;
	}else{
		this.camara.transform.position = this.transicion.SlerpTransPosition();
		this.camara.transform.rotation = this.transicion.SlerpTransRotation();
	}
}
/*funciones propias de camara*/
private void AirViewEx(){
	this.auxiliar.transform.position = this.cameraLooks[this.actualView].posicion + player.transform.position;
	this.auxiliar.transform.LookAt(this.player.transform);
	this.transicion.posicionFinal = auxiliar.transform.position;
	this.transicion.rotacionFinal = auxiliar.transform.rotation;
}
private void FollowPlayerEx(){
	this.auxiliar.transform.localPosition = this.cameraLooks[this.actualView].posicion;
	this.transicion.posicionFinal = HitDetector();
	if (this.cameraLooks[this.actualView].posicion == Vector3.zero) {
		this.auxiliar.transform.localRotation = Quaternion.identity;
	}else{
		auxiliar.transform.LookAt(this.player.transform);
	}
	//parte anti traspaso de camara
	this.transicion.posicionFinal = Vector3.MoveTowards(this.transicion.posicionFinal, this.player.transform.position, this.camara.GetComponent<Camera>().nearClipPlane);
	this.transicion.rotacionFinal = this.auxiliar.transform.rotation;
}
private void LockOnGameObjectEx(){
	if(this.lockedOnTarget == null){
		Debug.Log("There is no target, using follow player");
		FollowPlayerEx();
		return;
	}
	this.player.transform.LookAt(this.lockedOnTarget.transform);
	this.auxiliar.transform.localPosition = this.cameraLooks[this.actualView].posicion;
	this.transicion.posicionFinal = auxiliar.transform.position;
	this.transicion.rotacionFinal = auxiliar.transform.rotation;
}
private void StationaryEx(){
	this.transicion.posicionFinal = this.cameraLooks[this.actualView].posicion;
	this.transicion.rotacionFinal = this.cameraLooks[this.actualView].getQRotation();
}
private Vector3 HitDetector(){

	this.ray = new Ray(this.player.transform.position, this.auxiliar.transform.position - this.player.transform.position);
   //*******agrege*****
    Vector3 myVector;
    Vector3 myVector2;

    myVector = new Vector3(0.0f, 0.0f, 0.0f);
    myVector2 = new Vector3(0.0f, 0.0f, 0.0f);

    myVector2 = this.cameraLooks[this.actualView].posicion;

    float distancia = Vector3.Distance(myVector, myVector2);
    //******************
    //if (Physics.Raycast(this.ray,this.hit,Vector3.Distance(Vector3(0, 0, 0), this.cameraLooks[this.actualView].posicion),QueryTriggerInteraction.Ignore))
    if (Physics.Raycast(this.ray, out this.hit, distancia))
    {
        if (this.hit.collider != null)
        {  //this.hit != null
			return this.hit.point;
		}else{
			return this.auxiliar.transform.position;
		}
	}
	return this.auxiliar.transform.position;
}

private void CullingMaskOrder(){
	//Debug.Log(this.cameraLooks[this.actualView].cullingMaskIgnore);
	if (LayerMask.NameToLayer(this.cameraLooks[this.actualView].cullingMaskIgnore) != -1) {
		this.GetComponent<Camera>().cullingMask &= ~(1<<LayerMask.NameToLayer(this.cameraLooks[this.actualView].cullingMaskIgnore));
		//Debug.Log("fui llamado");
	}else{
		//Debug.Log("todo");
        this.GetComponent<Camera>().cullingMask = -1;  //0xffffffff; //POSIBLE ERROR ****************************+
	}
}
/*funciones publicas*/
public void ChangeView(int view){
	if(view > this.cameraLooks.Count-1){
		Debug.LogError("No Camera Found");
		return;
	}
	if (this.actualView != view){
		this.transicion.ResetTime();
		SetOrigin();
		this.transicion.SetDuracion(this.cameraLooks[view].duracion);
		this.lastCallView = view;
		this.actualView = view;
		CullingMaskOrder();
	}
}
public void ChangePlayer(GameObject player1){
	this.player = player1;
	this.auxiliar.transform.SetParent(this.player.transform);
	this.transicion.ResetTime();
	this.transicion.SetDuracion(this.cameraLooks[this.actualView].duracion);
	SetOrigin();
}
public void SetMouseListener(GameObject mouseListen){
	this.conexionMouse = mouseListen;
}
public void ChangeLockTarget(GameObject target){
	this.lockedOnTarget = target;
}
public void GetNewCamera(VistasC camaraNueva){
	this.cameraLooks.Add(camaraNueva);
	this.ChangeView(this.cameraLooks.Count-1);
}
public void DeleteLast(){
	if(this.cameraLooks.Count == 1){
		Debug.LogError("The Script needs at least one view");
		return;
	}
	this.actualView = 0;
	this.cameraLooks.RemoveAt(this.cameraLooks.Count-1);
}
public void DeleteLast(int vista){
	if(this.cameraLooks.Count == 1){
		Debug.LogError("The Script needs at least one view");
		return;
	}
	if (vista > this.cameraLooks.Count-1) {
		Debug.LogError("The index surpasses the quantity of camera views");
		return;
	}
	this.actualView = vista;
	this.cameraLooks.RemoveAt(this.cameraLooks.Count-1);
}
public void DisableUserControls(bool stat){
	this.disableUserCameraChange = stat;
}




}
