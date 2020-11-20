using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageEffect_30 : MonoBehaviour {

	public AnimationCurve curve;
	public float speedEffect = 1;

	private Image img;
	public float timeleft;

	public bool playOnAwake = false;

	void Start()
	{
		img = GetComponent<Image> ();
		if (playOnAwake)
			ApplyEffect ();
	}

	public void ApplyEffect()
	{
		StopCoroutine (UpdateEffect ());
		StartCoroutine (UpdateEffect ());
	}

	IEnumerator UpdateEffect()
	{
		timeleft = 1;

		while(timeleft > 0)
		{
			timeleft -= Time.deltaTime * speedEffect;
			float deltaTime = curve.Evaluate (timeleft);
			img.color = new Color (img.color.r, img.color.g, img.color.b, deltaTime);
            

            yield return null;
		}

		timeleft = 0;
		
		if(playOnAwake)
			gameObject.SetActive(false);
	}
}
