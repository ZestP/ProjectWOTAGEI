using UnityEngine;
using System.Collections;
using HighlightingSystem;
public class FlashController : MonoBehaviour {
	protected Highlighter h;
	// Use this for initialization
	void Awake()
	{
		h = GetComponent<Highlighter>();
		if (h == null) { h = gameObject.AddComponent<Highlighter>(); }
	}
	void Start()
	{
		//Shine();
	}
	// 
	public void Shine()
	{
		h.FlashingOff();
		h.ConstantOnImmediate(Color.cyan);
		h.ConstantOff();
	}
	public void OneShine()
	{
		h.On(Color.cyan);
	}
	public void OnFlashing()
	{
		h.FlashingOn(Color.cyan,Color.blue,3f);
	}
	public void OffFlashing()
	{
		h.FlashingOff();
	}
}
