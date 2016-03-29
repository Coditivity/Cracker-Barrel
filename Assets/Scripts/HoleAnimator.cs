using UnityEngine;
using System.Collections;

public class HoleAnimator : MonoBehaviour {

    Material material;
    Color color;
    float alpha;
	// Use this for initialization
	void Start () {
        
        material = GetComponent<Renderer>().material;
        color = material.color;
        alpha = color.a;
	}


    int sign = 1;
	// Update is called once per frame
	void Update () {

        alpha -= .1f;// Time.deltaTime * 1 * sign;
      /*  if (alpha >= 1)
        {
            alpha = 1;
            sign *= -1; 
        }
        else if (alpha <= .4f)
        {
            alpha = .4f;
            sign *= -1;
        }*/

        color.a = alpha;

        material.color = color;
	}
}
