namespace IntoOOP.FileManager.Utils;

public class StateControl
{
    private string dataFileName;
    private string logFileName;

    public string DataFileName
    {
        get => dataFileName;
        set => dataFileName = value;
    }

    public string LogFileName
    {
        get => logFileName;
        set => logFileName = value;
    }

    public StateControl(string dataFileName, string logFileName)
    {
        DataFileName = dataFileName;
        LogFileName = logFileName;
    }

    public object[] LoadData()
    {
        return new object[0];
    }

    public void SaveData(object[] data)
    {

    }

    public void WriteLog(string logLine)
    {

    }
}