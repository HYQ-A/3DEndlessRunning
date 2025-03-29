using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RankData
{

    public List<RankItemData> listItemData = new List<RankItemData>();

}

public class RankItemData
{
    [XmlAttribute]
    public string name;
    [XmlAttribute]
    public int time;
    [XmlAttribute]
    public int score;
}
