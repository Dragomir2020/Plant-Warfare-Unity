using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	/// <summary>
	/// The fade in time.
	/// </summary>
	public float fadeInTime;
	/// <summary>
	/// The fade panel.
	/// </summary>
	private Image fadePanel;
	/// <summary>
	/// The color of the current fade in panel.
	/// </summary>
	private Color currentColor = Color.black;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		fadePanel = GetComponent<Image> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update(){
		if (Time.timeSinceLevelLoad < fadeInTime) {
			//Set fade in panel active if off
			if (!this.isActiveAndEnabled) {
				gameObject.SetActive (true);
			}
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}

}
