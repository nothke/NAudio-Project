//#define ENABLE_SPATIALIZER_API // remove if no spatializer
//#define USE_OCULUS_AUDIO
//#define AUDIO_MANAGER
//#define POOLING

using UnityEngine;
using UnityEngine.Audio;

public static class NAudio
{
    const float standardMinDistance = 1;
    const float standardSpread = 150;

    public static AudioSource Play(
        this AudioClip clip, Vector3 position,
        float volume = 1, float pitch = 1,
        float spread = standardSpread,
        float minDistance = standardMinDistance,
        AudioMixerGroup mixerGroup = null)
    {
        GameObject go;
        AudioSource source;

#if POOLING
        if (AudioManager.e)
        {
            source = AudioManager.e.GetNextSource();
            go = source.gameObject;
        }
        else
        {
            go = new GameObject("AudioTemp");
            source = go.AddComponent<AudioSource>();
        }
#else
        go = new GameObject("AudioTemp");
        source = go.AddComponent<AudioSource>();
#endif

        go.transform.position = position;

        source.spatialBlend = 1; // makes the source 3d
        source.minDistance = minDistance;

        source.loop = false;
        source.clip = clip;

        source.volume = volume;
        source.pitch = pitch;
        source.spread = spread;

        source.dopplerLevel = 0;

        source.outputAudioMixerGroup = mixerGroup;

#if ENABLE_SPATIALIZER_API
        source.spatialize = true;
#endif

#if AUDIO_MANAGER
        source.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, AudioManager.e.reverbCurve);
        //source.outputAudioMixerGroup = AudioManager.e.currentGroup;


#endif

        source.Play();

        if (pitch == 0) pitch = 100;

#if !POOLING
        GameObject.Destroy(source.gameObject, clip.length * (1 / pitch));
#endif

        return source;
    }

    public static AudioSource Play(
        this AudioClip[] clips, Vector3 position,
        float volume = 1, float pitch = 1,
        float spread = standardSpread,
        float minDistance = standardMinDistance,
        AudioMixerGroup mixerGroup = null)
    {
        if (clips == null) { Debug.Log("Clips array is null"); return null; }
        if (clips.Length == 0) { Debug.Log("No clips in array"); return null; }

        return Play(clips[Random.Range(0, clips.Length)], position, volume, pitch, spread, minDistance, mixerGroup);
    }

    // AUDIO SOURCE CREATION

    public static AudioSource CreateSource(
        Transform at, AudioClip clip = null,
        float volume = 1, float pitch = 1, 
        bool loop = true, bool playAtStart = false,
        float minDistance = standardMinDistance,
        float spread = standardMinDistance,
        float spatialBlend = 1,
        AudioMixerGroup mixerGroup = null)
    {
        GameObject go = new GameObject("AudioLoop");
        go.transform.parent = at;
        go.transform.localPosition = Vector3.zero;

        AudioSource source = go.AddComponent<AudioSource>();

        source.loop = loop;
        source.clip = clip;

        source.volume = volume;
        source.spatialBlend = spatialBlend;
        source.spread = spread;
        source.minDistance = minDistance;

        source.playOnAwake = playAtStart;

        source.outputAudioMixerGroup = mixerGroup;

#if USE_OCULUS_AUDIO
        source.gameObject.AddComponent<ONSPAudioSource>();
#endif

        return source;
    }
}
