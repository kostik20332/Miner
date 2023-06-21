using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElicMining : MonoBehaviour
{
    public static double elickAmount;
    public double storageFillAmount;
    public double storageSize;
    public double storageFillPercent;
    public Image elickLevel;
    public TMP_Text storageFillAmountText;
    public TMP_Text storageSizeText;


    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        storageFillAmountText.text = "" + (float)Math.Round(storageFillAmount, 1) + "/";
        storageSizeText.text = "" + (float)Math.Round(storageSize, 1);
        storageFillPercent = storageFillAmount / storageSize;
        elickLevel.fillAmount = (float)storageFillPercent;
        if (storageFillPercent <= 1.0)
        {
            if((storageSize - storageFillAmount) > 3.0)
            {
                storageFillAmount += 3.0;
            }
            else
            {
                storageFillAmount += (storageSize - storageFillAmount);
            }
        }
    }

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedElickAmount = elickAmount;
        data.savedStorageFillAmount = storageFillAmount;
        data.savedStorageSize = storageSize;
        data.savedStorageFillPercent = storageFillPercent;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            elickAmount = data.savedElickAmount;
            storageFillAmount = data.savedStorageFillAmount;
            storageSize = data.savedStorageSize;
            storageFillPercent = data.savedStorageFillPercent;

            Debug.Log("Game data loaded!");
        }
        else
        {
            elickAmount = 1;
            storageFillAmount = 0;
            storageSize = 1000;
            storageFillPercent = 0;
            Debug.LogError("There is no save data!");
        }
    }

    void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            elickAmount = 1;
            storageFillAmount = 0;
            storageSize = 1000;
            storageFillPercent = 0;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}

[Serializable]
class SaveData
{
    public double savedElickAmount;
    public double savedStorageFillAmount;
    public double savedStorageSize;
    public double savedStorageFillPercent;
}