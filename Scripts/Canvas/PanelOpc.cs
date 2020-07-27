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
        HideHalf(true);
    }
    public void HideHalf(bool hide)
    {
        RectTransform a = this.GetComponent<RectTransform>();
        if (hide)
        {
            //a.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, a.sizeDelta.x / 2);
            //a.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, a.sizeDelta.x / 2);
            a.offsetMax = new Vector2(0.5f, 1);
            //a.sizeDelta = new Vector2(a.sizeDelta.x / 2, a.sizeDelta.y);
            Debug.Log("Halt");
        }
        else
        {
            a.sizeDelta = new Vector2(a.rect.xMax, a.sizeDelta.y);
        }
    }
    
}
