using UnityEngine;
using System.Collections;

public class Hole  {

    GameObject hole;
    public bool hasPeg;

    public Hole(GameObject hole, bool hasPeg)
    {
        this.hole = hole;
        this.hasPeg = hasPeg;
    }

    public GameObject GetHole()
    {
        return hole;
    }
	
}
