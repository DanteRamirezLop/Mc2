using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDedicada : MonoBehaviour
{
    public Vector3[] cuadrante;
    private Vector3 centro;
    private Vector3 posAmbiente;
    public bool habil;

    public GameObject ambiente; //para pruebas
    // Start is called before the first frame update
    void Start()
    {
        this.cuadrante = null;
        this.habil = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cuadrante != null)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                DesplazarCamara();
            }
            if (Input.GetMouseButton(1))
            {
                RotarCamara();
            }
        }
        else
        {
            SetCuadrante(ambiente.GetComponent<AmbienteControl>().getCuadrante(), ambiente.transform.position);
        }
    }

    private void RotarCamara()
    {
        float sensibilidad = 100f;
        float speed = 10f;
        this.transform.Rotate(Input.GetAxis("Mouse Y") * speed * sensibilidad * Time.deltaTime,
            Input.GetAxis("Mouse X") * speed * sensibilidad * Time.deltaTime * -1,0,Space.Self);
        //this.transform.Rotate(0,0, - this.transform.eulerAngles.z,Space.Self);
    }

    private void DesplazarCamara()
    {
        Vector3 change = this.transform.position;
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            this.transform.position = posAmbiente + cuadrante[0];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            this.transform.position = posAmbiente + (cuadrante[1] + cuadrante[0]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            this.transform.position = posAmbiente + cuadrante[1];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            this.transform.position = posAmbiente + (cuadrante[0] + cuadrante[2]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            this.transform.position = centro + Vector3.up * (Vector3.Distance(cuadrante[0],cuadrante[3]) + Vector3.Distance(cuadrante[1],cuadrante[2])) / 4;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            this.transform.position = posAmbiente + (cuadrante[1] + cuadrante[3]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            this.transform.position = posAmbiente + cuadrante[2];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            this.transform.position = posAmbiente + (cuadrante[2] + cuadrante[3]) / 2;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            this.transform.position = posAmbiente + cuadrante[3];
        }
        if (change != this.transform.position)
            this.transform.LookAt(this.centro);
    }
    public void SetCuadrante(Vector3[] cuadrante, Vector3 posAmbiente)
    {
        this.posAmbiente = posAmbiente;
        this.cuadrante = cuadrante;
        centro = cuadrante[0] + cuadrante[1] + cuadrante[2] + cuadrante[3];
        centro /= 4;
    }
    public void SetHabil(bool habil)
    {
        this.habil = habil;
    }
}
