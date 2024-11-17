using UnityEngine;

public static class AnimatorController
{
    public static class State
    {
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }
}