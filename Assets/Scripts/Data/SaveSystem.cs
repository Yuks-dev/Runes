using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable]
class SaveData
{
    public int[] runesOpen = new int[24];
}

public class SaveSystem : Element
{
    public void SaveAppData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/EDRunes.save");
        SaveData data = new SaveData();

        data.runesOpen = app.model.availableRunes;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadAppData()
    {
        if (File.Exists(Application.persistentDataPath + "/EDRunes.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/EDRunes.save", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            app.model.availableRunes = data.runesOpen;
        }
    }
}



