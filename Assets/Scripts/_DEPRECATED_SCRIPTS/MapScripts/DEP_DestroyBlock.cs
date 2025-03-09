using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DEP_DestroyBlock : MonoBehaviour
{
    private string tagBullet = "Bullet";
    //private string layerInvincible = "Invincible";

    public AudioClip sfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagBullet))
        {
            float playSFXTime = 1f;
            DEP_SoundsPlayer.Instance.PlaySFX(sfx, 0.8f ,playSFXTime);

            // 레이어 예외처리
            //if (collision.gameObject.layer == LayerMask.NameToLayer(layerInvincible))
            //    Break;

            //collision.gameObject.GetComponent<BulletController>().StopInvoke();

            collision.gameObject.GetComponent<DEP_BulletController>().isDestroyed = true;
            //Destroy(collision.gameObject);
            //StartCoroutine(LateDestroy(collision));
        }
    }

    private IEnumerator LateDestroy(Collider2D collision)
    {
        DEP_GameManager.Instance.canRetry = false;
        yield return new WaitForSeconds(1f);
        MakeBullet();
        DEP_GameManager.Instance.canRetry = true;
    }

    private void MakeBullet()
    {
        DEP_PlayerController.Instance.MakeBullet();
        DEP_PlayerController.Instance.isBulletSelected = false;
        DEP_PlayerController.Instance.selectAvailable = true;
        DEP_PlayerController.Instance.bulletDestroyed = true;
        DEP_PlayerController.Instance.UseItem(DEP_PlayerController.Instance.selectedItem);
    }

}
