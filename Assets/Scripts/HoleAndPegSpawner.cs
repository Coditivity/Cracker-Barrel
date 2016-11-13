using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HoleAndPegSpawner : MonoBehaviour
{

    public GameObject MenuPanel, gameOverPanel, gameWinPanel;
    public GameObject[] cornerHoles;
    Hole[] holes;
    Peg[] pegs;
    Hole[][] holesRowColumn;
    public GameObject peg;
    static int difficulty = 0;
    bool gameContinuing;
    public bool Spawned { get; private set; }

    // Use this for initialization
    void Start()
    {
        gameContinuing = false;
        Spawned = false;
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        if (SaveDataManager.IsSaveDataAvailable())
        {
            SpawnObjectsFromSaveData();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
    }
    public void EasyClick()
    {
        difficulty = 0;
        SpawnObjects();
        MenuPanel.SetActive(false);
    }

    public void MediumClick()
    {
        difficulty = 1;
        SpawnObjects();
        MenuPanel.SetActive(false);
    }
    public void HardClick()
    {
        difficulty = 2;
        SpawnObjects();
        MenuPanel.SetActive(false);
    }
    public void ContinueClick()
    {
        gameContinuing = true;
        SpawnObjects();
        MenuPanel.SetActive(false);
        SetObjectsAccordingToSaveData();

    }

    public void MenuClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void SpawnObjects()
    {
        if (difficulty == 0)
        {
            int holeCount = calculateHoleCount(4);
            holes = new Hole[holeCount];
            pegs = new Peg[holeCount];
            holesRowColumn = new Hole[4][];
            for (int i = 0; i < 4; i++)
            {
                holesRowColumn[i] = new Hole[i + 1];
            }

            holes[0] = new Hole(cornerHoles[0], true, 0, 0);//cornerHoles[0];
            holes[holes.Length - 4] = new Hole(cornerHoles[1], true, 3, 0);
            holes[holes.Length - 1] = new Hole(cornerHoles[2], true, 3, 3);


            for (int i = 0; i < holeCount; i++)
            {


                if (i != 0 && i != holes.Length - 4 && i != holes.Length - 1)
                {

                    float xDifference = (cornerHoles[0].transform.position.x
                        - cornerHoles[1].transform.position.x) / 3;
                    float yDifference = (cornerHoles[0].transform.position.y
                        - cornerHoles[1].transform.position.y) / 3;
                    float xPositionLeft = cornerHoles[0].transform.position.x
                        - xDifference * getRowNumber(i);
                    float xPositionRight = cornerHoles[0].transform.position.x
                        + xDifference * getRowNumber(i);
                    float xDifferenceActual = (xPositionRight - xPositionLeft)
                        / getRowNumber(i);
                    float xPosition = xPositionLeft + xDifferenceActual * getColumnNumber(i);
                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);

                    GameObject hole = (GameObject)Instantiate(cornerHoles[0]
                        , holePosition, cornerHoles[0].transform.rotation);
                    hole.AddComponent<HoleAnimator>();
                    holes[i] = new Hole(hole, true, getRowNumber(i), getColumnNumber(i));

                }


                Vector3 pegPosition = holes[i].GetHole().transform.position;
                pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                    , peg.transform.rotation), holes[i]);
                if (i % 2 == 0)
                {

                    pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                }

                if (i == 0 && !gameContinuing)
                {
                    holes[i].Peg.Remove();
                    holes[i].hasPeg = false;
                }


                holesRowColumn[getRowNumber(i)][getColumnNumber(i)] = holes[i];

            }

        }
        else if (difficulty == 1)
        {
            int holeCount = calculateHoleCount(5);
            pegs = new Peg[holeCount];
            holes = new Hole[holeCount];
            holes[0] = new Hole(cornerHoles[0], true, 0, 0);
            holes[holes.Length - 5] = new Hole(cornerHoles[1], true, 4, 0);
            holes[holes.Length - 1] = new Hole(cornerHoles[2], true, 4, 4);

            holesRowColumn = new Hole[5][];
            for (int i = 0; i < 5; i++)
            {
                holesRowColumn[i] = new Hole[i + 1];
            }
            for (int i = 0; i < holeCount; i++)
            {

                if (i != 0 && i != holes.Length - 5 && i != holes.Length - 1)
                {
                    float xDifference = (cornerHoles[0].transform.position.x
                         - cornerHoles[1].transform.position.x) / 4;
                    float yDifference = (cornerHoles[0].transform.position.y
                       - cornerHoles[1].transform.position.y) / 4;


                    float xPositionLeft = cornerHoles[0].transform.position.x
                        - xDifference * getRowNumber(i);
                    float xPositionRight = cornerHoles[0].transform.position.x
                        + xDifference * getRowNumber(i);
                    float xDifferenceActual = (xPositionRight - xPositionLeft)
                        / getRowNumber(i);
                    float xPosition = xPositionLeft + xDifferenceActual
                        * getColumnNumber(i);

                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);
                    GameObject hole = (GameObject)Instantiate(cornerHoles[0]
                       , holePosition, cornerHoles[0].transform.rotation);
                    hole.AddComponent<HoleAnimator>();
                    holes[i] = new Hole(hole, true, getRowNumber(i), getColumnNumber(i));
                }


                Vector3 pegPosition = holes[i].GetHole().transform.position;
                pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                    , peg.transform.rotation), holes[i]);
                if (i % 2 == 0)
                {
                    pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                }

                if (i == 0 && !gameContinuing)
                {
                    holes[i].Peg.Remove();
                    holes[i].hasPeg = false;
                }

                holesRowColumn[getRowNumber(i)][getColumnNumber(i)] = holes[i];

            }
        }
        else
        {
            int holeCount = calculateHoleCount(6);
            holes = new Hole[holeCount];
            pegs = new Peg[holeCount];

            holes[0] = new Hole(cornerHoles[0], true, 0, 0);
            holes[holes.Length - 6] = new Hole(cornerHoles[1], true, 5, 0);
            holes[holes.Length - 1] = new Hole(cornerHoles[2], true, 5, 5);
            holesRowColumn = new Hole[6][];
            for (int i = 0; i < 6; i++)
            {
                holesRowColumn[i] = new Hole[i + 1];
            }
            for (int i = 0; i < holeCount; i++)
            {

                if (i != 0 && i != holes.Length - 6 && i != holes.Length - 1)
                {

                    float xDifference = (cornerHoles[0].transform.position.x
                        - cornerHoles[1].transform.position.x) / 5;
                    float yDifference = (cornerHoles[0].transform.position.y
                       - cornerHoles[1].transform.position.y) / 5;

                    float xPositionLeft = cornerHoles[0].transform.position.x
                         - xDifference * getRowNumber(i);
                    float xPositionRight = cornerHoles[0].transform.position.x
                        + xDifference * getRowNumber(i);
                    float xDifferenceActual = (xPositionRight - xPositionLeft)
                        / getRowNumber(i);
                    Debug.Log(i + " " + xDifferenceActual);
                    float xPosition = xPositionLeft + xDifferenceActual
                        * getColumnNumber(i);

                    float yPosition = cornerHoles[0].transform.position.y
                        - yDifference * getRowNumber(i);
                    Vector3 holePosition = new Vector3(xPosition, yPosition, cornerHoles[0].transform.position.z);


                    GameObject hole = (GameObject)Instantiate(cornerHoles[0]
                       , holePosition, cornerHoles[0].transform.rotation);
                    hole.AddComponent<HoleAnimator>();
                    holes[i] = new Hole(hole, true, getRowNumber(i), getColumnNumber(i));
                }


                Vector3 pegPosition = holes[i].GetHole().transform.position;
                pegPosition.z = holes[0].GetHole().transform.position.z + .5f;
                pegs[i] = new Peg(i, (GameObject)Instantiate(peg, pegPosition
                    , peg.transform.rotation), holes[i]);
                if (i % 2 == 0)
                {
                    pegs[i].GetPeg().GetComponent<Renderer>().material.color = Color.blue;
                }

                if (i == 0 && !gameContinuing)
                {
                    holes[i].Peg.Remove();
                    holes[i].hasPeg = false;
                }

                holesRowColumn[getRowNumber(i)][getColumnNumber(i)] = holes[i];
            }
        }

        Spawned = true;
    }
    public int calculateHoleCount(int sideHoleCount)
    {
        return sideHoleCount * (sideHoleCount + 1) / 2;
    }

    private int getRowNumber(int holeIndex)
    {
        if (holeIndex == 0)
        {
            return 0;
        }
        else if (holeIndex <= 2)
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

        return 0;
    }

    private int getColumnNumber(int holeIndex)
    {
        int rowNum = getRowNumber(holeIndex);
        int firstInRow = rowNum * (rowNum + 1) / 2;
        return holeIndex - firstInRow;
    }

    public Hole GetHole(int row, int column)
    {
        int numRows = getSideHoleCount();
        if (row >= 0 && row < numRows)
        {
            if (column >= 0 && column <= row)
            {
                return holesRowColumn[row][column];
            }
        }
        return null;
    }
    public Hole[][] GetAllHoles()
    {
        return holesRowColumn;
    }
    public void RemovePeg(int pegIndex)
    {
        pegs[pegIndex].Remove();
    }

    public Peg[] getPegs()
    {
        return pegs;
    }
    public int getSideHoleCount()
    {
        return 4 + difficulty;
    }
    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int holeCount = calculateHoleCount(getSideHoleCount());
        if (Physics.Raycast(ray, out hit))
        {

            for (int i = 0; i < holeCount; i++)
            {
                if (pegs[i] != null)
                {
                    if (hit.collider.name == pegs[i].ColliderName)
                    {
                        EventManager.OnRayHitDetecion(pegs[i]);
                    }
                }
                if (hit.collider.name == holes[i].ColliderName)
                {
                    if (!holes[i].hasPeg)
                    {

                        EventManager.OnHoleMouseDetection(holes[i]);
                    }
                }
            }
        }

    }



    string[] loadedData;
    int[,] moves;
    int loadedDifficulty;
    MoveData[] moveDatas;
    bool[] lastHoleStatus;
    float time;
    private void SpawnObjectsFromSaveData()
    {
        loadedData = SaveDataManager.GetLoadedData();
        moveDatas = new MoveData[loadedData.Length];

        int k = 0;
        foreach (string s in loadedData)
        {

            string[] datas = s.Split(new string[] { " " }
                , System.StringSplitOptions.RemoveEmptyEntries);
            int[] start = new int[2], end = new int[2];
            time = 0;
            for (int i = 0; i < datas.Length; i++)
            {
                string[] datas2 = datas[i].Split(new string[] { "," }
                , System.StringSplitOptions.RemoveEmptyEntries);
                if (i == 0)
                {
                    start[0] = int.Parse(datas2[0]);
                    start[1] = int.Parse(datas2[0]);
                }
                else if (i == 1)
                {
                    end[0] = int.Parse(datas2[0]);
                    end[1] = int.Parse(datas2[1]);
                }
                else if (i == 2)
                {
                    time = float.Parse(datas2[0]);
                    Debug.Log("loaded time " + time);
                }
                else
                {
                    if (datas2.Length > 0)
                    {
                        lastHoleStatus = new bool[datas2.Length];

                        for (int b = 0; b < lastHoleStatus.Length; b++)
                        {
                            lastHoleStatus[b] = bool.Parse(datas2[b]);
                        }
                    }
                }

            }
            moveDatas[k] = new MoveData(start, end, time);
            k++;
        }
        if (lastHoleStatus != null)
        {
            int holeCountInSaveData = lastHoleStatus.Length - 1;
            Debug.Log(holeCountInSaveData);
            if (holeCountInSaveData == 9)
            {
                loadedDifficulty = 0;
                difficulty = loadedDifficulty;
            }
            else if (holeCountInSaveData == 14)
            {
                loadedDifficulty = 1;
                difficulty = loadedDifficulty;
            }
            else
            {
                loadedDifficulty = 2;
                difficulty = loadedDifficulty;
            }
        }
    }

    private void SetObjectsAccordingToSaveData()
    {
        GameScript.sinceTime = time;
        int rowCount = getSideHoleCount();
        int k = 0;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (!lastHoleStatus[k])
                {
                    GetHole(i, j).Peg.Remove();
                }
                else
                {
                  //  getHole(i,j).Pe
                }
                k++;
            }
        }
        
    }
}
