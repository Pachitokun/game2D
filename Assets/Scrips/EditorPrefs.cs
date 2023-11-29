using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class EditorPrefsExample
{
    const string autoSaveKey = "AutoSaveEnabled";

    [MenuItem("MyMenu/Toggle AutoSave")]
    static void ToggleAutoSave()
    {
        bool autoSaveEnabled = EditorPrefs.GetBool(autoSaveKey, false); // Obtener el valor actual o usar false si no existe
        autoSaveEnabled = !autoSaveEnabled; // Invertir el valor
        EditorPrefs.SetBool(autoSaveKey, autoSaveEnabled); // Guardar el nuevo valor
        Debug.Log("AutoSave is now: " + autoSaveEnabled);
    }
}