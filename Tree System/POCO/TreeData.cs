using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTreeData", menuName = "Tree System/Tree Data")]
public class TreeData : ScriptableObject
{
    public string treeName;
    public bool isFruitable;
    public WoodType woodType;
    public List<SeasonSpritePair> seasonSprites;
    public List<TreeStageData> treeStagesDataList;
}
