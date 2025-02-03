using System;
using System.Text;

namespace Naninovel
{
    public class NaniToScriptAssetConverter : IRawConverter<Script>
    {
        public RawDataRepresentation[] Representations { get; } = {
            new(".nani", "text/plain")
        };

        public Script ConvertBlocking (byte[] obj, string name) => Script.FromText(Guid.NewGuid().ToString("N"), Encoding.UTF8.GetString(obj), name);

        public UniTask<Script> Convert (byte[] obj, string name) => UniTask.FromResult(ConvertBlocking(obj, name));

        public object ConvertBlocking (object obj, string name) => ConvertBlocking(obj as byte[], name);

        public async UniTask<object> Convert (object obj, string name) => await Convert(obj as byte[], name);
    }
}
