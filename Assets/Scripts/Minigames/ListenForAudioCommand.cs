
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Based on a tutorial posted here: https://github.com/bryanrtboy/InputTutorial
/// This script will be taking microphone input and checking how loud it is
/// </summary>
public class ListenForAudioCommand : MonoBehaviour
{
	void Update()
	{
		float db = MicInput.MicLoudnessinDecibels;

		Debug.Log("Volume is " + MicInput.MicLoudness.ToString("##.#####") + ", decibels is :" + MicInput.MicLoudnessinDecibels.ToString("######"));
	}

	float NormalizedLinearValue(float v)
	{
		float f = Mathf.InverseLerp(.000001f, .001f, v);
		return f;
	}

	float NormalizedDecibelValue(float v)
	{
		float f = Mathf.InverseLerp(-114.0f, 6f, v);
		return f;
	}
}