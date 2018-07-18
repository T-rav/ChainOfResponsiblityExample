namespace Implementation
{
    public class RequestResult
    {
        public bool Approved { get; set; }
        public IApprover By { get; set; }
        public string Notes { get; set; }
    }
}