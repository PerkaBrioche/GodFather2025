using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class sensibilityController : MonoBehaviour
{
    [Header("Mapping touches 1..9 -> sensitivity")]
    public float min = 0.2f;      // valeur pour la touche 1
    public float step = 0.25f;    // incrément par numéro (1->2->3...)
    public int maxKey = 9;        // touches 1..maxKey

    [Header("Options de sauvegarde")]
    public bool saveToPlayerPrefs = true;
    public string prefsKey = "MouseSensitivity";


    [Header("Event")]
    public UnityEvent<float> OnSensitivityChanged; // tu peux abonner d'autres scripts via l'inspector

    public static float CurrentSensitivity { get; private set; } = 1f;

    void Awake()
    {
        // Charger la sensibilité si on sauvegarde
        if (saveToPlayerPrefs && PlayerPrefs.HasKey(prefsKey))
        {
            CurrentSensitivity = PlayerPrefs.GetFloat(prefsKey, CurrentSensitivity);
        }

        UpdateUI();
        OnSensitivityChanged?.Invoke(CurrentSensitivity);
    }

    void Update()
    {
        // Ecouter les touches Alpha1..Alpha9
        for (int i = 1; i <= maxKey; i++)
        {
            KeyCode key = KeyCode.Alpha1 + (i - 1); // Alpha1, Alpha2, ...
            if (Input.GetKeyDown(key))
            {
                SetSensitivityFromKey(i);
            }
        }
    }

    void SetSensitivityFromKey(int keyNumber)
    {
        print("Change sensi");
        float newSensitivity = min + (keyNumber - 1) * step;
        SetSensitivity(newSensitivity);
        Debug.Log($"Sensibilité définie sur {newSensitivity} (touche {keyNumber})");
    }

    public void SetSensitivity(float value)
    {
        CurrentSensitivity = value;

        if (saveToPlayerPrefs)
        {
            PlayerPrefs.SetFloat(prefsKey, CurrentSensitivity);
            PlayerPrefs.Save();
        }

        UpdateUI();
        OnSensitivityChanged?.Invoke(CurrentSensitivity);
    }

    void UpdateUI()
    {

    }

}
