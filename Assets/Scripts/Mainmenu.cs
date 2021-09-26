using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
	// Start is called before the first frame update
	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Application.Quit();
		Debug.Log("You have clicked the button!");
	}
}
