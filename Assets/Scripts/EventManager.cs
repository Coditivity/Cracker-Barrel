using UnityEngine;
using System.Collections;
using  UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private static EventManager eventManager;

    public delegate void RayHitDetector(RaycastHit hit);
    public event RayHitDetector RayHitDetection;

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

    public static void OnRayHitDetecion(RaycastHit hit){
        if (instance.RayHitDetection != null)
        {
            instance.RayHitDetection(hit);
        }

    }

   
}
