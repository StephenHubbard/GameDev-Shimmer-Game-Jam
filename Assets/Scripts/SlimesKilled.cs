using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimesKilled : MonoBehaviour
{
    [SerializeField] private TMP_Text slimesKilledText;
    [SerializeField] public int slimesKilled = 0;

    private void Update() {
        slimesKilledText.text = slimesKilled.ToString();
    }
}
