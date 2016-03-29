using UnityEngine;
using System.Collections;

public class Peg  {

    public int Id {get; private set;}
    GameObject gameObject;
    public string ColliderName { get; private set; }
    public Hole hole { get; private set; }
    Quaternion initialRotation;
    float initialZ;

    public Peg(int id, GameObject peg, Hole hole)
    {
        this.Id = id;
        this.gameObject = peg;
        ColliderName = id.ToString();
        peg.GetComponent<Collider>().name = ColliderName;
        this.hole = hole;
        initialRotation = peg.transform.rotation;
        initialZ = peg.transform.position.z;
        this.hole.Peg = this;

    }
    public Peg(Peg peg)
    {
        this.Id = peg.Id;
        this.gameObject = peg.GetPeg();
        this.ColliderName = peg.ColliderName;
        this.hole = peg.hole;
        this.hole.Peg = this;
    }

    public void Remove()
    {
        this.hole.hasPeg = false;
        gameObject.SetActive(false);
    }
    public GameObject GetPeg()
    {
        return gameObject;
    }

    public bool IsValid()
    {
        return gameObject.activeSelf;
    }
    public void DetachPeg(float xPosition)
    {
        Vector3 position = gameObject.transform.position;
        position.x = xPosition;
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 35, 0));
            
    }

    public void MovePegToHole(Hole hole)
    {
        this.hole.hasPeg = false;
        this.hole = hole;
        hole.hasPeg = true;
        Vector3 pos = hole.GetHole().transform.position;
        pos.z = initialZ;
        gameObject.transform.position = pos;
        gameObject.transform.rotation = initialRotation;this.hole.Peg = this;
        this.hole.Peg = this;
            
    }
}
