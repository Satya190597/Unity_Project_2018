﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public void LoadByIndex(int scene_index)
	{
		SceneManager.LoadScene (scene_index);
	}
}
