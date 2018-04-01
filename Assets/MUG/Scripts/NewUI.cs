using UnityEngine;
using System.Collections;

public class NewUI : MonoBehaviour {
	ArrayList winArrayList;
	// Use this for initialization
	void Start () {
		winArrayList=new ArrayList();
		winArrayList.Add(new Rect(winArrayList.Count*100,50,150,100));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		int count=winArrayList.Count;
		for(int i=0;i<count;i++)
		{
			winArrayList[i]=GUILayout.Window(i,(Rect)winArrayList[i],AddWindow,"窗口id:"+i);

		}
	}
	void AddWindow(int windowID)
	{
		GUILayout.BeginHorizontal();
		GUILayout.Label("这是一个全新窗");
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("添加新窗"))
		{
			winArrayList.Add(new Rect(winArrayList.Count*100,50,150,100));

		}
		if(GUILayout.Button("关闭当前窗口"))
		{
			winArrayList.RemoveAt(windowID);
		}
		GUILayout.EndHorizontal();
		GUI.DragWindow(new Rect(0,0,Screen.width,Screen.height));
	}
}
