using Obfuz;
using Obfuz.EncryptionVM;
using UnityEngine;

namespace Launcher
{
    public class ObfuzInitialize : MonoBehaviour
    {
        // 初始化EncryptionService后被混淆的代码才能正常运行，
        // 因此尽可能地早地初始化它。
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void SetUpStaticSecretKey()
        {
#if ENABLE_OBFUZ
            Debug.Log("Enable Obfuz");
            Debug.Log("SetUpStaticSecret begin");
            EncryptionService<DefaultStaticEncryptionScope>.Encryptor = new GeneratedEncryptionVirtualMachine(Resources.Load<TextAsset>("Obfuz/defaultStaticSecretKey").bytes);
            Debug.Log("SetUpStaticSecret end");
#else
            Debug.Log("Disable Obfuz");
#endif
        }
    }
}