using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Newtonsoft.Json;

public class DataManager : Node
{
    private const string SAVE_PATH = "user://save.json";

    private static DataModel _data = new DataModel();

    public override void _Ready()
    {
        ReadSaveFile();
    }

    public static void Save()
    {
        WriteSaveFile();
    }

    public void ReadSaveFile()
    {
        string jsonString = null;
        var saveFile = OpenSaveFile(File.ModeFlags.Read);
        if (saveFile != null)
        {
            jsonString = saveFile.GetLine();
            try
            {
                _data = Deserialize(jsonString);
            }
            catch
            {
                // Careful here! This will create new save data if something went wrong with reading the file. You may want to handle this case differently.
                _data = new DataModel();
            }
            saveFile.Close();
        }
    }

    public static void AddCount(int count)
    {
        _data.Count += count;
    }

    public static void AddGuid(Guid guid)
    {
        _data.Guids.Add(guid);
    }

    public static void SetChecked(bool isChecked)
    {
        _data.Checked = isChecked;
    }

    public static int GetCount()
    {
        return _data.Count;
    }

    public static List<Guid> GetGuids()
    {
        return _data.Guids.ToList(); // I like to create a new list so we aren't passing the "source of truth" list as a reference
    }

    public static bool GetChecked()
    {
        return _data.Checked;
    }

    private static void WriteSaveFile()
    {
        var saveFile = OpenSaveFile(File.ModeFlags.Write);
        if (saveFile != null)
        {
            var json = JsonConvert.SerializeObject(_data);
            saveFile.StoreLine(json);
            saveFile.Close();
        }
    }

    private static File OpenSaveFile(File.ModeFlags flag = File.ModeFlags.Read)
    {
        var saveFile = new File();
        var err = saveFile.Open(SAVE_PATH, (int) flag);
        if (err == 0)
        {
            return saveFile;
        }
        return null;
    }

    private static DataModel Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<DataModel>(json);
    }
}