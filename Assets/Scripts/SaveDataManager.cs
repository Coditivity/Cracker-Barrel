using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class SaveDataManager : MonoBehaviour {

    string fileName;
    StringBuilder builder;
    bool saveDataAvailable;
    string[] loadedData;
    private static SaveDataManager manager;
    bool hasDataToWrite;
    private static SaveDataManager instance
    {
        get
        {
            if (manager == null)
            {
                manager = (SaveDataManager)FindObjectOfType<SaveDataManager>();
                if (manager == null)
                {
                    Debug.Log("Please attach a SaveDataManager script to any gameobject");
                }
                else
                {
                    manager.Init();
                }

            }
            return manager;
        }
    }

    public static bool IsSaveDataAvailable()
    {
        return instance.saveDataAvailable;
    }
    private void Init()    {

        fileName = Application.persistentDataPath
               + Path.DirectorySeparatorChar
               + "moveList.txt";
        //fileName = "C:/Users/MY GIGABYTE/data.txt";
        builder = new StringBuilder();
        if (File.Exists(fileName))
        {
            saveDataAvailable = true;
            loadedData = File.ReadAllLines(fileName);
        }
        hasDataToWrite = false;
    }

    public static void AddPlayerMove(Hole startingHole, Hole endingHole, float time, Hole[][] holes)
    {
        instance.hasDataToWrite = true;
        string move = startingHole.Row.ToString() + "," + startingHole.Column.ToString()
            + " " + endingHole.Row.ToString() + "," + endingHole.Column.ToString()
            + " " + time.ToString() + " " ;

        Debug.Log("=============================");
        for (int i = 0; i < holes.Length;i++ )
        {
            for (int j = 0; j < holes[i].Length; j++)
            {
                if (holes[i][j].Peg != null)
                {
                    move += (holes[i][j].Peg.IsValid() && holes[i][j].hasPeg) + ",";
                    Debug.Log(holes[i][j].Peg.IsValid() && holes[i][j].hasPeg);
                }
                else
                {
                    move += false + ",";
                    Debug.Log(false);
                }
            }
        }
        Debug.Log("=============================");

            instance.builder.AppendLine(move);
    }
    public static void SaveData()
    {
        if (!instance.hasDataToWrite)
        {
            return;
        }
        StreamWriter file = new StreamWriter(instance.fileName);
        file.Write(instance.builder);
        file.Close();
    }

    public static string[] GetLoadedData()
    {
        return instance.loadedData;
    }
    void OnApplicationQuit()
    {
        SaveData();
    }
    
}
