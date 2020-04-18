using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmBar : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = BeatSystem.Instance.SecondsPerHalfBeat * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = BeatSystem.Instance.TimeTillNextBeat();
    }
}
