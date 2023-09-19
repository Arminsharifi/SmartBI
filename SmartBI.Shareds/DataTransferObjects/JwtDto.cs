namespace SmartBI.Shareds.DataTransferObjects
{
    [Serializable]
    public record JwtDto
    {
        public string Token { get; private set; }
        public int ExpireTime { get; private set; }

        public JwtDto(string token, int expireTime)
        {
            Token = token;
            ExpireTime = expireTime;
        }
    }
}