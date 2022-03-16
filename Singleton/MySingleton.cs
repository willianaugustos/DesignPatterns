//set as sealed for blocking inheritance
public sealed class MySingleton
{
    private static MySingleton _instance;
    private static object _lockControl = new Object();
    private string guid = Guid.NewGuid().ToString();

    public string getHash() => this.guid;

    //set a private parameterless constructor
    //so no clients can instantiate
    private MySingleton()
    {
  
    }

    public static MySingleton getInstance()
    {
        if (_instance==null)
        {
            lock(_lockControl)
            {
                if (_instance==null)
                _instance = new MySingleton();
            }
        }

        return _instance;
    }
}