using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpc : MonoBehaviour
{
    public GameObject lblAmbiente;
    public GameObject dropAmbiente;
    public GameObject btnAmbiente;

    private void Start()
    {
        //Debug.Log("max: " + this.GetComponent<RectTransform>().rect.width);
    }
    public void HideHalf(bool hide)
    {
        RectTransform a = this.GetComponent<RectTransform>();
        if (hide)
        {
            //a.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, a.sizeDelta.x / 2);
            //a.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, a.sizeDelta.x / 2);
            //a.sizeDelta = new Vector2(a.sizeDelta.x / 2, a.sizeDelta.y);
            a.offsetMax = new Vector2(Screen.width * -1 + 200, 0);
            //Debug.Log("Halt");
        }
        else
        {
            a.offsetMax = new Vector2(0, 0);
            //a.sizeDelta = new Vector2(a.rect.xMax, a.sizeDelta.y);
        }
        lblAmbiente.SetActive(!hide);
        dropAmbiente.SetActive(!hide);
        btnAmbiente.SetActive(!hide);
    }
    
}
