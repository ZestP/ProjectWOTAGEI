using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnConnected(NetworkMessage msg)
	{
		Debug.Log("Connected");

	}
}
