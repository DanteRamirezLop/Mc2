using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoMC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<Mesh>();
        if (mesh == null)
            Debug.Log("Sin mesh");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Creator()
    {

    }
}
