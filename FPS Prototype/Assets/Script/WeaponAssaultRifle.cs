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

    public void StartWeaponAction(int type = 0)
    {
        //���콺 ���� Ŭ��(���� ����)
        if(type == 0)
        {
            //���Ӱ���
            if(weaponSetting.isAutomaticAttack)
            {
                StartCoroutine(OnAttackLoop());
            }
            //�ܹ߰���
            else
            {
                OnAttack();
            }
        }
    }

    public void StopWeaponAction(int type = 0)
    {
        //���콺 ���� Ŭ��(���� ����)
        if(type == 0)
        {
            StopCoroutine(OnAttackLoop());
        }
    }

    private IEnumerator OnAttackLoop()
    {
        while(true)
        {
            OnAttack();

            yield return null;
        }
    }

    public void OnAttack()
    {
        if(Time.time - lastAttackTime > weaponSetting.attackRate)
        {
            //�ٰ����� ���� ������ �� ����
            if(animator.MoveSpeed > 0.5f)
            {
                return;
            }

            //�����ֱⰡ �Ǿ�� ������ �� �ֵ��� �ϱ� ���� ���� �ð� ����
            lastAttackTime = Time.time;

            //���� �ִϸ��̼� ���
            animator.Play("Fire", -1, 0);
        }
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
