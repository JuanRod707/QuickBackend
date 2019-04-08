namespace QuickBackend.Domain
{
    public struct AddUserMessage
    {
        public int UserId;
        public bool Success;
        public string Message;
    }
}