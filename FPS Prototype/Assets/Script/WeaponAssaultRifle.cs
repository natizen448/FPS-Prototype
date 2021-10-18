using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAssaultRifle : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipTakeOutWeapon;   //무기 장착 사운드

    [Header("Weapon Setting")]
    [SerializeField]
    private WeaponSetting weaponSetting; //무기 설정

    private float lastAttackTime = 0; //마지막 발사 시간 체크용

    private AudioSource audioSource;            //사운드 재생 컴포넌트
    private PlayerAnimatorController animator; //애니메이션 재생 제어

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<PlayerAnimatorController>();
    }

    private void OnEnable()
    {
        //무기 장착 사운드 재생
        PlaySound(audioClipTakeOutWeapon);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();         //기존 재생중인 사운드를 재생중지하고
        audioSource.clip = clip;    //새로운 사운드 clip으로 교체 후
        audioSource.Play();         //사운드 재생
    }


}
