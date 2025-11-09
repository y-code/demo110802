namespace app;

/// <summary>
/// Represents the Web App service settings stored in Azure App Configuration service.
/// </summary>
public class Settings
{
    /// Azure Key Vault service endpoint to use to directly acquire secrets
    public string KeyVaultEndpoint { get; set; } = string.Empty;

    /// Name of the secret stored in the Azure Key Vault service
    public string SecretName { get; set; } = string.Empty;

    /// Value of the secret, indirectly acquired from Azure Key Vault service
    /// <remarks>It is mapped to a Key Vault reference.</remarks>
    public string Secret { get; set;} = string.Empty;
}

