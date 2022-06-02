using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    [SerializeField]private string name;

    [TextArea(5,10)]
    [SerializeField]private string[] sentences;
    #region properties
    public string Name
    {
        get{return name;}
        set{name = value;}
    }
    public string[] Sentences
    {
        get{return sentences;}
        set{sentences = value;}
    }
    #endregion
}
