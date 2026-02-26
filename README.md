markdown
# VIVEcms — Optimizely Project Foundation

## How to Run
```bash
dotnet run


Prerequisites: .NET SDK 8+, SQL Server 2016 Express LocalDB or later

Project Structure
Models/
Pages/
  SitePageData.cs              ← SEO base class for all pages
  HomePage/
    HomePage.cs                ← [ContentType] + tab names
    HomePage.HeadingSection.cs ← section properties
Media/
  ImageFile.cs                 ← handles CMS image uploads + alt text
ViewModels/
  IPageViewModel.cs            ← interface for layout views
  PageViewModel.cs             ← combines page data + layout data
  LayoutModel.cs               ← holds Navbar & Footer data
Services/
IImageService.cs / ImageService.cs   ← gets alt text from images
ILayoutService.cs / LayoutService.cs ← fetches global layout from CMS
Controllers/
HomePageController.cs
Views/
Shared/
  _Layout.cshtml / _Head.cshtml / _Navbar.cshtml / _Footer.cshtml
HomePage/
  Index.cshtml
  Sections/
    _HeadingSection.cshtml

How Data Flows
Request
└── HomePageController
      └── PageViewModel<HomePage>
            ├── .CurrentPage → Index.cshtml → page sections
            └── .Layout      → _Layout.cshtml
                                ├── _Head.cshtml    (SEO)
                                ├── _Navbar.cshtml  (global)
                                └── _Footer.cshtml  (global)

Key Files
SitePageData.cs — SEO Base Class

All page types inherit from this → automatic SEO tab in every page.

SitePageData
├── HomePage    ← gets SEO tab automatically
├── AboutPage   ← gets SEO tab automatically
└── ...

HomePage.cs — Partial Class Pattern

Split into one file per section to avoid 60+ properties in one file.

HomePage.cs                   ← [ContentType] + Tabs class only
HomePage.HeadingSection.cs    ← section 1 properties
HomePage.OurClassesSection.cs ← section 2 properties
HomePage.ServicesSection.cs   ← section 3 properties

PageViewModel<T> — Data Wrapper

One ViewModel works for all page types.

csharp
public class PageViewModel<T> : IPageViewModel
{
  public T CurrentPage { get; }       // ← page content
  public LayoutModel Layout { get; set; } // ← navbar + footer
}

LayoutService.cs — Global Layout

Fetches SiteSettingsPage from CMS Root → maps to LayoutModel.

csharp
public LayoutModel GetLayoutModel()
{
  var settings = _contentLoader
      .GetChildren<SiteSettingsPage>(SiteDefinition.Current.RootPage)
      .FirstOrDefault();

  if (settings == null) return new LayoutModel();
  return new LayoutModel { ... };
}

HomePageController.cs — Auto Routing

Optimizely handles URL routing automatically — no manual routes needed.

csharp
public IActionResult Index(HomePage currentPage)
{
  var model = new PageViewModel<HomePage>(currentPage);
  model.Layout = _layoutService.GetLayoutModel();
  return View(model);
}


Key Rules

Rule	                            Why

virtual on all properties	        Optimizely proxies data from DB
Unique GUID per page type	        Tracks content in database — never change
XhtmlString for rich text	        Gives editors TinyMCE editor
string for plain text	            Simple input fields
Namespace on every file	            Missing = CS0246 build error
No required keyword	                Breaks Optimizely proxy system
No ? on virtual properties	        Conflicts with Optimizely internals
@* *@ for Razor comments	        <!-- --> renders in HTML, {{!--}} shows as text


Sections Pattern

Every section follows the same 4 steps:

1. Add tab name in HomePage.cs
    public const string NewSection = "New Section";

2. Create HomePage.NewSection.cs
    public virtual bool ShowNewSection { get; set; }
    // ... properties

3. Create _NewSection.cshtml
    @model HomePage
    @if → show/hide
    @Model.Property → dynamic values only
    never touch classes, data-id, data-settings

4. Add to Index.cshtml
    @if (Model.CurrentPage.ShowNewSection)
    { @await Html.PartialAsync("_NewSection.cshtml", Model.CurrentPage) }

Startup.cs Registrations
csharp
services.AddScoped<IImageService,  ImageService>();
services.AddScoped<ILayoutService, LayoutService>();

CMS Setup — Site Settings Page
Root → New Page → "Site Settings" → Publish
└── Footer Tab
      ├── ☑ Show Footer
      ├── Logo, Address, Opening Hours
      ├── Social URLs
      ├── Copyright Text
      └── Footer Links


Current Status

Component	                Status
SEO (all pages)	            ✅ Dynamic via SitePageData
Page sections	            ✅ Dynamic via partial classes + show/hide toggle
Images + Alt Text	        ✅ Via ImageFile + IImageService
Footer	                    ✅ Dynamic via SiteSettingsPage
Navbar	                    ✅ Dynamic via SiteSettingsPage
Global (all pages)	        ⚠️ Add ILayoutService to each new controller