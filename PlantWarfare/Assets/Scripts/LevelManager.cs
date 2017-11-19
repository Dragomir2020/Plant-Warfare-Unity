using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
///  Class handles level related tasks as well as switching scenes
/// </summary>
public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	void Start(){
		Debug.LogWarning ("Yasss");
		if (autoLoadNextLevel != 0f) {
			Invoke ("LoadNextLevel", autoLoadNextLevel);
		}
	}

	/// <summary>
	///  Open new scenes
	/// </summary>
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	/// <summary>
	///  Quit game
	/// </summary>
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene ("StartMenu");
	}

}
