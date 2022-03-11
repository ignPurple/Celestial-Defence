using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    
    public List<SubAnimator> animatorsList;
    private Dictionary<string, Animator> animators;

    void Awake() {
        animators = new Dictionary<string, Animator>();

        foreach (SubAnimator animator in this.animatorsList) {
            animators.Add(animator.name.ToUpper(), animator.animator);
        }
    }

    public Animator GetAnimator(string name) {
        return this.animators[name.ToUpper()];
    }

    [System.Serializable]
    public class SubAnimator {
        public string name;
        public Animator animator;
    }
}
