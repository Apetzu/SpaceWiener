using UnityEngine;
using System.Collections;

public class linkScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void LinkToLicenseFont()
	{
		Application.OpenURL("https://www.creativecommons.org/licenses/by/4.0");
	}
	public void LinkToMaterialFont()
	{
		Application.OpenURL("http://www.fontsquirrel.com/fonts/blogger-sans");
	}
	public void LinkToLicenseSoundCash()
	{
		Application.OpenURL("http://creativecommons.org/licenses/by/3.0/");
	}
	public void LinkToMaterialSoundCash()
	{
		Application.OpenURL("http://freesound.org/people/kiddpark/sounds/201159/");
	}
	public void LinkToLicenseSoundMachine()
	{
		Application.OpenURL("http://creativecommons.org/licenses/by/3.0/");
	}
	public void LinkToMaterialSoundCashMachine()
	{
		Application.OpenURL("http://opengameart.org/content/collaboration-sound-effects-machine-001");
	}
}
