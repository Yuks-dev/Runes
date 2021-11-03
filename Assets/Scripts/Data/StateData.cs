using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Add State", order = 52)]
public class StateData : ScriptableObject
{
    [SerializeField] private string stateFormat;
    [SerializeField] private int runesCount;
    [TextArea] [SerializeField] private string[] stateDescription;
    [TextArea] [SerializeField] private string[] stateDescriptionRu;
    [TextArea] [SerializeField] private string[] stateDescriptionEsp;
    [TextArea] [SerializeField] private string[] stateDescriptionKor;

    public string StateFormat { get { return stateFormat; } }
    public int RunesCount { get { return runesCount; } }
    public string[] StateDescription { get { return stateDescription; } }

    // Localization
    public string[] StateDescriptionRu { get { return stateDescriptionRu; } }
    public string[] StateDescriptionEsp { get { return stateDescriptionEsp; } }
    public string[] StateDescriptionKor { get { return stateDescriptionKor; } }
}
