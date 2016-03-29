using UnityEngine;
using System.Collections;

public class Hole  {

    GameObject hole;
    public bool hasPeg;
    public int Row { get; private set; }
    public int Column { get; private set; }

    public Hole(GameObject hole, bool hasPeg, int row, int column)
    {
        this.hole = hole;
        this.hasPeg = hasPeg;
        this.Row = row;
        this.Column = column;
    }

    

    public GameObject GetHole()
    {
        return hole;
    }
	
}

