using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class SO_Card : ScriptableObject {

    [TextArea(5, 10)]
    public string content;
    public Sprite background;

    public string optionText1;
    public string optionText2;

    public List<int> valuesChange1 = new List<int>();
    public List<int> valuesChange2 = new List<int>();

}
