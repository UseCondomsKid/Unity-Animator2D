using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace UseCondomsKid.Animator2D
{
    [Serializable]
    public class SpriteAnimationFrame
    {
        public Sprite Sprite;
        public float Duration = 0.1f;
        public bool TriggerEvent;
    }

    [Serializable]
    public class SpriteAnimation
    {
        // Triggered when the animation encounters an event in a frame
        public event Action OnAnimationTrigger;
        // Triggered when the animation finishes
        public event Action OnAnimationComplete;

        public string Name;
        public bool Loop;
        public List<SpriteAnimationFrame> Frames;

        // The index of the currently playing frame
        private int _currentFrame;
        // Frame timer
        private float _timer;
        // Is the animation active
        private bool _active;


        // Stops the animation
        public void Stop(bool resetFrame = true)
        {
            Reset(resetFrame);
            _active = false;
        }

        // Starts the animation
        public void Start(bool resetFrame = true)
        {
            Reset(resetFrame);
            _active = true;

            var frame = GetCurrentAnimationFrame();

            if (frame == null)
            {
                return;
            }

            // If the frame isn't null, we invoke it's event because we just started the animation
            if (frame.TriggerEvent)
            {
                OnAnimationTrigger?.Invoke();
            }
        }

        // Resets the animation
        public void Reset(bool resetFrame = true)
        {
            if (resetFrame) _currentFrame = 0;
            _timer = 0;
        }

        /// <summary>
        /// Updates the animation
        /// </summary>
        /// <param name="animationSpeedMultiplier"></param>
        /// <returns>The sprite of the currently active frame</returns>
        public Sprite UpdateAnimation(float animationSpeedMultiplier = 1f)
        {
            // If the animation is not active, we return.
            if (!_active) return GetFrame(_currentFrame);

            // Increment the timer.
            _timer += Time.deltaTime * animationSpeedMultiplier;

            // Get the currently active frame
            var frame = GetCurrentAnimationFrame();

            // If it is null that means the frame doesn't exist, we return.
            if (frame == null)
            {
                return null;
            }

            // If the timer exceeds the active frame's duration, the frame ended
            if (_timer > frame.Duration)
            {
                // Reset the timer
                _timer = 0;

                // If the animation is finished and loop is false
                if (_currentFrame == Frames.Count - 1 && !Loop)
                {
                    // Invoke animation finished
                    OnAnimationComplete?.Invoke();

                    // Stop the animation
                    Stop(false);
                }
                else
                {
                    // If not, we increment the current frame
                    _currentFrame = (_currentFrame + 1) % Frames.Count;

                    // Invoke the frame's event if it has one
                    if (GetCurrentAnimationFrame().TriggerEvent)
                    {
                        OnAnimationTrigger?.Invoke();
                    }
                }
            }

            return frame.Sprite;
        }

        public Sprite GetFrame(int frame)
        {
            return Frames[frame].Sprite;
        }

        // Returns the currently active frame, using the current frame index.
        public SpriteAnimationFrame GetCurrentAnimationFrame()
        {
            return Frames[_currentFrame];
        }
    }

}