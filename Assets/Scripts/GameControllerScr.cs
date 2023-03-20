using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScr : MonoBehaviour
{
    public int cellCount;

    int[] pathID = { 55, 56, 57, 84, 111, 138, 165, 192, 219, 246,
                     247, 248, 249, 250, 223, 196, 169, 142, 143, 
                     144, 145, 146, 147, 148, 149, 150, 123, 96,
                     69, 68, 67, 66, 65, 38, 11, 12, 13, 14, 15,
                     16, 17, 18, 19, 20, 47, 74, 75, 76, 103, 130,
                     131, 132, 133, 160, 187, 214, 241, 268, 269, 270};

    List<CellScr> AllCells = new List<CellScr> ();

    public GameObject cellPref;
    public Transform cellGroup;
    // Start is called before the first frame update
    void Start()
    {
        CreateCells();   
        CreatePath();
    }

    void CreateCells()
    {
        for (int i=0; i<cellCount; i++)
        {
            GameObject tmpCell = Instantiate(cellPref);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CellScr>().id = i + 1;
            tmpCell.GetComponent<CellScr>().SetState(0);
            AllCells.Add(tmpCell.GetComponent<CellScr>());
        }
    }

    void CreatePath()
    {
        for(int i=0; i < pathID.Length; i++)
            AllCells[pathID[i] - 1].SetState(1);
    }
}
