using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDedicada : MonoBehaviour
{
    public Vector3[] cuadrante;
    private Vector3 centro;
    private Vector3 posAmbiente;
    private Transicion transicion;
    public float speed;
    public float sensitivity;
    public float caliber;

    public GameObject ambiente; //para pruebas
    // Start is called before the first frame update
    void Start()
    {
        this.speed = 5;
        this.sensitivity = 100;
        this.caliber = 500;
        this.cuadrante = null;
        transicion = new Transicion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!transicion.IsFinished())
        {
            transicion.PassTime();
            this.transform.position = transicion.SlerpTransPosition();
            this.transform.rotation = transicion.SlerpTransRotation();
            return;
        }
        if (cuadrante != null)
        {
            Direccionales();
            if (Input.GetKey(KeyCode.LeftControl))
                DesplazarCamara();
            if (Input.GetMouseButton(1))
                ControlMouse();
            if (Input.mouseScrollDelta.y != 0f)
                MoverAdelante();
        }
        else
        {
            //esta parte es para que se pueda probar
            SetCuadrante(ambiente.GetComponent<AmbienteControl>().getCuadrante(), ambiente.transform.position);
        }
    }

    private void MoverAdelante()
    {
        this.transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * speed * caliber / 10);
    }

    private void Direccionales()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(Vector3.up * -1 * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
        {
            Quaternion q = this.transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
            this.transicion.DTransicion(this.transform.position, this.transform.position, this.transform.rotation, q);
            this.transicion.SetDuracion(3, 10, 0.5f);
            return;
        }
        if (Input.GetKey(KeyCode.Q))
            this.transform.Rotate(Vector3.forward * speed * sensitivity / 10 * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            this.transform.Rotate(Vector3.forward * speed * -1 * sensitivity / 10 * Time.deltaTime);
    }
    private void ControlMouse()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Rotate(Input.GetAxis("Mouse Y") * speed * caliber * Time.deltaTime,
                Input.GetAxis("Mouse X") * speed * caliber * Time.deltaTime * -1,0,Space.Self);
        }
        else
        {
            this.transform.Translate(new Vector3(
                Input.GetAxis("Mouse X") * speed * caliber / 10 * -1 * Time.deltaTime,
                Input.GetAxis("Mouse Y") * speed * caliber / 10 * -1 *Time.deltaTime,
                0));
        }
        //this.transform.Rotate(0,0, - this.transform.eulerAngles.z,Space.Self);
    }

    private void DesplazarCamara()
    {
        Vector3 change = this.transform.position;
        Vector3 nPos = this.transform.position;
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            nPos = posAmbiente + cuadrante[0];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            nPos = posAmbiente + (cuadrante[1] + cuadrante[0]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            nPos = posAmbiente + cuadrante[1];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            nPos = posAmbiente + (cuadrante[0] + cuadrante[2]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            nPos = centro + Vector3.up * (Vector3.Distance(cuadrante[0],cuadrante[3]) + Vector3.Distance(cuadrante[1],cuadrante[2])) / 4;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            nPos = posAmbiente + (cuadrante[1] + cuadrante[3]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            nPos = posAmbiente + cuadrante[2];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            nPos = posAmbiente + (cuadrante[2] + cuadrante[3]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            nPos = posAmbiente + cuadrante[3];
        }
        if (change != nPos)
        {
            this.transicion.DTransicion(this.transform.position, nPos, this.transform.rotation,
                Quaternion.LookRotation(centro - nPos, Vector3.up));
            this.transicion.SetDuracion(3, 10, 0.5f);
            //this.transform.LookAt(this.centro);
        }
    }
    public void SetCuadrante(Vector3[] cuadrante, Vector3 posAmbiente)
    {
        this.posAmbiente = posAmbiente;
        this.cuadrante = cuadrante;
        centro = cuadrante[0] + cuadrante[1] + cuadrante[2] + cuadrante[3];
        centro /= 4;
    }
}
