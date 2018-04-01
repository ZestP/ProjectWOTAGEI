using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
public class myUGUI : MonoBehaviour {
	[SerializeField] protected Text tScore,tStatus,tLog,tName,tFinalScore;
	[SerializeField] protected GameObject tPanel,tBtn;
	[SerializeField] protected AudioSource audio;
	[SerializeField] protected Blur bEye,bUI,bNote;

	public bool isFinal;
	protected string str,myInfo;
	public int score,combo;
	void Start()
	{
		score=0;
		combo=0;
		tPanel.SetActive(false);
		isFinal=false;
		FirstDisplay();
	}
	// Use this for initialization
	public void exit()
	{
		Application.Quit();
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
		tStatus.text=s+'\n'+combo.ToString();
	}

	public virtual void setScore(int s)
	{
		score+=(int)(s*(1+(float)combo/10));
		tScore.text="Score:"+score.ToString();
	}
	public void setInfo(string s)
	{
		myInfo=s;
		tLog.text=s;
	}
	public virtual void FinalDisplay()
	{
		isFinal=true;
		changeBlur();
		tFinalScore.text="Score:"+score.ToString();
		tScore.gameObject.SetActive(false);
		tStatus.gameObject.SetActive(false);
		tLog.gameObject.SetActive(false);
		tBtn.SetActive(false);
		tPanel.SetActive(true);
	}
	public void FirstDisplay()
	{
		tName.text=audio.clip.name;
		Destroy(tName.gameObject,3.0f);
		Invoke("changeBlur",3.0f);
	}
	public void Retry()
	{
		SceneManager.LoadScene("Loader");

	}
	public void changeBlur()
	{
		bEye.enabled=!bEye.enabled;
		bNote.enabled=!bNote.enabled;
		bUI.enabled=!bUI.enabled;
	}
	public void ActivitateMe()
	{
		tScore.gameObject.SetActive(true);
		tBtn.SetActive(true);
		tName.gameObject.SetActive(true);
		tStatus.gameObject.SetActive(true);
	}
	public void DeactivitateMe()
	{
		tScore.gameObject.SetActive(false);
		tBtn.SetActive(false);
		tName.gameObject.SetActive(false);
		tStatus.gameObject.SetActive(false);
	}
}
