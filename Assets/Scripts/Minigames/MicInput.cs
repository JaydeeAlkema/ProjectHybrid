using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the microphone input necessary for the Fire Minigame.
/// It will listen to the microphone on the mobile device for a few seconds and then analyze it.
/// If the required amount of dB is not achieved, it will record another segment to analyze.
/// 
/// Based on a tutorial posted here: https://github.com/bryanrtboy/InputTutorial
/// </summary>
public class MicInput : MonoBehaviour
{
	[SerializeField] private string _device;
	[SerializeField] private bool _isInitialized;

	private static float micLoudness;
	private static float micLoudnessinDecibels;

	private AudioClip _clipRecord;
	private AudioClip _recordedClip;
	private int _sampleWindow = 128;

	public static float MicLoudness { get => micLoudness; set => micLoudness = value; }
	public static float MicLoudnessinDecibels { get => micLoudnessinDecibels; set => micLoudnessinDecibels = value; }

	//mic initialization
	public void InitMic()
	{
		if(_device == null)
		{
			_device = Microphone.devices[0];
		}
		_clipRecord = Microphone.Start(_device, true, 999, 44100);
		_isInitialized = true;
	}

	public void StopMicrophone()
	{
		Microphone.End(_device);
		_isInitialized = false;
	}

	//get data from microphone into audioclip
	float MicrophoneLevelMax()
	{
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
		if(micPosition < 0) return 0;
		_clipRecord.GetData(waveData, micPosition);
		// Getting a peak on the last 128 samples
		for(int i = 0; i < _sampleWindow; i++)
		{
			float wavePeak = waveData[i] * waveData[i];
			if(levelMax < wavePeak)
			{
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}

	//get data from microphone into audioclip
	float MicrophoneLevelMaxDecibels()
	{

		float db = 20 * Mathf.Log10(Mathf.Abs(micLoudness));

		return db;
	}
	public float FloatLinearOfClip(AudioClip clip)
	{
		StopMicrophone();

		_recordedClip = clip;

		float levelMax = 0;
		float[] waveData = new float[_recordedClip.samples];

		_recordedClip.GetData(waveData, 0);
		// Getting a peak on the last 128 samples
		for(int i = 0; i < _recordedClip.samples; i++)
		{
			float wavePeak = waveData[i] * waveData[i];
			if(levelMax < wavePeak)
			{
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}

	public float DecibelsOfClip(AudioClip clip)
	{
		StopMicrophone();

		_recordedClip = clip;

		float levelMax = 0;
		float[] waveData = new float[_recordedClip.samples];

		_recordedClip.GetData(waveData, 0);
		// Getting a peak on the last 128 samples
		for(int i = 0; i < _recordedClip.samples; i++)
		{
			float wavePeak = waveData[i] * waveData[i];
			if(levelMax < wavePeak)
			{
				levelMax = wavePeak;
			}
		}

		float db = 20 * Mathf.Log10(Mathf.Abs(levelMax));

		return db;
	}

	void Update()
	{
		// levelMax equals to the highest normalized value power 2, a small number because < 1
		// pass the value to a static var so we can access it from anywhere
		micLoudness = MicrophoneLevelMax();
		micLoudnessinDecibels = MicrophoneLevelMaxDecibels();
	}

	// start mic when scene starts
	void OnEnable()
	{
		InitMic();
		_isInitialized = true;
	}

	//stop mic when loading a new level or quit application
	void OnDisable()
	{
		StopMicrophone();
	}

	void OnDestroy()
	{
		StopMicrophone();
	}

	// make sure the mic gets started & stopped when application gets focused
	void OnApplicationFocus(bool focus)
	{
		if(focus)
		{
			Debug.Log("Focus");

			if(!_isInitialized)
			{
				Debug.Log("Init Mic");
				InitMic();
			}
		}
		if(!focus)
		{
			Debug.Log("Pause");
			StopMicrophone();
			Debug.Log("Stop Mic");

		}
	}
}
