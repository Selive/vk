using JetBrains.Annotations;
using VkNet.Abstractions.Utils;
using VkNet.Model;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

/// <inheritdoc />
[UsedImplicitly]
public sealed class ImplicitFlowLoginForm : AbstractAuthorizationForm
{
	/// <inheritdoc />
	public ImplicitFlowLoginForm(IRestClient restClient, IAuthorizationFormHtmlParser htmlParser)
		: base(restClient, htmlParser)
	{
	}

	/// <inheritdoc />
	public override ImplicitFlowPageType GetPageType() => ImplicitFlowPageType.LoginPassword;

	/// <inheritdoc />
	protected override void FillFormFields(VkHtmlFormResult form, IApiAuthParams authParams)
	{
		if (form.Fields.ContainsKey(AuthorizationFormFields.Email))
		{
			form.Fields[AuthorizationFormFields.Email] = authParams.Login;
		}

		if (form.Fields.ContainsKey(AuthorizationFormFields.Password))
		{
			form.Fields[AuthorizationFormFields.Password] = authParams.Password;
		}

		form.Headers = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "content-type", "application/x-www-form-urlencoded" },
			{ "origin", "https://oauth.vk.com" },
			{ "referer", "https://oauth.vk.com/" }
		};
	}
}