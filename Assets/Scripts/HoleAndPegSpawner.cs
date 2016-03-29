using UnityEngine;
using System.Collections;

public class HoleAndPegSpawner : MonoBehaviour {

    public GameObject[] cornerHoles;
    public GameObject[] holes;
    int difficulty = 2;

	// Use this for initialization
	void Start () {

        if (difficulty == 0)
        {
            int holeCount = calculateHoleCount(4);
            holes = new GameObject[holeCount];
            holes[0] = cornerHoles[0];
            holes[holes.Length - 4] = cornerHoles[1];
            holes[holes.Length - 1] = cornerHoles[2];
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


                    holes[i] = (GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation);
                }
            }
        
        }
        else if (difficulty == 1)
        {
            int holeCount = calculateHoleCount(5);
            Debug.Log(holeCount);
            holes = new GameObject[holeCount];
            holes[0] = cornerHoles[0];
            holes[holes.Length - 5] = cornerHoles[1];
            holes[holes.Length - 1] = cornerHoles[2];
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
                    holes[i] = (GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation);
                }
            }
        }
        else
        {
            int holeCount = calculateHoleCount(6);
            holes = new GameObject[holeCount];
            holes[0] = cornerHoles[0];
            holes[holes.Length - 6] = cornerHoles[1];
            holes[holes.Length - 1] = cornerHoles[2];
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
                    holes[i] = (GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation);
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
	// Update is called once per frame
	void Update () {
	
	}
}
