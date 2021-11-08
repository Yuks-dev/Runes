using TMPro;

public class TextMeshLangView : Element
{
    public TextMeshPro textMesh;
    public string ruText;
    public string espText;
    public string korText;

    private void Start()
    {
        textMesh.font = app.model.latinFont;

        if (app.model.language == MainModel.Localization.Russian)
        {
            textMesh.font = app.model.cyrilicFont;
            textMesh.text = ruText;
        }

        if (app.model.language == MainModel.Localization.Spanish)
            textMesh.text = espText;

        if (app.model.language == MainModel.Localization.Korean)
        {
            textMesh.font = app.model.koreanFont;
            textMesh.text = korText;
        }
    }
}
