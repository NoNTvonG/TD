using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour 
{
	public UnityEngine.GameObject _MenuPanel;
	public UnityEngine.UI.Button _Menu;
	public UnityEngine.UI.Button _Options;
	public UnityEngine.UI.Button _Back;
	public UnityEngine.UI.Button _Exit;
	public static bool SM = false; // Забороняє будувати башні коли включена пауза
	void Start () 
	{
		_MenuPanel.SetActive(false); // стандартно меню деактивоване
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SM = true; // забороняємо будувати башні
			_MenuPanel.SetActive(true); // відкриваємо веню
			Time.timeScale = 0; // зупиняємо час
		}
	}
	public void Menu()
	{	
		SM = false; // дозворяє будувати башні
		SceneManager.LoadScene(0); // загружаємо головне меню
	}
	public void Back()
	{
		SM = false; // дозворяє будувати башні
		_MenuPanel.SetActive(false); // деактивовує панель
		Time.timeScale = 1; // відновлємо ігровий час
	}
	public void Exit()
	{
		Application.Quit(); // закриваємо гру
		Debug.Log("ff");
	}
}
