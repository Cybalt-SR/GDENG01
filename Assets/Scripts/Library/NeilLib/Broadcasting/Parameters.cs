using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
 * Data model that holds parameters to be passed alongside observer functions
 * 
 * Structured similary to Android's Intent class.
 * Created By: NeilDG
 * Modifications by: GabrielR
 */
public class Parameters
{
    //basic supported parcelable types
    private Dictionary<string, char> charData;
    private Dictionary<string, int> intData;
    private Dictionary<string, bool> boolData;
    private Dictionary<string, float> floatData;
    private Dictionary<string, double> doubleData;
    private Dictionary<string, short> shortData;
    private Dictionary<string, long> longData;
    private Dictionary<string, string> stringData;

    //reference type parcelable
    private Dictionary<string, ArrayList> arrayListData;
    private Dictionary<string, object> objectListData;


    public Parameters()
    {
        charData = new Dictionary<string, char>();
        intData = new Dictionary<string, int>();
        boolData = new Dictionary<string, bool>();
        floatData = new Dictionary<string, float>();
        doubleData = new Dictionary<string, double>();
        shortData = new Dictionary<string, short>();
        longData = new Dictionary<string, long>();
        stringData = new Dictionary<string, string>();
        arrayListData = new Dictionary<string, ArrayList>();
        objectListData = new Dictionary<string, object>();
    }

    public void PutExtra(string paramName, bool value)
    {
        boolData.Add(paramName, value);
    }

    public void PutExtra(string paramName, int value)
    {
        intData.Add(paramName, value);
    }

    public void PutExtra(string paramName, char value)
    {
        charData.Add(paramName, value);
    }

    public void PutExtra(string paramName, float value)
    {
        floatData.Add(paramName, value);
    }

    public void PutExtra(string paramName, double value)
    {
        doubleData.Add(paramName, value);
    }

    public void PutExtra(string paramName, short value)
    {
        shortData.Add(paramName, value);
    }

    public void PutExtra(string paramName, long value)
    {
        longData.Add(paramName, value);
    }

    public void PutExtra(string paramName, string value)
    {
        stringData.Add(paramName, value);
    }

    public void PutExtra(string paramName, ArrayList arrayList)
    {
        arrayListData.Add(paramName, arrayList);
    }

    public void PutExtra(string paramName, object[] objectArray)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.AddRange(objectArray);
        PutExtra(paramName, arrayList);
    }

    public void PutObjectExtra(string paramName, object value)
    {
        objectListData.Add(paramName, value);
    }

    public int GetIntExtra(string paramName, int defaultValue)
    {
        if (intData.ContainsKey(paramName))
        {
            return intData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public char GetCharExtra(string paramName, char defaultValue)
    {
        if (charData.ContainsKey(paramName))
        {
            return charData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public bool GetBoolExtra(string paramName, bool defaultValue)
    {
        if (boolData.ContainsKey(paramName))
        {
            return boolData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public float GetFloatExtra(string paramName, float defaultValue)
    {
        if (floatData.ContainsKey(paramName))
        {
            return floatData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public double GetDoubleExtra(string paramName, double defaultValue)
    {
        if (doubleData.ContainsKey(paramName))
        {
            return doubleData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public short GetShortExtra(string paramName, short defaultValue)
    {
        if (shortData.ContainsKey(paramName))
        {
            return shortData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public long GetLongExtra(string paramName, long defaultValue)
    {
        if (longData.ContainsKey(paramName))
        {
            return longData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public string GetStringExtra(string paramName, string defaultValue)
    {
        if (stringData.ContainsKey(paramName))
        {
            return stringData[paramName];
        }
        else
        {
            return defaultValue;
        }
    }

    public ArrayList GetArrayListExtra(string paramName)
    {
        if (arrayListData.ContainsKey(paramName))
        {
            return arrayListData[paramName];
        }
        else
        {
            return null;
        }
    }

    public object[] GetArrayExtra(string paramName)
    {
        ArrayList arrayListData = GetArrayListExtra(paramName);

        if (arrayListData != null)
        {
            return arrayListData.ToArray();
        }
        else
        {
            return null;
        }
    }

    public object GetObjectExtra(string paramName)
    {
        if (objectListData.ContainsKey(paramName))
        {
            return objectListData[paramName];
        }
        else
        {
            return null;
        }
    }

    public IEnumerable GetAll()
    {
        IEnumerable[] dictionaries = {
        charData,
        intData,
        boolData,
        floatData,
        doubleData,
        shortData,
        longData,
        stringData,
        arrayListData,
        objectListData
        };

        var merged_dictionary = new List<object>();
        foreach (var dictionary in dictionaries)
        {
            foreach (var kvp in dictionary)
            {
                merged_dictionary.Add(kvp);
            }
        }
        return merged_dictionary;
    }
}
