using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class networkController : MonoBehaviour {
	public GameObject Failed;
	public InputField account;
	public InputField password;

	// Use this for initialization
	void Start () {
		Failed.SetActive(false);
	}

	public void doLogin(){
		//TODO COMUNICACAO COM O BD
		if(account.text == "JOSE" && password.text == "JOSE" ){
			Application.LoadLevel ("Principal"); 
		}else{
			Failed.SetActive(true);
		}
	}

	public void closeMsgError(){
		Failed.SetActive(false);
	}
}
