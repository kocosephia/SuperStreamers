using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageState : MonoBehaviour {

    public int bone;
    public int blood;
    public int flesh;

    public Text boneText;
    public Text bloodText;
    public Text fleshText;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        boneText.text = "bone: " + bone.ToString();
        bloodText.text = "blood: " + blood.ToString();
        fleshText.text = "flesh: " + flesh.ToString();



    }
    public void killKoala()
    {
        bone++;
        blood++;
        flesh++;
    }
}
