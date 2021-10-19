using UnityEngine;

[CreateAssetMenu(fileName = "New Rune", menuName = "Add Rune", order = 51)]
public class RunesData : ScriptableObject
{
    [SerializeField] private int runeIndex;
    [SerializeField] private string runeName;
    [SerializeField] private string runeShortExplain;
    [SerializeField] private GameObject runePrefab;
    [SerializeField] private Sprite runeImage;
    [TextArea] [SerializeField] private string runeDescription;

    public int RuneIndex { get { return runeIndex; } }
    public string RuneName { get { return runeName; } }
    public string RuneShortExplain { get { return runeShortExplain; } }
    public GameObject RunePrefab { get { return runePrefab; } }
    public string RuneDescription { get { return runeDescription; } }
    public Sprite RuneImage { get { return runeImage; } }
}
