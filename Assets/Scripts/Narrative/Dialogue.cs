using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite portrait;
    [TextArea(3, 5)]
    public string sentence;
    
}
