using UnityEngine;
using System.Collections;

public class HoleAndPegSpawner : MonoBehaviour {

    public GameObject[] cornerHoles;
    Hole[] holes;
    Peg[] pegs;
   // bool[] holeHasPeg;
    public GameObject peg;
    int difficulty = 2;

	// Use this for initialization
	void Start () {

        if (difficulty == 0)
        {
            int holeCount = calculateHoleCount(4);
            holes = new Hole[holeCount];
            pegs = new Peg[holeCount];

            holes[0] = new Hole(cornerHoles[0], true);//cornerHoles[0];
            holes[holes.Length - 4] = new Hole(cornerHoles[1], true);
            holes[holes.Length - 1] = new Hole(cornerHoles[2], true);
            for (int i = 0; i < holeCount;i++ )
            {

               
                if (i != 0 && i != holes.Length - 4 && i != holes.Length - 1)
                {

                    float xDifference = (cornerHoles[0].transform.position.x 
                        - cornerHoles[1].transform.position.x ) / 3;   
                    float yDifference = (cornerHoles[0].transform.position.y
                        - cornerHoles[1].transform.position.y) / 3;
                    float xPositionLeft = cornerHoles[0].transform.position.x
                        - xDifference * getRowNumber(difficulty, i);
                    float xPositionRight = cornerHoles[0].transform.position.x
                        + xDifference * getRowNumber(difficulty, i);
                    float xDifferenceActual = (xPositionRight - xPositionLeft)
                        / getRowNumber(difficulty, i);
                    float xPosition = xPositionLeft + xDifferenceActual * getColumnNumber(difficulty, i);
                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(difficulty, i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);


                    holes[i] = new Hole((GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation), true);
                }
                if (i != 0)
                {
                   
                    Vector3 pegPosition = holes[i].GetHole().transform.position;
                    pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                    pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                        , peg.transform.rotation));
                    if (i % 2 == 0)
                    {

                        pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
                else 
                {
                    holes[i].hasPeg = false;
                }
            }
        
        }
        else if (difficulty == 1)
        {
            int holeCount = calculateHoleCount(5);
            pegs = new Peg[holeCount];
            holes = new Hole[holeCount];            
            holes[0] = new Hole(cornerHoles[0], true);
            holes[holes.Length - 5] = new Hole(cornerHoles[1], true);
            holes[holes.Length - 1] = new Hole(cornerHoles[2], true);
            for (int i = 0; i < holeCount; i++)
            {
               
                if (i != 0 && i != holes.Length - 5 && i != holes.Length - 1)
                {
                   float xDifference = (cornerHoles[0].transform.position.x 
                        - cornerHoles[1].transform.position.x ) / 4;    
                     float yDifference = (cornerHoles[0].transform.position.y
                        - cornerHoles[1].transform.position.y) / 4;


                     float xPositionLeft = cornerHoles[0].transform.position.x
                         - xDifference * getRowNumber(difficulty, i);
                     float xPositionRight = cornerHoles[0].transform.position.x
                         + xDifference * getRowNumber(difficulty, i);
                     float xDifferenceActual = (xPositionRight - xPositionLeft)
                         / getRowNumber(difficulty, i);
                     float xPosition = xPositionLeft + xDifferenceActual 
                         * getColumnNumber(difficulty, i);

                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(difficulty, i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);
                    holes[i] = new Hole((GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation), true);
                }
                if (i != 4)
                {
                    
                    Vector3 pegPosition = holes[i].GetHole().transform.position;
                    pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                    pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                        , peg.transform.rotation));
                    if (i % 2 == 0)
                    {
                        pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
                else
                {
                    holes[i].hasPeg = false;
                }
            }
        }
        else
        {
            int holeCount = calculateHoleCount(6);
            holes = new Hole[holeCount];
            pegs = new Peg[holeCount];
           
            holes[0] = new Hole(cornerHoles[0], true);
            holes[holes.Length - 6] =  new Hole(cornerHoles[1], true);
            holes[holes.Length - 1] =  new Hole(cornerHoles[2], true);
            for (int i = 0; i < holeCount; i++)
            {
                
                if (i != 0 && i != holes.Length - 6 && i != holes.Length - 1)
                {

                    float xDifference = (cornerHoles[0].transform.position.x 
                        - cornerHoles[1].transform.position.x ) / 5;  
                     float yDifference = (cornerHoles[0].transform.position.y
                        - cornerHoles[1].transform.position.y) / 5;

                     float xPositionLeft = cornerHoles[0].transform.position.x
                          - xDifference * getRowNumber(difficulty, i);
                     float xPositionRight = cornerHoles[0].transform.position.x
                         + xDifference * getRowNumber(difficulty, i);
                     float xDifferenceActual = (xPositionRight - xPositionLeft)
                         / getRowNumber(difficulty, i);
                    Debug.Log(i + " "  +xDifferenceActual);
                     float xPosition = xPositionLeft + xDifferenceActual
                         * getColumnNumber(difficulty, i);

                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(difficulty, i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);
                    holes[i] = new Hole((GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation), true);
                }
                if (i != 4)
                {
                   
                    Vector3 pegPosition = holes[i].GetHole().transform.position;
                    pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                    pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                        , peg.transform.rotation));
                    if (i % 2 == 0)
                    {
                        pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
                else
                {
                    holes[i].hasPeg = false;
                }
            }
        }
        
	}

    private int calculateHoleCount(int sideHoleCount)
    {
        return sideHoleCount * (sideHoleCount + 1) / 2;
    }

    private int getRowNumber(int difficulty, int holeIndex)
    {
       /* if (difficulty == 0)
        {
            if (holeIndex <= 2)
            {
                return 1;
            }
            else if(holeIndex <= 5)
            {
                return 2;
            }
        }
        else if (difficulty == 1)
        {
            if (holeIndex <= 2)
            {
                return 1;
            }
            else if (holeIndex <= 5)
            {
                return 2;
            }
            else if(holeIndex <=9){
                return 3;
            }
        }
        else if (difficulty == 2)
        {*/
            if (holeIndex <= 2)
            {
                return 1;
            }
            else if (holeIndex <= 5)
            {
                return 2;
            }
            else if (holeIndex <= 9)
            {
                return 3;
            }
            else if (holeIndex <= 14)
            {
                return 4;
            }
            else if (holeIndex <= 20)
            {
                return 5;
            }
       // }
        return 0;
    }

    private int getColumnNumber(int difficulty, int holeIndex)
    {
        int rowNum = getRowNumber(difficulty, holeIndex);
        int firstInRow = rowNum * (rowNum + 1) / 2;
        return holeIndex - firstInRow;
    }

    public Hole[] getHoles()
    {
        return holes;
    }

    public Peg[] getPegs()
    {
        return pegs;
    }
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
        }
	}
}
