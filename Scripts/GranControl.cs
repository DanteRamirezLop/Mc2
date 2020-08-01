using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GranControl : MonoBehaviour
{
    // Poner en la camara
    // 0 sin accion, 1 preparado para construir, 2 preparado para mover, 3 preparado para remover
    private int operationState;
    private Camera cachedCamera;
    private GameObject grab;
    private GameObject equipoEnUso;
    public GameObject codo;
    public GameObject ducto;
    public GameObject union;
    public GameObject equipo;
    public MultiCanvas canvasControl;
    public GameObject Opciones;
    // Start is called before the first frame update
    void Start()
    {
        cachedCamera = this.GetComponent<Camera>();
        operationState = 0;
        grab = null;
        equipoEnUso = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab != null && operationState == 1)
        {
            grab.transform.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 5);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (operationState)
            {
                case 1:
                    break;
                default:
                    break;
            }
            grab = null;
            operationState = 0;

        }
    }
    public void Creador(int a)
    {
        switch (a)
        {
            case 0:
                grab = GameObject.Instantiate(equipo);
                equipoEnUso = grab;
                equipoEnUso.GetComponent<EquipoControl>().InitOrder();
                break;
            case 1:
                grab = GameObject.Instantiate(ducto);
                break;
            case 2:
                grab = GameObject.Instantiate(codo);
                break;
            case 3:
                grab = GameObject.Instantiate(union);
                break;
        }
        grab.SetActive(true);
        grab.SendMessage("ChangeLayer", 8);
        if (equipoEnUso != null)
            equipoEnUso.GetComponent<EquipoControl>().PulsoColision(true);
        operationState = 1;
    }
    private void BringInfo()
    {
        grab = GetRayObject();
        if (grab == null)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                Debug.Log("OVER UI");
            else
                HideInspector();
        }
        else
            BringInspector();
    }

    private void HideInspector()
    {
        canvasControl.SetGrab(null);
        Opciones.GetComponent<PanelOpc>().HideHalf(false);
    }

    private void BringInspector()
    {
        grab = grab.transform.parent.gameObject;
        canvasControl.SetGrab(grab);
        Opciones.GetComponent<PanelOpc>().HideHalf(true);
    }

    private void BringCreate()
    {
        if (grab == null)
            operationState = 0; //evita un posible bug
        else
        {
            if (grab.TryGetComponent(typeof(EquipoControl), out Component e))
            {
                grab.GetComponent<ObjectControlMain>().ChangeLayer(9);
                grab = null;
                operationState = 0;
                if (equipoEnUso != null)
                    equipoEnUso.GetComponent<EquipoControl>().PulsoColision(false);
                return;
            }
            GameObject target = GetRayObject();
            if (target != null)
            {
                ObjectControlMain min = grab.GetComponent<ObjectControlMain>();
                min.SetConexion(target.GetComponent<MiniColision>().GetConexion());
                min.SetReferencia(target.transform.parent.gameObject);
                min.ChangeLayer(9);
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
        if (EventSystem.current.IsPointerOverGameObject())
            return null;
        Ray rayo = cachedCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit, 50f, LayerMask.GetMask("Placed")))
            return hit.transform.gameObject;
        else
            return null;
    }
}
