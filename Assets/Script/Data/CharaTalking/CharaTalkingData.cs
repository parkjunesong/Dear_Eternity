using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharaTalkingData", menuName = "Scriptable Object/Chara Talking Data", order = 3000)]

public class CharaTalkingData : ScriptableObject
{   
    [SerializeField]
    private new string name;
    public string Name { get { return name; } }
    [SerializeField]
    private Sprite[] image;
    public Sprite[] Image { get { return image; } }

}
