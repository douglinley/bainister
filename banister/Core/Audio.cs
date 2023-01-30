using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace banister.Core;

public class Audio
{
    public const int MaxVolume = 10;

    private static Dictionary<string, Song> _tracks;
    private static Dictionary<string, SoundEffect> _soundEffects;
    private static Random _rand;
    private static int _musicVolume;
    private static int _soundEffectVolume;

    static Audio()
    {
        _tracks = new Dictionary<string, Song>();
        _soundEffects = new Dictionary<string, SoundEffect>();
        _rand = new Random();
        _musicVolume = 5;
        _soundEffectVolume = 1;

        MediaPlayer.Volume = MusicLevel;
    }

    private static float MusicLevel => _musicVolume / (float)MaxVolume;

    private static float SoundEffectLevel => _soundEffectVolume / (float)MaxVolume;

    public static void AddMusicTrack(string trackName, Song track)
    {
        _tracks.Add(trackName, track);
    }

    public static void AddSoundEffect(string trackName, SoundEffect effect)
    {
        _soundEffects.Add(trackName, effect);
    }

    public static void PlayMusicTrack(string trackName)
    {
        if (_tracks.TryGetValue(trackName, out Song track))
        {
            MediaPlayer.Play(track);
        }
    }

    public static void PlaySoundEffect(string effectName)
    {
        if (_soundEffects.TryGetValue(effectName, out SoundEffect effect))
        {
            effect.Play(SoundEffectLevel, 0f, 0f);
        }
    }

    public static void PlayRandomSoundEffect(string[] effectNames)
    {
        PlaySoundEffect(effectNames[_rand.Next(effectNames.Length)]);
    }

    public static void IncreaseSoundEffectVolume()
    {
        if (_soundEffectVolume == MaxVolume) return;

        _soundEffectVolume++;
    }

    public static void DecreaseSoundEffectVolume()
    {
        if (_soundEffectVolume == 0) return;

        _soundEffectVolume--;
    }

    public static void IncreaseMusicVolume()
    {
        if (_musicVolume == MaxVolume) return;

        _musicVolume++;
        MediaPlayer.Volume = MusicLevel;
    }

    public static void DecreaseMusicVolume()
    {
        if (_musicVolume == 0) return;

        _musicVolume--;
        MediaPlayer.Volume = MusicLevel;
    }

    public static void StopMusic()
    {
        MediaPlayer.Stop();
    }
}
