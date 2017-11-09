using UnityEngine;

namespace BidOn
{
    public class AudioEventCtrl : MonoBehaviour
    {
        private AudioSource _sources;
        private AudioSource _Sources { get { return _sources ?? (_sources = GetComponent<AudioSource>()); } }

        public void PlayAudio()
        {
            _Sources.Play();
        }

        public void StopAudio()
        {
            _Sources.Stop();
        }
    }
}