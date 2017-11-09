using System;
using UnityEngine;

namespace BidOn
{
    public class AudioModel : Singleton<AudioModel>
    {
        // AudioSource which will be used for background sounds
        public AudioSource No3DSource;
        //Clip that plays when garbage is take in hand
        public AudioClip TakeTrashClip;
        //Won audio clip
        public AudioClip WonClip;
        //Array related matches audio clips of when a garbage is dropped into the garbage tank
        public TrashColorContainer[] TrashClips;
    }

    [Serializable]
    public struct TrashColorContainer
    {
        public GarbageTankColor Color;
        public AudioClip Clip;
    }
}