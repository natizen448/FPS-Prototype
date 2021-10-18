using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAssaultRifle : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipTakeOutWeapon;   //���� ���� ����

    [Header("Weapon Setting")]
    [SerializeField]
    private WeaponSetting weaponSetting; //���� ����

    private float lastAttackTime = 0; //������ �߻� �ð� üũ��

    private AudioSource audioSource;            //���� ��� ������Ʈ
    private PlayerAnimatorController animator; //�ִϸ��̼� ��� ����

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<PlayerAnimatorController>();
    }

    private void OnEnable()
    {
        //���� ���� ���� ���
        PlaySound(audioClipTakeOutWeapon);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();         //���� ������� ���带 ��������ϰ�
        audioSource.clip = clip;    //���ο� ���� clip���� ��ü ��
        audioSource.Play();         //���� ���
    }


}
