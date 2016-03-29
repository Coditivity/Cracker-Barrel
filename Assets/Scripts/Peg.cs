﻿using UnityEngine;
using System.Collections;

public class Peg  {

    int id;
    GameObject peg;

    public Peg(int id, GameObject peg)
    {
        this.id = id;
        this.peg = peg;
        peg.GetComponent<Collider>().name = "PC" + id.ToString();

    }

    public GameObject GetPeg()
    {
        return peg;
    }
}
