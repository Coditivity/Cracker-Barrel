using UnityEngine;
using System.Collections;

public class HoleAnimator : MonoBehaviour {

    //Material material;
    Color color;
    float red;
    Renderer _renderer;
	// Use this for initialization
	void Start () {

        //material = GetComponent<Renderer>().material;
        _renderer = GetComponent<Renderer>();
        color = _renderer.material.color;
        red = color.r;
	}


    int sign = 1;
	// Update is called once per frame
	void Update () {

        red -= Time.deltaTime * 1 * sign;
        if( red >= 1) 
        {
            red = 1;
            sign *= -1; 
        }
        else if (red <= .4f)
        {
            red = .4f;
            sign *= -1;
        }

        color.r = red;

        _renderer.material.color = color;
	}
}
