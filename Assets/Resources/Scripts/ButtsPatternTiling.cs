using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtsPatternTiling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<RectTransform>().anchoredPosition.x >= 800)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(-800, 0);
        }
        GetComponent<RectTransform>().Translate(1f, 0, 0);
	}
}
