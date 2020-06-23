using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTrace : MonoBehaviour {

public Vector3 inicio;
public Vector3 fin;
private VistasC exCamera;
public  GameObject cube;
public GameObject persona;
private GameObject mirrorPoint;


void Start () {
	this.mirrorPoint = new GameObject("CameraMirror");
	this.mirrorPoint.transform.position = this.inicio;
	this.mirrorPoint.transform.SetParent(this.transform, true);
     

}
	
// Update is called once per frame
void Update () {
		
}
}
