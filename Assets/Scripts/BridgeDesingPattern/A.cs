using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "A", menuName = "ScriptableObjects/A", order = 1)]
public class A : ScriptableObject
{
    [SerializeField] private LevelData[] levelData;
    public LevelData[] LevelData => levelData;
}

[System.Serializable]
public class LevelData
{
    public string levelName;
    public int levelID;
    public int levelMinMission;
    public GameObject[] targets;
    public LevelMission[] levelMissions;

}

public enum MissionType
{
    Collect,
    Eliminate,
    Defend
}

[System.Serializable]
public class LevelMission
{
    public MissionType missionType;
    public int missionCount;
}