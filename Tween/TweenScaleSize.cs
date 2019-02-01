﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace uTools
{

    public class TweenScaleSize : Tween<Vector2>
    {

        private Vector2 mValue;

        RectTransform mTransform;
        Vector2 mSizeDelta;
        RectTransform cachedTransform
        {
            get
            {
                if (mTransform == null)
                {
                    mTransform = transform as RectTransform;
                    mSizeDelta = mTransform.sizeDelta;
                }
                return mTransform;
            }
        }

        public override Vector2 value
        {
            get { return mValue; }
            set
            {
                mValue = value;
                if (cachedTransform != null)
                {
                    cachedTransform.sizeDelta = new Vector2(mSizeDelta.x * value.x, mSizeDelta.y * value.y);
                }
                
            }
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = from + factor * (to - from);
        }

        public static TweenScaleSize Begin(GameObject go, Vector2 from, Vector2 to, float duration = 1f, float delay = 0f)
        {
            TweenScaleSize comp = Tweener.Begin<TweenScaleSize>(go, duration);
            comp.value = from;
            comp.from = from;
            comp.to = to;
            comp.duration = duration;
            comp.delay = delay;
            if (duration <= 0)
            {
                comp.Sample(1, true);
                comp.enabled = false;
            }
            return comp;
        }
    }
}
