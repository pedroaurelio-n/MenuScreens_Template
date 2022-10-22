using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using PedroAurelio.Utils;

namespace PedroAurelio.MenuScreens
{
    #region Entry Enums
    public enum EntryMode
    {
        NONE,
        FADE,
        ZOOM
    }
    #endregion

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(CanvasGroup))]
    [DisallowMultipleComponent]
    public class MenuPage : MonoBehaviour
    {
        public bool ExitOnNewPagePush = false;

        [Header("Dependencies")]
        [SerializeField] private RectTransform rectTransform;

        [Header("General Settings")]
        [SerializeField, Range(0.1f, 5f)] private float animationDuration = 1f;
        
        [Header("Entry Settings")]
        [SerializeField] private AudioClip entryClip;
        [SerializeField] private EntryMode entryMode = EntryMode.NONE;
        [SerializeField] private UnityEvent onEntryStart;
        [SerializeField] private UnityEvent onEntryCompletion;

        [Header("Exit Settings")]
        [SerializeField] private AudioClip exitClip;
        [SerializeField] private EntryMode exitMode = EntryMode.NONE;
        [SerializeField] private UnityEvent onExitStart;
        [SerializeField] private UnityEvent onExitCompletion;

        private CanvasGroup _canvasGroup;

        private Coroutine _animationCoroutine;
        private Tween _animationTween;
        private Coroutine _audioCoroutine;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Enter(bool playAudio)
        {
            switch (entryMode)
            {
                case EntryMode.FADE: FadeIn(playAudio); break;
                case EntryMode.ZOOM: ZoomIn(playAudio); break;
                default: DefaultIn(playAudio); break;
            }
        }

        public void Exit(bool playAudio)
        {
            switch (exitMode)
            {
                case EntryMode.FADE: FadeOut(playAudio); break;
                case EntryMode.ZOOM: ZoomOut(playAudio); break;
                default: DefaultOut(playAudio); break;
            }
        }

        private void FadeIn(bool playAudio)
        {
            if (_animationTween.IsActive())
                _animationTween.Kill();

            _canvasGroup.alpha = 0f;
            _animationTween = DOTweenUtils.UIFade(_canvasGroup, 1f, animationDuration, () => onEntryStart?.Invoke(), () => onEntryCompletion?.Invoke());

            PlayEntryClip(playAudio);
        }

        private void FadeOut(bool playAudio)
        {
            if (_animationTween.IsActive())
                _animationTween.Kill();

            _canvasGroup.alpha = 1f;
            _animationTween = DOTweenUtils.UIFade(_canvasGroup, 0f, animationDuration, () => onExitStart?.Invoke(), () => onExitCompletion?.Invoke());

            PlayExitClip(playAudio);
        }

        private void ZoomIn(bool playAudio)
        {
            if (rectTransform == null)
                return;

            if (_animationTween.IsActive())
                _animationTween.Kill();

            rectTransform.localScale = Vector3.zero;
            _animationTween = DOTweenUtils.UIScale(rectTransform, Vector3.one, animationDuration, () => onEntryStart?.Invoke(), () => onEntryCompletion?.Invoke());

            PlayEntryClip(playAudio);
        }

        private void ZoomOut(bool playAudio)
        {
            if (rectTransform == null)
                return;

            if (_animationTween.IsActive())
                _animationTween.Kill();

            rectTransform.localScale = Vector3.one;
            _animationTween = DOTweenUtils.UIScale(rectTransform, Vector3.zero, animationDuration, () => onExitStart?.Invoke(), () => onExitCompletion?.Invoke());

            PlayExitClip(playAudio);
        }

        private void DefaultIn(bool playAudio)
        {
            if (_animationTween.IsActive())
                _animationTween.Kill();

            onEntryStart?.Invoke();
            onEntryCompletion?.Invoke();

            PlayEntryClip(playAudio);
        }

        private void DefaultOut(bool playAudio)
        {
            if (_animationTween.IsActive())
                _animationTween.Kill();
            
            onExitStart?.Invoke();
            onExitCompletion?.Invoke();

            PlayExitClip(playAudio);
        }

        #region Audio Methods
        private void PlayEntryClip(bool playAudio)
        {
            if (!playAudio || entryClip == null)
                return;
            
            if (_audioCoroutine != null)
                StopCoroutine(_audioCoroutine);
        }

        private void PlayExitClip(bool playAudio)
        {
            if (!playAudio || exitClip == null)
                return;
            
            if (_audioCoroutine != null)
                StopCoroutine(_audioCoroutine);
        }
        #endregion
    }
}