using UnityEngine;
using System.Collections;

public class Peg  {

    public int Id {get; private set;}
    GameObject gameObject;
    public string ColliderName { get; private set; }
    public Hole hole { get; private set; }

    public Peg(int id, GameObject peg, Hole hole)
    {
        this.Id = id;
        this.gameObject = peg;
        ColliderName = id.ToString();
        peg.GetComponent<Collider>().name = ColliderName;
        this.hole = hole;

    }
    public Peg(Peg peg)
    {
        this.Id = peg.Id;
        this.gameObject = peg.GetPeg();
        this.ColliderName = peg.ColliderName;
        this.hole = peg.hole;
    }

    public GameObject GetPeg()
    {
        return gameObject;
    }
}
