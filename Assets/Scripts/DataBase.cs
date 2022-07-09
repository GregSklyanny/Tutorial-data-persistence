using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataBase : MonoBehaviour
{
    public static DataBase Instance;
    public string userName;
    public string recordName;
    public int score;
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
        public string recordName;
        public int score;
    }

    public void SaveRecord()
    {
        JSONDataSet data = new JSONDataSet();
        data.recordName = userName;
        data.score = score;
        string json = JsonUtility.ToJson(data);

        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadRecord()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JSONDataSet data = JsonUtility.FromJson<JSONDataSet>(json);

            recordName = data.recordName;
            score = data.score;
        }


    }
    // Update is called once per frame
    
}
