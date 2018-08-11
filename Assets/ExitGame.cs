using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour 
{

	// Quit The Game
	public void Quit()
	{
		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}
}
