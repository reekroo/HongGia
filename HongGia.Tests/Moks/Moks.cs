using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace HongGia.Tests.Moks
{
	public static class Moks
	{
		public static HtmlHelper<TModel> CreateHtmlHelper<TModel>(bool clientValidationEnabled, bool unobtrusiveJavascriptEnabled, ViewDataDictionary dictionary = null)
		{
			if (dictionary == null)
				dictionary = new ViewDataDictionary { TemplateInfo = new TemplateInfo() };

			var mockViewContext = new Mock<ViewContext>(
				new ControllerContext(
					new Mock<HttpContextBase>().Object,
					new RouteData(),
					new Mock<ControllerBase>().Object),
				new Mock<IView>().Object,
				dictionary,
				new TempDataDictionary(),
				new Mock<TextWriter>().Object);

			mockViewContext.SetupGet(c => c.UnobtrusiveJavaScriptEnabled).Returns(unobtrusiveJavascriptEnabled);
			mockViewContext.SetupGet(c => c.FormContext).Returns(new FormContext { FormId = "myForm" });
			mockViewContext.SetupGet(c => c.ClientValidationEnabled).Returns(clientValidationEnabled);
			mockViewContext.SetupGet(c => c.ViewData).Returns(dictionary);
			var mockViewDataContainer = new Mock<IViewDataContainer>();
			mockViewDataContainer.Setup(v => v.ViewData).Returns(dictionary);

			return new HtmlHelper<TModel>(mockViewContext.Object, mockViewDataContainer.Object);
		}
	}
}
