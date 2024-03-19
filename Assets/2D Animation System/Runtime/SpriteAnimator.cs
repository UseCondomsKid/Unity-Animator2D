using System;
using UnityEngine;

namespace UseCondomsKid.Animator2D
{
    public class SpriteAnimator : MonoBehaviour
    {
        public SpriteAnimation CurrentAnimation { get { return _currentAnimation; } }

        [SerializeField] private bool _playAutomatically = false;
        [SerializeField] private SpriteAnimationObject _spriteAnimationObject;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private SpriteAnimation _currentAnimation;

        public bool HasAnimation(string name) => _spriteAnimationObject.SpriteAnimations.Exists(a => a.Name == name);
        public SpriteAnimation DefaultAnimation => _spriteAnimationObject.SpriteAnimations.Count > 0 ? _spriteAnimationObject.SpriteAnimations[0] : null;

        // Events
        public event Action OnAnimationTrigger;
        public event Action OnAnimationComplete;

        private void OnEnable()
        {
            if (_playAutomatically)
            {
                if (DefaultAnimation == null)
                {
                    Debug.LogError($"PlayAutomatically is set to TRUE but no default animations were found.");
                    return;
                }

                Play(DefaultAnimation);
            }
        }

        private void LateUpdate()
        {
            if (_spriteRenderer == null)
                return;

            if (_currentAnimation != null)
            {
                _spriteRenderer.sprite = _currentAnimation.UpdateAnimation();
            }
        }

        private void OnValidate()
        {
            if (_spriteRenderer != null && DefaultAnimation != null)
            {
                _spriteRenderer.sprite = DefaultAnimation.GetFrame(0);
            }
        }

        public SpriteAnimator Play(string name)
        {
            if (!HasAnimation(name))
            {
                Debug.LogError($"Animation with name '{name}' not found");
                return null;
            }

            Play(GetAnimationByName(name));
            return this;
        }

        public SpriteAnimator Play(SpriteAnimation spriteAnimation)
        {
            if (spriteAnimation == null || spriteAnimation.Frames.Count <= 0)
            {
                Debug.LogError("An null or invalid SpriteAnimation object was passed.");
                return null;
            }

            ChangeAnimation(spriteAnimation);

            return this;
        }

        public SpriteAnimator PlayIfNotPlaying(string name)
        {
            if (!HasAnimation(name))
            {
                Debug.LogError($"Animation with name '{name}' not found");
                return null;
            }

            PlayIfNotPlaying(GetAnimationByName(name));
            return this;
        }

        public SpriteAnimator PlayIfNotPlaying(SpriteAnimation spriteAnimation)
        {
            if (spriteAnimation == null)
            {
                Debug.LogError("An null or invalid SpriteAnimation object was passed.");
                return null;
            }

            if (_currentAnimation.Name == spriteAnimation.Name)
                return null;
            ChangeAnimation(spriteAnimation);

            return this;
        }

        public void Pause() => _currentAnimation.Stop(resetFrame: false);
        public void Resume() => _currentAnimation.Start(resetFrame: false);
        public void Restart() => _currentAnimation.Start(resetFrame: true);


        public SpriteAnimation GetAnimationByName(string name)
        {
            for (int i = 0; i < _spriteAnimationObject.SpriteAnimations.Count; i++)
            {
                if (_spriteAnimationObject.SpriteAnimations[i].Name == name)
                {
                    return _spriteAnimationObject.SpriteAnimations[i];
                }
            }

            Debug.LogError($"Can't find animation named {name}");
            return null;
        }

        private void ChangeAnimation(SpriteAnimation spriteAnimation)
        {
            // Unsub from events
            //_currentAnimation.OnAnimationTrigger -= OnAnimationTrigger;
            //_currentAnimation.OnAnimationComplete -= OnAnimationComplete;
            OnAnimationTrigger = null;
            OnAnimationComplete = null;

            // If an animation is already playing, we stop it.
            if (_currentAnimation != null)
            {
                _currentAnimation.Stop();
            }

            // Set new animation
            _currentAnimation = spriteAnimation;
            // Sub to events
            _currentAnimation.OnAnimationTrigger += OnAnimationTrigger;
            _currentAnimation.OnAnimationComplete += OnAnimationComplete;

            // If it is not null, we start it.
            if (_currentAnimation != null)
            {
                _currentAnimation.Start();
            }

        }
    }
}