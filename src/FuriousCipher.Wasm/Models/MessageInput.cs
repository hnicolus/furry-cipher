using System;

namespace FuriousCipher.Wasm.Models
{
    public class MessageInput
    {
        public int SecretKey { get; set; } = 1;
        public string Message { get; set; } = string.Empty;
    }
}