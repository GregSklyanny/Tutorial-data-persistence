using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataBase : MonoBehaviour
{
    public static DataBase Instance;
    public string userName;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class JSONDataSet
    {
        public string userName; 
    }

    public void SaveName()
    {
        JSONDataSet data = new JSONDataSet();
        data.userName = userName;
        string json = JsonUtility.ToJson(data);

        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JSONDataSet data = JsonUtility.FromJson<JSONDataSet>(json);

            userName = data.userName;
        }


    }
    // Update is called once per frame
    
}
