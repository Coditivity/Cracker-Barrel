using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    void OnEnable()
    {
        EventManager.instance.RayHitDetection += OnRayHitDetection;
    }
    void OnDisable()
    {
        EventManager.instance.RayHitDetection -= OnRayHitDetection;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void IfPegMovable()
    {

    }

    void OnRayHitDetection(Peg peg) {

        Debug.Log("hit " + peg.hole.Row + " " + peg.hole.Column);
    }
}
