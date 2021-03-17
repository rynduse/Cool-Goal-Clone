using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Score
{
    public int score;
}
[System.Serializable]
public class LevelNum
{
    public int levelNum;
}


[CreateAssetMenu(fileName = "Data For Game Stats")]
public class DataScriptableObject : ScriptableObject
{
    public Score score = new Score();
    public LevelNum levelNum = new LevelNum();

}
