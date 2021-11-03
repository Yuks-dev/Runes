using UnityEngine;
using UnityEngine.UI;

public class TextLangView : Element
{
    public Text textObj;
    public string ruText;
    public string espText;
    public string korText;

    private void Start()
    {
        if (app.model.language == MainModel.Localization.Russian)
            textObj.text = ruText;

        if (app.model.language == MainModel.Localization.Spanish)
            textObj.text = espText;

        if (app.model.language == MainModel.Localization.Korean)
            textObj.text = korText;
    }
}
