using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
public static class SaveLoadRecodrs
{
    public static List<Game> savedGames = new List<Game>();
    public static void SaveRecodrs()
    {
        SaveLoadRecodrs.savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath это строка; выведите ее в логах и вы увидите расположение файла сохранений
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt");
        bf.Serialize(file, SaveLoadRecodrs.savedGames);
        file.Close();
        Debug.Log(Application.persistentDataPath + "/savedGames.txt");
    }
    public static void LoadRecodrs()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.txt", FileMode.Open);
            SaveLoadRecodrs.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
            Debug.Log(Application.persistentDataPath + "/savedGames.txt");
            SaveLoadRecodrs.savedGames = SaveLoadRecodrs.savedGames.OrderByDescending(gm => gm.scoreField).ToList();
        }
    }
}
