using System;
using System.Collections;
using System.Collections.Generic;
using Global;
using UnityEngine;

public enum SoundType
{
   Tick,
   Click,
   Pickup,
   TaskComplete,
   FootStep1,
   FootStep2
}

[Serializable]
public struct SoundObject
{
   [SerializeField] private SoundType m_SoundType;
   [SerializeField] private AudioClip m_AudioClip;

   public SoundType SoundType => m_SoundType;
   public AudioClip AudioClip => m_AudioClip;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoSingleton<SoundManager>
{
   [SerializeField] private SoundObject[] m_SoundObjects;
   
   [SerializeField] private AudioSource m_BGAudioSource;
   [SerializeField] private AudioSource m_OneShotAudioSource;

   private void Start()
   {
      
   }

   public void PlaySoundOneShot(SoundType soundType)
   {
      AudioClip clip = Array.Find(m_SoundObjects, x => x.SoundType == soundType).AudioClip;
      m_OneShotAudioSource.PlayOneShot(clip);
   }
}
