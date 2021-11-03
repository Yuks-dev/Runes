using UnityEngine;

[CreateAssetMenu(fileName = "New Rune", menuName = "Add Rune", order = 51)]
public class RunesData : ScriptableObject
{
    [SerializeField] private int runeIndex;
    [SerializeField] private string runeName;

    [SerializeField] private string runeShortExplain;
    [SerializeField] private string runeShortExplainRu;
    [SerializeField] private string runeShortExplainEsp;
    [SerializeField] private string runeShortExplainKor;

    [SerializeField] private GameObject runePrefab;
    [SerializeField] private Sprite runeImage;

    [TextArea] [SerializeField] private string runeDescription;
    [TextArea] [SerializeField] private string runeDescriptionRu;
    [TextArea] [SerializeField] private string runeDescriptionEsp;
    [TextArea] [SerializeField] private string runeDescriptionKor;

    public int RuneIndex { get { return runeIndex; } }
    public string RuneName { get { return runeName; } }
    public string RuneShortExplain { get { return runeShortExplain; } }
    public GameObject RunePrefab { get { return runePrefab; } }
    public string RuneDescription { get { return runeDescription; } }
    public Sprite RuneImage { get { return runeImage; } }

    //Localization Russian
    public string RuneShortExplainRu { get { return runeShortExplainRu; } }
    public string RuneDescriptionRu { get { return runeDescriptionRu; } }

    //Localization Spanish
    public string RuneShortExplainEsp { get { return runeShortExplainEsp; } }
    public string RuneDescriptionEsp { get { return runeDescriptionEsp; } }

    //Localization Korean
    public string RuneShortExplainKor { get { return runeShortExplainKor; } }
    public string RuneDescriptionKor { get { return runeDescriptionKor; } }
}
