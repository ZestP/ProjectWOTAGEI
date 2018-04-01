using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.Networking;
using System.Net.NetworkInformation;
using UnityEngine.SceneManagement;
public class VersusUI : myUGUI {


	[SerializeField] protected Text tOpScore,tOpGei,tOpGeis,tMyGeis,tIP,tIPAdd,tGei1text,tGei2text,tGei3text;
	[SerializeField] protected GameObject tGei1,tGei2,tGei3,tCountdown,tMyBar,tOpBar,tInitPanel,tGeiPanel,tMyDsBar,tOpDsBar;
	public Dropdown tAtkGeiSel,tDefGeiSel,tHealGeiSel;
	public NetSync myDataSync,opDataSync;
	public int opScore,maxScore,myDs,opDs,maxDs;
	public Slider slider;
	public NoteGenMan gen;
	public int atk,def,heal;
	protected int[] temp;
	public ArrayList selectedGeis;
	public bool isChrous;
	void Start()
	{
		isChrous=false;
		gen=GameObject.Find("Reader").GetComponent<NoteGenMan>();
		score=0;
		maxScore=49999;
		maxDs=4999;
		myDs=0;
		opDs=0;
		combo=0;
		opScore=0;
		tPanel.SetActive(false);
		tOpScore.gameObject.SetActive(false);
		tOpGei.gameObject.SetActive(false);
		tOpGeis.gameObject.SetActive(false);
		tMyGeis.gameObject.SetActive(false);
		tGei1.SetActive(false);
		tGei2.SetActive(false);
		tGei3.SetActive(false);
		tCountdown.SetActive(false);
		tOpBar.SetActive(false);
		tBtn.SetActive(false);
		FirstDisplay();
		this.DeactivitateInitPanel();
		this.ActivitateGeiPanel();
		DeactivitateMe();
		Time.timeScale=0;
		audio.Pause();
	}
	void Update()
	{
		tMyBar.transform.localScale=new Vector3(((float)score)/maxScore,1,1);
		tOpBar.transform.localScale=new Vector3(((float)opScore)/maxScore,1,1);
		tMyDsBar.transform.localScale=new Vector3(((float)myDs)/maxDs,1,1);
		tOpDsBar.transform.localScale=new Vector3(((float)opDs)/maxDs,1,1);
	}
	// Use this for initialization

	public override void setScore(int s)
	{
		//Debug.Log("ser");
		if(!isChrous)
		{
			score+=(int)(s*(1+(float)combo/10));
			tScore.text="我方得分:"+score.ToString()+"+"+(int)(s*(1+(float)combo/10));
			myDataSync.CmdUpdateScore(score);
		}else{
			UpdateMyDs(s);
		}
	}
	public void setScoreWithCustomMultiplier(int s,float mult)
	{
		score+=s;
		tScore.text="我方得分:"+score.ToString()+"+"+s*mult;
	}

	public override void FinalDisplay()
	{
		isFinal=true;
		DeactivitateOp();
		changeBlur();
		tFinalScore.text="Score:"+score.ToString();
		tScore.gameObject.SetActive(false);
		tStatus.gameObject.SetActive(false);
		tLog.gameObject.SetActive(false);
		tBtn.SetActive(false);
		tPanel.SetActive(true);
	}



	public void SyncOpScore(int s)
	{
		opScore=s;
		tOpScore.text="对方得分:"+opScore.ToString();
	}
	public void UpdateMyDs(int s)
	{
		if(gen.isFactor)
		{
			myDs+=(int)(s*(1+(float)combo/10)*gen.factor);
		}else{
			myDs+=(int)(s*(1+(float)combo/10));
		}
		myDataSync.CmdUpdateDs(myDs);
	}
	public void SyncOpDs(int s)
	{
		opDs=s;
	}
	public void ActivitateOp()
	{
		tOpScore.gameObject.SetActive(true);
		tOpGeis.gameObject.SetActive(true);
		tMyGeis.gameObject.SetActive(true);
		tOpBar.SetActive(true);
		StartCoroutine(UpdateOpGeis());
		tMyGeis.text="对手技表：攻击="+((Gei_data)gen.gei[(int)selectedGeis[0]]).name+"\n防御="+((Gei_data)gen.gei[(int)selectedGeis[1]]).name+"\n回复="+((Gei_data)gen.gei[(int)selectedGeis[2]]).name;
	}
	public void DeactivitateOp()
	{
		tOpScore.gameObject.SetActive(false);
		tOpGei.gameObject.SetActive(false);
		tOpGeis.gameObject.SetActive(false);
		tMyGeis.gameObject.SetActive(false);
		tGei1.SetActive(false);
		tGei2.SetActive(false);
		tGei3.SetActive(false);
		tCountdown.SetActive(false);
		tOpBar.SetActive(false);

	}
	public void ActivitateGeiSel()
	{
		myDs=0;
		opDs=0;
		temp=new int[3];
		for(int i=0;i<3;i++)
		{
			temp[i]=-1;
		}
		for(int i=0;i<3;i++)
		{
			int t;
			while(temp[t=Random.Range(0,3)]!=-1);
			temp[t]=i;
		}
		//Debug.Log(temp);
		tGei1text.text=((Gei_data)gen.gei[(int)selectedGeis[temp[0]]]).name;
		tGei2text.text=((Gei_data)gen.gei[(int)selectedGeis[temp[1]]]).name;
		tGei3text.text=((Gei_data)gen.gei[(int)selectedGeis[temp[2]]]).name;

		tGei1.GetComponent<Button>().interactable=true;
		tGei2.GetComponent<Button>().interactable=true;
		tGei3.GetComponent<Button>().interactable=true;

		tGei1.SetActive(true);
		tGei2.SetActive(true);
		tGei3.SetActive(true);
		gen.isOpSelected=false;
		isChrous=true;
	}
	public void DeactivitateGeiSel()
	{
		tGei1.SetActive(false);
		tGei2.SetActive(false);
		tGei3.SetActive(false);
		HideOpGeiState();
	}
	public void UpdateOpGeiState(string name)
	{
		tOpGei.gameObject.SetActive(true);
		tOpGei.text="对手选择了："+name;
		tCountdown.SetActive(true);
		slider.value=0;
	}
	public void HideOpGeiState()
	{
		tOpGei.gameObject.SetActive(false);
		slider.gameObject.SetActive(false);

	}
	public void UpdateCountdown(float t)
	{
		slider.value=t;
		if(t>=1)
		{
			slider.gameObject.SetActive(false);
			if(((Gei_data)gen.gei[gen.opSelectedGei]).type==1)
			{
				if(temp[0]==1)
				{
					tGei1.GetComponent<Button>().interactable=false;
				}else if(temp[1]==1)
				{
					tGei2.GetComponent<Button>().interactable=false;
				}else if(temp[2]==1)
				{
					tGei3.GetComponent<Button>().interactable=false;
				}
			}else if(((Gei_data)gen.gei[gen.opSelectedGei]).type==3)
			{
				if(temp[0]==0)
				{
					tGei1.GetComponent<Button>().interactable=false;
				}else if(temp[1]==0)
				{
					tGei2.GetComponent<Button>().interactable=false;
				}else if(temp[2]==0)
				{
					tGei3.GetComponent<Button>().interactable=false;
				}
			}
		}

	}
	public void Gei1()
	{
		if(myDataSync!=null)myDataSync.CmdUpdateGei((int)selectedGeis[temp[0]]);
		DeactivitateGeiSel();
		gen.FindPn((int)selectedGeis[temp[0]]);
	}
	public void Gei2()
	{
		if(myDataSync!=null)myDataSync.CmdUpdateGei((int)selectedGeis[temp[1]]);
		DeactivitateGeiSel();
		gen.FindPn((int)selectedGeis[temp[1]]);
	}
	public void Gei3()
	{
		if(myDataSync!=null)myDataSync.CmdUpdateGei((int)selectedGeis[temp[2]]);
		DeactivitateGeiSel();
		gen.FindPn((int)selectedGeis[temp[2]]);
	}
	public void CreateHost()
	{
		NetworkManager.singleton.StartHost();
		tIP.text="主机IP地址："+Network.player.ipAddress;

	}
	public void Connect()
	{
		NetworkManager.singleton.networkAddress=tIPAdd.text;
		NetworkManager.singleton.StartClient();
	}
	public void ActivitateInitPanel()
	{
		tInitPanel.SetActive(true);
	}
	public void DeactivitateInitPanel()
	{
		if(myDataSync!=null)
		{
			if(gen.atkGeis.Count>0)
				myDataSync.CmdUpdateAtkGei((int)gen.atkGeis[tAtkGeiSel.value]);
			if(gen.defGeis.Count>0)
				myDataSync.CmdUpdateDefGei((int)gen.defGeis[tDefGeiSel.value]);
			if(gen.healGeis.Count>0)
				myDataSync.CmdUpdateHealGei((int)gen.healGeis[tHealGeiSel.value]);
		}
		selectedGeis=new ArrayList();
		selectedGeis.Add((int)gen.atkGeis[tAtkGeiSel.value]);
		selectedGeis.Add((int)gen.defGeis[tDefGeiSel.value]);
		selectedGeis.Add((int)gen.healGeis[tHealGeiSel.value]);

		tInitPanel.SetActive(false);
	}
	public void ActivitateGeiPanel()
	{
		tGeiPanel.SetActive(true);
		tAtkGeiSel.ClearOptions();
		tDefGeiSel.ClearOptions();
		tHealGeiSel.ClearOptions();

		ArrayList tmp=gen.atkGeis;

		List<Dropdown.OptionData> tt = new List<Dropdown.OptionData>();
		for(int i=0;i<tmp.Count;i++)
		{
			//Debug.Log("atk+"+((Gei_data)gen.gei[(int)tmp[i]]).name);

			Dropdown.OptionData ttt = new Dropdown.OptionData();
			if(((int)tmp[i])!=14)
			{
				ttt.text=((Gei_data)gen.gei[(int)tmp[i]]).name;
				tt.Add(ttt);
			}
		}
		tAtkGeiSel.AddOptions(tt);
		tt = new List<Dropdown.OptionData>();
		tmp=gen.defGeis;
		for(int i=0;i<tmp.Count;i++)
		{
			//Debug.Log("def+"+((Gei_data)gen.gei[(int)tmp[i]]).name);
			Dropdown.OptionData ttt = new Dropdown.OptionData();
			ttt.text=((Gei_data)gen.gei[(int)tmp[i]]).name;
			tt.Add(ttt);
		}
		tDefGeiSel.AddOptions(tt);
		tt = new List<Dropdown.OptionData>();
		tmp=gen.healGeis;
		for(int i=0;i<tmp.Count;i++)
		{
			//Debug.Log("heal+"+((Gei_data)gen.gei[(int)tmp[i]]).name);
			Dropdown.OptionData ttt = new Dropdown.OptionData();
			ttt.text=((Gei_data)gen.gei[(int)tmp[i]]).name;
			tt.Add(ttt);
		}
		tHealGeiSel.AddOptions(tt);

	}
	public void DeactivitateGeiPanel()
	{
		tGeiPanel.SetActive(false);
	}
	public void GetReady()
	{
		ActivitateInitPanel();
		DeactivitateGeiPanel();
		//StartGame();
	}
	public void StartGame()
	{
		if(myDataSync.isReady&&opDataSync.isReady)
		{
			ActivitateOp();
			DeactivitateGeiPanel();
			Time.timeScale=1;
			audio.Play();
		}
	}
	public void CalDs()
	{
		int result=0;
		if(((Gei_data)gen.gei[gen.selectedGei]).type!=1)
		{
			result+=myDs;
		}
		if(((Gei_data)gen.gei[gen.opSelectedGei]).type==1)
		{
			result-=opDs;
		}
		if(((Gei_data)gen.gei[gen.selectedGei]).type==2)
		{
			if(result>0)
			{
				result=0;
			}
		}
		setScoreWithCustomMultiplier(result,1);
	}
	IEnumerator UpdateOpGeis()
	{
		yield return new WaitForSeconds(1);
		tOpGeis.text="对手技表：攻击="+((Gei_data)gen.gei[atk]).name+"\n防御="+((Gei_data)gen.gei[def]).name+"\n回复="+((Gei_data)gen.gei[heal]).name;
	}
}
