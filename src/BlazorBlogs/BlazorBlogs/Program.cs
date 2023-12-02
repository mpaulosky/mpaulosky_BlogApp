
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error", true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

// TODO: Add code here

// TODO: Feature: Add SASS support to the BlazorBlogs project.
// labels: enhancement, feature
// assignees: mpaulosky

// TODO: Feature: Add a Create Blog Post page.
// Add a page to create a new blog post. In the BlazorBlogs project, add a new page called CreateBlogPost.razor. This page should have a form with the following fields:
// labels: enhancement, feature
// assignees: mpaulosky

// FEATURE: Feature: Add a Edit Blog Post page.
// Add a page to edit a blog post. In the BlazorBlogs project, add a new page called Edit.razor.
// labels: enhancement, feature
// assignees: mpaulosky

// BUG: BUG: Fix Build and Test Action.
// Find and resolve the issue with the Build and Test Action.
// labels: bug
// assignees: mpaulosky

[ExcludeFromCodeCoverage]
public class AssemblyClassLocator;