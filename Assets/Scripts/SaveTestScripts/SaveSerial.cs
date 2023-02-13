using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{  
    int intToSave;
    float floatToSave;
    bool boolToSave;

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 125, 50), "Raise Integer"))
            intToSave++;
        if (GUI.Button(new Rect(0, 100, 125, 50), "Raise Float"))
            floatToSave += 0.1f;
        if (GUI.Button(new Rect(0, 200, 125, 50), "Change Bool"))
            boolToSave = boolToSave ? boolToSave 
                        = false : boolToSave = true;
        GUI.Label(new Rect(375, 0, 125, 50), "Integer value is " 
                    + intToSave);
        GUI.Label(new Rect(375, 100, 125, 50), "Float value is " 
                    + floatToSave.ToString("F1"));
        GUI.Label(new Rect(375, 200, 125, 50), "Bool value is " 
                    + boolToSave);
        if (GUI.Button(new Rect(750, 0, 125, 50), "Save Your Game"))
            SaveGame();
        if (GUI.Button(new Rect(750, 100, 125, 50), 
                    "Load Your Game"))
            LoadGame();
        if (GUI.Button(new Rect(750, 200, 125, 50), 
                    "Reset Save Data"))
            ResetData();
    }

    [Serializable]
    class SaveData {
        public int savedInt;
        public float savedFloat;
        public bool savedBool;
    }

    void SaveGame() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedInt = intToSave;
        data.savedFloat = floatToSave;
        data.savedBool = boolToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame() {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                        File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            intToSave = data.savedInt;
            floatToSave = data.savedFloat;
            boolToSave = data.savedBool;
            Debug.Log("Game data loaded!");
        } else {
            Debug.LogError("There is no save data!");
        }
    }

    void ResetData() {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat")) {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            intToSave = 0;
            floatToSave = 0.0f;
            boolToSave = false;
            Debug.Log("Data reset complete!");
        } else {
            Debug.LogError("No save data to delete.");
        }
    }
}
