using UnityEngine;
using System.Collections;

public class myUI : MonoBehaviour {
	public GUISkin mySkin;
	public string str,myInfo;
	public int score,combo;
	//GUIStyle b;
	// Use this for initialization
	void Start () {
		//b=new GUIStyle();
		//b.normal.textColor=Color.white;
		//b.fontSize=40;
		score=0;
		combo=0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
//		GUI.Label(new Rect(50,50,100,30),str,b);
//		GUI.Label(new Rect(50,0,100,30),score.ToString(),b);
//		GUI.Label(new Rect(50,150,100,30),combo.ToString(),b);
		GUI.skin=mySkin;
		GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
		GUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();
		GUILayout.Label(score.ToString());
		GUILayout.Space(10);


		GUILayout.EndHorizontal();

		GUILayout.Label(str);
		GUILayout.Label(combo.ToString());
		GUILayout.Label(myInfo);
		if(GUILayout.Button("End"))
		{
			Application.Quit();
		}
		GUILayout.EndArea();
	}
	public void setStr(string s)
	{
		if(s=="Miss")
		{
			combo=0;
		}else{
			combo++;
		}
		str=s;
	}
	public void setScore(int s)
	{
		score+=s;
	}
	public void setInfo(string s)
	{
		myInfo=s;
	}
}
