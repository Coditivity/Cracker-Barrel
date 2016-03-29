using UnityEngine;
using System.Collections;
using  UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private static EventManager eventManager;

    //public delegate void RayHitDetector(RaycastHit hit);
    public delegate void RayHitDetector(Peg peg);
    public delegate void HoleMouseDetector(Hole hole);
    public event RayHitDetector RayHitDetection;
    public event HoleMouseDetector HoleMouseDetection;

    public static EventManager instance
    {

        get
        {
            if (eventManager == null)
            {
                eventManager = (EventManager)FindObjectOfType<EventManager>();

                if (eventManager == null)
                {
                    Debug.LogError("An EventManager script needs to be attached to a gamescript");
                }
            }
            
            return eventManager;
        }    
    
    }

    public static void OnRayHitDetecion(Peg peg){
        if (instance.RayHitDetection != null)
        {
            instance.RayHitDetection(peg);
        }

    }

    public static void OnHoleMouseDetection(Hole hole)
    {
        if (instance.HoleMouseDetection != null)
        {
            instance.HoleMouseDetection(hole);
        }
    }

   
}
