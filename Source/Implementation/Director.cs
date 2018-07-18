namespace Implementation
{
    public class Director : IApprover
    {
        private IApprover _approver;

        public string Name { get; }

        public Director(string name)
        {
            Name = name;
        }

        public void SetSuccessor(IApprover approver)
        {
            _approver = approver;
        }

        public RequestResult ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 5000.00)
            {
                return new RequestResult{ Approved = true, By = this, Notes = $"Your purchase of {purchase.Description} has been approved"};
            }

            return new RequestResult{Approved = false, By = this, Notes = "I need to speak with the CEO first!"};
        }
    }
}