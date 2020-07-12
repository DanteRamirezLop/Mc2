using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranControl : MonoBehaviour
{
    // Poner en la camara
    // 0 sin accion, 1 preparado para construir, 2 preparado para mover, 3 preparado para remover
    private int operationState;
    private GameObject grab;
    private GameObject equipoEnUso;
    public GameObject codo;
    public GameObject ducto;
    public GameObject union;
    public GameObject equipo;
    // Start is called before the first frame update
    void Start()
    {
        operationState = 0;
        grab = null;
        equipoEnUso = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab != null)
        {
            grab.transform.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            //grab.transform.position += this.transform.forward * 3;
        }
        if (Input.GetMouseButtonDown(0))
        {
            switch (operationState)
            {
                case 0:
                    BringInfo();
                    break;
                case 1:
                    BringCreate();
                    break;
                case 2:
                    BringMove();
                    break;
                case 3:
                    BringRemove();
                    break;
            }
        }
    }
    public void Creador(int a)
    {
        switch (a)
        {
            case 0:
                grab = equipo;
                equipoEnUso = equipo;
                break;
            case 1:
                grab = GameObject.Instantiate(ducto);
                break;
            case 2:
                grab = GameObject.Instantiate(codo);
                break;
        }
        grab.layer = 8; //Hold
        if (equipoEnUso != null)
            equipoEnUso.GetComponent<EquipoControl>().PulsoColision(true);
        operationState = 1;
    }
    private void BringInfo()
    {
        if (GetRayObject() == null)
            Debug.Log("undetected");
        else
            Debug.Log("detected");
    }
    private void BringCreate()
    {
        if (grab == null)
            operationState = 0; //evita un posible bug
        else
        {
            if (grab.TryGetComponent(typeof(EquipoControl), out Component e))
            {
                grab.layer = 9; //Placed
                grab = null;
                operationState = 0;
                if (equipoEnUso != null)
                    equipoEnUso.GetComponent<EquipoControl>().PulsoColision(false);
                return;
            }
            GameObject target = GetRayObject();
            if (target != null)
            {
                //en caso sea un multiple el proceso debe ser diferente
                grab.SendMessage("SetReferencia", target);
                grab.layer = 9; //Placed
                grab = null;
                if (equipoEnUso != null)
                    equipoEnUso.GetComponent<EquipoControl>().PulsoColision(false);
            }
        }
    }
    private void BringMove()
    {
        throw new NotImplementedException();
    }
    private void BringRemove()
    {
        throw new NotImplementedException();
    }
    private GameObject GetRayObject()
    {
        Ray rayo = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit, 50f, LayerMask.GetMask("Placed")))
            return hit.transform.gameObject;
        else
            return null;
    }
}
