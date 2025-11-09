using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace app.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Secret { get; private set; } = string.Empty;
    public Settings Settings { get; private set; }

    public IndexModel(
            IOptionsSnapshot<Settings> options,
            ILogger<IndexModel> logger)
    {
        Settings = options.Value;
        _logger = logger;
    }

    public async Task OnGet()
    {
        Secret = "<Loading...>";
        var client = new SecretClient(
            new Uri(Settings.KeyVaultEndpoint),
            new DefaultAzureCredential());
        var res = await client.GetSecretAsync(Settings.SecretName);
        var secretValue = res.HasValue ? res.Value.Value : "<Failed to retrieve secret>";
        Secret = secretValue;
    }
}
