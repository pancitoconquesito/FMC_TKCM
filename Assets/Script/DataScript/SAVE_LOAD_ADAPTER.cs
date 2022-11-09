using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SAVE_LOAD_ADAPTER//: ISaveLoadSystem
{
    public static void SAVE_DATA_GAME(DATA_GAME dataGame)
    {
        try
        {
            string dataPath = Application.persistentDataPath + "/game.save";
            FileStream fileStream = new FileStream(dataPath, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, dataGame);
            fileStream.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("LA DATA NO PUDO GUARDARSE!!!");
        }
    }
    public static DATA_GAME LOAD_DATA_GAME()
    {
        string dataPath = Application.persistentDataPath + "/game.save";
        if (File.Exists(dataPath))
        {
            try
            {
                FileStream fileStream = new FileStream(dataPath, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                DATA_GAME data_game = (DATA_GAME)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                return data_game;
            }
            catch (Exception e)
            {
                Debug.LogError("LA DATA NO PUDO CARGARSE!!!");
                return null;
            }
        }
        else
        {
            Debug.LogError("_LA DATA NO PUDO CARGARSE!!!");
            return null;
        }
    }
}
