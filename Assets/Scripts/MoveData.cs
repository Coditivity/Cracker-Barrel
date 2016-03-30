using UnityEngine;
using System.Collections;

public class MoveData {

    public int[] FromHole {get; private set;}
    public int[] ToHole {get; private set;}
    public float SinceTime {get;private set;}
    public MoveData(int[] fromHole, int[] toHole, float time) {
        FromHole = fromHole;
        ToHole = toHole;
        SinceTime = time;
    }
}
