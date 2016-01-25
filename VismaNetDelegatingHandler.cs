public class VismaNetDelegatingHandler : DelegatingHandler
{
    private readonly int _context;
    public VismaNetDelegatingHandler(int context)
    {
        _context = context;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("ipp-company-id", _context.ToString());
        request.Headers.Add("ipp-application-type", "Visma.net Financials");
        return base.SendAsync(request, cancellationToken);
    }
}
