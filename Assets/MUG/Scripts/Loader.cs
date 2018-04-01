using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour {
	void Start()
	{
		Time.timeScale=1;
	}
	// Use this for initialization
	public void openSingle()
	{
		SceneManager.LoadScene("Single");
	}
	public void openVersus()
	{
		SceneManager.LoadScene("Versus");
	}
	public void openCo()
	{
		SceneManager.LoadScene("Ob");
	}
}
