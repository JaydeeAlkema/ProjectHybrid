using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the microphone input necessary for the Fire Minigame.
/// It will listen to the microphone on the mobile device for a few seconds and then analyze it.
/// If the required amount of dB is not achieved, it will record another segment to analyze.
/// 
/// https://stackoverflow.com/questions/53030560/read-microphone-decibels-and-pitch-frequency
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

	//[SerializeField] private List<Microphone> microphones = new List<Microphone>();
	//[SerializeField] private AudioSource audioSource = default;

	//[SerializeField] private float rmsVal;
	//[SerializeField] private float dbVal;
	//[SerializeField] private float pitchVal;

	//float[] _samples;
	//private float[] _spectrum;
	//private float _fSample;

	//private const int QSamples = 1024;
	//private const float RefValue = 0.1f;
	//private const float Threshold = 0.02f;

	//private void Start()
	//{
	//	audioSource = GetComponent<AudioSource>();
	//	audioSource.clip = Microphone.Start("", true, 3, 44100);

	//	_samples = new float[QSamples];
	//	_spectrum = new float[QSamples];
	//	_fSample = AudioSettings.outputSampleRate;
	//}

	//private void Update()
	//{
	//	AnalyzeSound();

	//	Debug.Log("RMS: " + rmsVal.ToString("F2"));
	//	Debug.Log(dbVal.ToString("F1") + " dB");
	//	Debug.Log(pitchVal.ToString("F0") + " Hz");
	//}

	//void AnalyzeSound()
	//{
	//	GetComponent<AudioSource>().GetOutputData(_samples, 0); // fill array with samples

	//	int i;
	//	float sum = 0;
	//	for(i = 0; i < QSamples; i++)
	//	{
	//		sum += _samples[i] * _samples[i]; // sum squared samples
	//	}
	//	rmsVal = Mathf.Sqrt(sum / QSamples); // rms = square root of average
	//	dbVal = 20 * Mathf.Log10(rmsVal / RefValue); // calculate dB
	//	if(dbVal < -160) dbVal = -160; // clamp it to -160dB min

	//	GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris); // get sound spectrum
	//	float maxV = 0;
	//	var maxN = 0;
	//	for(i = 0; i < QSamples; i++)
	//	{ // find max 
	//		if(!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
	//			continue;

	//		maxV = _spectrum[i];
	//		maxN = i; // maxN is the index of max
	//	}

	//	float freqN = maxN; // pass the index to a float variable
	//	if(maxN > 0 && maxN < QSamples - 1)
	//	{ // interpolate index using neighbours
	//		var dL = _spectrum[maxN - 1] / _spectrum[maxN];
	//		var dR = _spectrum[maxN + 1] / _spectrum[maxN];
	//		freqN += 0.5f * (dR * dR - dL * dL);
	//	}

	//	pitchVal = freqN * (_fSample / 2) / QSamples; // convert index to frequency
	//}
}
