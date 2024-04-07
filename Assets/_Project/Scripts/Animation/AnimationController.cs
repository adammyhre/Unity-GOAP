using UnityEngine;

public abstract class AnimationController : MonoBehaviour {
    const float k_crossfadeDuration = 0.1f;
    
    Animator animator;
    CountdownTimer timer;
    
    float animationLength;
    
    [HideInInspector] public int locomotionClip = Animator.StringToHash("Locomotion");
    [HideInInspector] public int speedHash = Animator.StringToHash("Speed");
    [HideInInspector] public int attackClip = Animator.StringToHash("Attack");
    
    void Awake() {
        animator = GetComponentInChildren<Animator>();
        SetLocomotionClip();
        SetAttackClip();
        SetSpeedHash();
    }

    public void SetSpeed(float speed) => animator.SetFloat(speedHash, speed);
    public void Attack() => PlayAnimationUsingTimer(attackClip);
    
    void Update() => timer?.Tick(Time.deltaTime);

    void PlayAnimationUsingTimer(int clipHash) {
        timer = new CountdownTimer(GetAnimationLength(clipHash));
        timer.OnTimerStart += () => animator.CrossFade(clipHash, k_crossfadeDuration);
        timer.OnTimerStop += () => animator.CrossFade(locomotionClip, k_crossfadeDuration);
        timer.Start();
    }

    public float GetAnimationLength(int hash) {
        if (animationLength > 0) return animationLength;

        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips) {
            if (Animator.StringToHash(clip.name) == hash) {
                animationLength = clip.length;
                return clip.length;
            }
        }

        return -1f;
    }

    protected abstract void SetLocomotionClip();
    protected abstract void SetAttackClip();
    protected abstract void SetSpeedHash();
}