using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
///  Class handles level related tasks as well as switching scenes
/// </summary>
public class LevelManager : MonoBehaviour {

	/// <summary>
	/// The auto load next level when set to 0f does not load next level.
	/// </summary>
	public float autoLoadNextLevel;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		if (autoLoadNextLevel != 0f)
		{
			Invoke("LoadNextLevel", autoLoadNextLevel);
		}
		else if (autoLoadNextLevel < 0)
		{
			Debug.LogWarning("Must load level after positive amount of time");
		}
	}

	/// <summary>
	///  Open new scenes
	/// </summary>
	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	/// <summary>
	///  Quit game
	/// </summary>
	public void QuitRequest(){
		Application.Quit ();
	}

	/// <summary>
	/// Loads the next level.
	/// </summary>
	public void LoadNextLevel(){
		SceneManager.LoadScene ("StartMenu");
	}

}
