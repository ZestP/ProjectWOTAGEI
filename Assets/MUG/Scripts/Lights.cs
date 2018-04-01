using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {
	Renderer r;
	// Use this for initialization
	void Start () {
		r=this.gameObject.GetComponent<Renderer>();
		r.sortingLayerID=0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
