using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

public float sensibilidadV;
public float sensibilidadH;
public GameObject juegoCamaraMouse;
private bool congelar;
private bool cursorMov;
private bool toggleFunction;

	// Use this for initialization


void Start () {
    this.cursorMov = false;
    this.toggleFunction = false;
    Cursor.lockState = CursorLockMode.Locked;
}
	
	// Update is called once per frame
void Update () {
    if (!this.juegoCamaraMouse)
    {
        return;
    }
    if (this.congelar)
    {
        return;
    }
    if (!this.cursorMov)
    {
        this.juegoCamaraMouse.transform.Rotate(-1 * Input.GetAxis("Mouse Y") * this.sensibilidadH, Input.GetAxis("Mouse X") * this.sensibilidadV, 0);
        this.juegoCamaraMouse.transform.eulerAngles = new Vector3 (this.juegoCamaraMouse.transform.eulerAngles.x,this.juegoCamaraMouse.transform.eulerAngles.y,0);
        //this.juegoCamaraMouse.transform.eulerAngles.z = 0; // se reemplazo por la linea de arriba   //POSIBLE ERROR
    }
    if (this.toggleFunction)
        return;
    if (Input.GetKeyDown(KeyCode.LeftControl))
    {
        Cursor.lockState = CursorLockMode.None;
        this.cursorMov = true;
    }
    if (Input.GetKeyUp(KeyCode.LeftControl))
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.cursorMov = false;
    }	
}

public void ToggleFreeCursor()
{
    this.toggleFunction = !this.toggleFunction;
    this.cursorMov = !this.cursorMov;
    if (this.cursorMov)
    {
        Cursor.lockState = CursorLockMode.None;
    }
    else
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
public void CanMove(bool move){
	this.congelar = move;
}

}
