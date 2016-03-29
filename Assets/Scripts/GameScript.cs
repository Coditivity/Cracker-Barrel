using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public HoleAndPegSpawner spawner;
    public GameObject dummyXPosObject;
    Hole[] movableHoles;
    int movableHolesCount;
    float pegRemoveX;
    Peg selectedPeg;
    void OnEnable()
    {
        EventManager.instance.RayHitDetection += OnRayHitDetection;
        EventManager.instance.HoleMouseDetection += OnHoleMouseDetection;
    }
    void OnDisable()
    {
        EventManager.instance.RayHitDetection -= OnRayHitDetection;
        EventManager.instance.HoleMouseDetection -= OnHoleMouseDetection;
    }

	// Use this for initialization
	void Start () {

        movableHoles = new Hole[6];
        pegRemoveX = dummyXPosObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (selectedPeg != null)
            {
                selectedPeg.MovePegToHole(selectedPeg.hole);
            }
        }
        int pegCount = spawner.getPegs().Length;
        Peg[] pegs = spawner.getPegs();
        bool movesLeft = false;
        for (int i = 0; i < pegCount; i++)
        {
            if (pegs[i] != null )                
            {
                if (pegs[i].IsValid())
                {
                    movesLeft |= TryGetViableMoves(pegs[i]);
                }
            }
        }

        if (!movesLeft)
        {
            Debug.Log("game Over");
        }
        
  
	}

    private void IfPegMovable()
    {

    }

    void OnRayHitDetection(Peg peg) {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetViableMoves(peg))
            {
                if (selectedPeg != null)
                {
                    selectedPeg.MovePegToHole(selectedPeg.hole);
                }
                selectedPeg = peg;
                peg.DetachPeg(pegRemoveX);
            }
        }
       
    }

    void OnHoleMouseDetection(Hole hole)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("selected peg " + selectedPeg);
            Debug.Log("nummovalbe" + movableHolesCount);
            if (selectedPeg != null)
            {
                TryGetViableMoves(selectedPeg);
                foreach (Hole h in movableHoles)
                {
                    if (h != null)
                    {
                        Debug.Log(h.ColliderName + " " + hole.ColliderName);
                        if (h.ColliderName == hole.ColliderName)
                        {
                            RemoveMiddlePeg(selectedPeg.hole, hole);
                            selectedPeg.MovePegToHole(hole);
                            selectedPeg = null;
                            break;
                        }
                    }
                }
            }
               
        }

    }

   private Hole GetPegHole(Peg peg) {       
      return spawner.GetHole(peg.hole.Row, peg.hole.Column);
   }

   private bool TryGetViableMoves(Peg peg)
   {
       movableHolesCount = 0;
       bool retVal = false;
       Hole hole = GetPegHole(peg);
       Hole movableHole = spawner.GetHole(hole.Row - 2, hole.Column - 2);
       bool movable = false ;
       for (int i = 0; i < 6; i++)
       {
           movableHoles[0] = null;
       }
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[0] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
       movableHole = spawner.GetHole(hole.Row-2, hole.Column);
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[1] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
       movableHole = spawner.GetHole(hole.Row+2, hole.Column);
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[2] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
       movableHole = spawner.GetHole(hole.Row + 2, hole.Column + 2);
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[3] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
       movableHole = spawner.GetHole(hole.Row, hole.Column - 2);
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[4] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
       movableHole = spawner.GetHole(hole.Row, hole.Column + 2);
       movable = IsMovableHole(movableHole, peg.hole);
       if(movable && movableHoles!=null){
           movableHoles[5] = movableHole;
           movableHolesCount++;
       }
       retVal |= movable;
  

       return retVal;
   }

    private bool IsMovableHole(Hole hole) {

        return false;
    }

   private bool IsMovableHole(Hole hole, Hole startingHole)
   {
       if (hole != null)
       {
           if (!hole.hasPeg)
           {
               if (GetMiddleHole(startingHole, hole).hasPeg)
               {
                   hole.StartAnimation();
                   return true;
               }
               
           }
       }
       if (hole != null)
       {
           hole.StopAnimation();
       }
       return false;
   }

   private void RemoveMiddlePeg(Hole startingHole, Hole endHole)
   {
       int pegRow = (startingHole.Row + endHole.Row) / 2;
       int pegColumn = (startingHole.Column + endHole.Column) / 2;
       //int pegIndex = pegRow * (pegRow + 1) / 2 + pegColumn;
       int pegIndex = spawner.GetHole(pegRow, pegColumn).Peg.Id;

       spawner.RemovePeg(pegIndex);
   }

   private Hole GetMiddleHole(Hole startingHole, Hole endHole)
   {
       int row = (startingHole.Row + endHole.Row) / 2;
       int column = (startingHole.Column + endHole.Column) / 2;
       return spawner.GetHole(row, column);
   }

   
}
