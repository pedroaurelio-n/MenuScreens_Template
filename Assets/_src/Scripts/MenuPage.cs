using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.MenuScreens
{
    #region Entry Enums
    public enum EntryMode
    {
        NONE,
        FADE,
        SLIDE,
        ZOOM
    }

    public enum EntryDirection
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }
    #endregion

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(CanvasGroup))]
    [DisallowMultipleComponent]
    public class MenuPage : MonoBehaviour
    {
        public bool ExitOnNewPagePush = false;

        [Header("General Settings")]
        [SerializeField, Range(0.1f, 5f)] private float animationSpeed = 1f;
        
        [Header("Entry Settings")]
        [SerializeField] private AudioClip entryClip;
        [SerializeField] private EntryMode entryMode = EntryMode.NONE;
        [SerializeField] private EntryDirection entryDirection = EntryDirection.LEFT;

        [Header("Exit Settings")]
        [SerializeField] private AudioClip exitClip;
        [SerializeField] private EntryMode exitMode = EntryMode.NONE;
        [SerializeField] private EntryDirection exitDirection = EntryDirection.LEFT;

        private RectTransform _rectTransform;
        private AudioSource _audioSource;
        private CanvasGroup _canvasGroup;

        private Coroutine _animationCoroutine;
        private Coroutine _audioCoroutine;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _audioSource = GetComponent<AudioSource>();
            _canvasGroup = GetComponent<CanvasGroup>();

            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
            _audioSource.spatialBlend = 0f;
        }

        public void Enter(bool playAudio)
        {
            switch (entryMode)
            {
                case EntryMode.FADE: FadeIn(playAudio); break;
                case EntryMode.SLIDE: SlideIn(playAudio); break;
                case EntryMode.ZOOM: ZoomIn(playAudio); break;
            }
        }

        public void Exit(bool playAudio)
        {
            switch (entryMode)
            {
                case EntryMode.FADE: FadeOut(playAudio); break;
                case EntryMode.SLIDE: SlideOut(playAudio); break;
                case EntryMode.ZOOM: ZoomOut(playAudio); break;
            }
        }

        private void FadeIn(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }

        private void FadeOut(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }

        private void SlideIn(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }

        private void SlideOut(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }

        private void ZoomIn(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }

        private void ZoomOut(bool playAudio)
        {
            if (_animationCoroutine != null)
                StopCoroutine(_animationCoroutine);
        }
    }
}