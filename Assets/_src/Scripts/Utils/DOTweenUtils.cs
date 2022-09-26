using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

namespace PedroAurelio.Utils
{
    public class DOTweenUtils
    {
        public static Tween UIFade(CanvasGroup canvasGroup, float alpha, float duration, Action onStart = null, Action onComplete = null, 
                                    Ease ease = Ease.Unset, bool ignoreTimescale = false, UpdateType updateType = UpdateType.Normal)
        {
            onStart?.Invoke();

            if (ignoreTimescale)
                return canvasGroup.DOFade(alpha, duration).SetEase(ease).SetUpdate(true).OnComplete(() => onComplete?.Invoke());
            else
                return canvasGroup.DOFade(alpha, duration).SetEase(ease).SetUpdate(updateType).OnComplete(() => onComplete?.Invoke());
        }

        public static Tween UIScale(RectTransform rectTransform, Vector3 newScale, float duration, Action onStart = null, Action onComplete = null, 
                                    Ease ease = Ease.Unset, bool ignoreTimescale = false, UpdateType updateType = UpdateType.Normal)
        {
            onStart?.Invoke();

            if (ignoreTimescale)
                return rectTransform.DOScale(newScale, duration).SetEase(ease).SetUpdate(true).OnComplete(() => onComplete?.Invoke());
            else
                return rectTransform.DOScale(newScale, duration).SetEase(ease).SetUpdate(updateType).OnComplete(() => onComplete?.Invoke());
        }
    }
}