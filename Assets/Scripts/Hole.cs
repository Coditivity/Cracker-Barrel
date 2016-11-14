using UnityEngine;
using System.Collections;

public class Hole  {


    HoleAnimator holeAnimator;
    GameObject hole;
    public bool hasPeg;
    public int Row { get; private set; }
    public int Column { get; private set; }
    public string ColliderName { get; private set; }
    public Peg Peg { get; set; }

    public Hole(GameObject hole, bool hasPeg, int row, int column)
    {
        this.hole = hole;
        this.hasPeg = hasPeg;
        this.Row = row;
        this.Column = column;
        holeAnimator = hole.GetComponent<HoleAnimator>();
        holeAnimator.enabled = false;
        ColliderName = "HC" + row.ToString() + column.ToString();
        hole.GetComponent<Collider>().name = ColliderName;
    }

    

    public GameObject GetHole()
    {
        return hole;
    }
    public void StartAnimation()
    {

        holeAnimator.enabled = true;
    }
    public void StopAnimation()
    {
        holeAnimator.enabled = false;
    }
	
}

