using System.Linq;
using UnityEngine;

namespace BidOn
{
    public class AudioCtrl : Singleton<AudioCtrl>
    {
        private void Start()
        {
            Controller.TouchManager.TakeTrashEvent += TakeTrash;
            Controller.GarbageTankManager.WinEvent += Won;
            Controller.GarbageTankManager.AddTrashEvent += AddTrash;
        }

        /// <summary>
        /// There is a sound of throwing out a certain type of trash.
        /// </summary>
        /// <param name="model">Garbage Tank Model.</param>
        private void AddTrash(GarbageTankModel model)
        {
            AudioSource.PlayClipAtPoint(Model.Audio.TrashClips.FirstOrDefault(
                color=> color.Color == model.GarbageTankColor).Clip, model.Transform.position);
        }

        /// <summary>
        /// Playing a won melody.
        /// </summary>
        private void Won()
        {
            Model.Audio.No3DSource.PlayOneShot(Model.Audio.WonClip);
        }

        /// <summary>
        /// Play take trash audio.
        /// </summary>
        /// <param name="trashModel"></param>
        private static void TakeTrash(TrashModel trashModel)
        {
            AudioSource.PlayClipAtPoint(Model.Audio.TakeTrashClip, trashModel.Transform.position);
        }
    }
}