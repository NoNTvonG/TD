using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour 

{
    public GUISkin skin;
	public int Window;
	void Start () 
	{
		Window = 1;
	}
	
	void OnGUI()
	{
        GUI.skin = skin;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 400, 400));
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Window == 1)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "Play"))
            {
                Window = 2;
            }
            if (GUI.Button(new Rect (10, 70, 180, 30), "Options"))
            {
                Window = 3;
            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "Exit"))
            {
                Window = 4;
            }
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Window == 2)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "New Game"))
            {
				Window = 5;
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "Continue"))
            {
                //SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "Back"))
            {
                Window = 1;
            }
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Window == 3)
        {   
            AudioListener.volume = GUI.HorizontalSlider(new Rect(10, 50, 180, 10), AudioListener.volume, 0.0F, 1.0F);
            if (GUI.Button(new Rect(10, 80, 180, 30), "Back"))
            {
                Window = 1;
            }
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Window == 4)
        {
            GUI.Label(new Rect(85, 30, 180, 30), "Exit?");
            if (GUI.Button(new Rect(10, 70, 180, 30), "Yes"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "No"))
            {
                Window = 1;
            }
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
		if (Window == 5)
		{
			GUI.Box(new Rect(10, 30, 180, 25), "Game Level");
			if(GUI.Button(new Rect(25, 70, 150, 25), "LVL 1"))
			{
				SceneManager.LoadScene(1);
			}
			if(GUI.Button(new Rect(25, 110, 150, 25), "LVL 2"))
			{
				SceneManager.LoadScene(2);
			}
			if(GUI.Button(new Rect(25, 150, 150, 25), "LVL 3"))
			{
				SceneManager.LoadScene(3);
			}
			if(GUI.Button(new Rect(25, 190, 150, 25), "Back"))
			{
				Window = 2;
			}
		}
        GUI.EndGroup();
	}
}