using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace BidOn
{
    public class GarbageTankManager : Singleton<GarbageTankManager>
    {
        //All garbage tank model
        private GarbageTankModel[] _garbageTankArr;
        public ParticleSystem StarParticle;
        //Parent object for all garbage
        public GameObject Trash;
        public UnityAction WinEvent;
        public UnityAction<GarbageTankModel> AddTrashEvent;

        protected override void Awake()
        {
            base.Awake();
            _garbageTankArr = GetComponentsInChildren<GarbageTankModel>();
            var trashModelArr = Trash.GetComponentsInChildren<TrashModel>();
            foreach (var model in _garbageTankArr)
                model.MaxTrashCount = trashModelArr.Count(
                    trashModel => trashModel.GarbageTankColor == model.GarbageTankColor);

            foreach (var ctrl in GetComponentsInChildren<GarbageTankCtrl>())
                ctrl.AddTrashEvent += AddTrash;
        }

        /// <summary>
        /// Counts on the fullness of all garbage tanks.
        /// Starts the logic of winning and finishing the game.
        /// </summary>
        /// <param name="model"></param>
        private void AddTrash(GarbageTankModel model)
        {
            AddTrashEvent.Invoke(model);
            var isAllFull = model.IsTrashFull;
            if (model.IsTrashFull)
            {
                foreach (var tempModel in _garbageTankArr)
                {
                    isAllFull &= tempModel.IsTrashFull;
                    if (!tempModel.IsTrashFull)
                        break;
                }
            }
            if (isAllFull)
            {
                StarParticle.Play();
                if (WinEvent != null)
                    WinEvent.Invoke();

                StartCoroutine(GameExit(StarParticle.main.duration));
            }
        }

        /// <summary>
        /// Exit the game.
        /// </summary>
        /// <param name="duration">After what time the game will end</param>
        private IEnumerator GameExit(float duration)
        {
            while ((duration -= Time.deltaTime) > 0.0f)
                yield return null;

#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}