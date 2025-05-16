namespace Aspire.Hosting;

public static class Smtp4DevHostingExtensions
{
    public static IResourceBuilder<Smtp4DevResource> AddSmtp4Dev(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null,
        int? smtpPort = null
    )
    {
        var resource = new Smtp4DevResource(name);
        const string ImageName = "rnwood/smtp4dev";
        const string Registry = "docker.io";

        return builder.AddResource(resource).WithImage(ImageName).WithImageRegistry(Registry)
            .WithHttpEndpoint(targetPort: 80, port: httpPort, name: Smtp4DevResource.HttpEndpointName)
            .WithEndpoint(targetPort: 25, port: smtpPort, name: Smtp4DevResource.SmtpEndpointName);
    }
}
