namespace MailSender.lib.Interfaces
{
    public interface IEncryptorService
    {
        string Excrypt (string str, string Password);
        string Decrypt(string str, string Password);

        byte[] Encrypt(byte[] data, string Password);
        byte [] Decrypt(byte[] data, string Password);
    }
}
