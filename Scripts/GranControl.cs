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
    public GameObject codo;
    public GameObject ducto;
    public GameObject union;
    public GameObject equipo;
    // Start is called before the first frame update
    void Start()
    {
        operationState = 0;
        grab = null;
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
    public void BetaCreate(int a)
    {
        switch (a)
        {
            case 0:
                grab = equipo;
                break;
            case 1:
                grab = GameObject.Instantiate(ducto);
                break;
            case 2:
                grab = GameObject.Instantiate(codo);
                break;
        }
        operationState = 1;
    }
    private void BringInfo()
    {
        Debug.Log("para el canvas");
    }
    private void BringCreate()
    {
        if (grab == null)
            operationState = 0; //evita un posible bug
        else
        {
            
            GameObject target = GetRayObject();
            if (target != null)
            {
                //en caso sea un multiple el proceso debe ser diferente
                target.GetComponent<ObjectControlMain>().SetReferencia(grab);
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
        if (Physics.Raycast(rayo, out hit, 50f))
            return hit.transform.gameObject;
        else
            return null;
    }
}
