# Empty CMS template

## How to run

Chose one of the following options to get started. 

### Windows

Prerequisities
- .NET SDK 8+
- SQL Server 2016 Express LocalDB (or later)

```bash
$ dotnet run
````

### Any OS with Docker

Prerequisities
- Docker
- Enable Docker support when applying the template
- Review the .env file and make changes where necessary to the Docker-related variables

```bash
$ docker-compose up
````

> Note that this Docker setup is just configured for local development. Follow this [guide to enable HTTPS](https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md).

#### Reclaiming Docker Image Space

1. Backup the App_Data/\${DB_NAME}.mdf and App_Data/\${DB_NAME}.ldf DB restoration files for safety
2. Run `docker compose down --rmi all` to remove containers, networks, and images associated with the specific project instance
3. In the future, run `docker compose up` anytime you want to recreate the images and containers

### Any OS with external database server

Prerequisities
- .NET SDK 8+
- SQL Server 2016 (or later) on a external server, e.g. Azure SQL

Create an empty database on the external database server and update the connection string accordingly.

```bash
$ dotnet run
````




Step 1: The Base Page Model (SEO) - Creating a foundation so all pages share SEO fields.

Step 2: The Home Page Model - Defining the specific fields for Section A and Section B.

Step 3: The ViewModels - Setting up a structure to pass the Page Data + Layout Data (Navbar/Footer) to the views.

Step 4: The Controller - Creating the controller to tie the Model and ViewModel together.

Step 5: Shared Layout & Views - Creating the _Layout.cshtml, Navbar, and Footer partials.

Step 6: The Home Page View - Rendering Section A and Section B.

# Optimizely CMS — Project Foundation

## Overview
This document covers the foundational architecture of the VIVEcms Optimizely project.
It explains the core building blocks required before any page or section can be built,
why each decision was made, and the best practices followed.

---

## Table of Contents
1. [Step 1 — Base Page Model (SitePageData)](#step-1--base-page-model-sitepagedata)
2. [Step 2 — Page Type Registration (HomePage)](#step-2--page-type-registration-homepage)
3. [Step 3 — ViewModel Architecture](#step-3--viewmodel-architecture)
4. [Step 4 — Page Controller](#step-4--page-controller)
5. [View Structure](#view-structure)
6. [Current State](#current-state)
7. [Architecture Decisions](#architecture-decisions)
8. [Next Steps](#next-steps)

---

## Step 1 — Base Page Model (SitePageData)

### What
A base class that every page type in the project inherits from.
It holds all **shared properties** that apply to all pages — primarily SEO fields.

### Why
Without a base class, every page type (HomePage, AboutPage, ContactPage, etc.)
would need to redefine the same SEO properties individually.
This violates the **DRY principle** (Don't Repeat Yourself).



SitePageData ← defined once here ├── HomePage ← inherits all SEO fields automatically ├── AboutPage ← inherits all SEO fields automatically ├── ContactPage ← inherits all SEO fields automatically └── ...


### Key Concepts Used

#### `[Display]` Attribute
Controls how properties appear in the Optimizely CMS editor.

```csharp
[Display(
Name        = "Meta Title",        // label shown in the CMS
Description = "Used for SEO",      // helper text shown to editors
Order       = 10,                  // controls the order of fields
GroupName   = "SEO")]              // groups the field into a tab
public virtual string MetaTitle { get; set; }

GroupName = "SEO" — Custom Tab

Using GroupName with a custom string automatically creates a dedicated tab in the CMS editor. All fields sharing the same GroupName are grouped together.

CMS Editor Tabs:
┌─────────┬──────────────────┬─────┐
│  Content │       SEO        │ ... │
└─────────┴──────────────────┴─────┘
     ↑
     All [Display(GroupName = "SEO")] properties appear here

virtual Properties — Required by Optimizely

All properties on Optimizely page models must be virtual.

csharp
// ✅ Correct
public virtual string MetaTitle { get; set; }

// ❌ Wrong — Optimizely cannot proxy this
public string MetaTitle { get; set; }


Why virtual? Optimizely does not store data directly in your class. Instead, it generates a proxy class at runtime that intercepts property calls and fetches the actual values from the database. Non-virtual properties cannot be intercepted — they will always return null.

Step 2 — Page Type Registration (HomePage)
What

The HomePage class is the first concrete page type in the project. It inherits from SitePageData and adds its own content properties.

Why

In Optimizely, a page type must be explicitly registered so the CMS knows it exists and can offer it to content editors when creating new pages.

Key Concepts Used
[ContentType] Attribute

Registers the class as a page type in the Optimizely database. Without this attribute, the CMS will not recognize the class.

csharp
[ContentType(
DisplayName = "Home Page",             // shown in CMS page type picker
GUID        = "your-unique-guid",      // permanent identity in the database
Description = "The main home page")]   // helper text for editors
public class HomePage : SitePageData { }

GUID — Permanent Identity

Optimizely uses the GUID to track this page type in the database permanently.

⚠️  Important Rules:
- Every page type must have a UNIQUE GUID
- NEVER change the GUID after the project goes live
- Changing the GUID breaks the connection to existing content in the database
- Generate using: Visual Studio → Tools → Create GUID (format 4)
               or any online GUID generator

SystemTabNames.Content — Default Content Tab

Properties grouped under SystemTabNames.Content appear in the default Content tab — the first tab editors see when editing a page.

csharp
[Display(GroupName = SystemTabNames.Content)]
public virtual string Title { get; set; }

XhtmlString — Rich Text Editor

When a property uses the XhtmlString type, Optimizely automatically renders a full TinyMCE Rich Text Editor for that field in the CMS.

csharp
// XhtmlString → editor gets bold, italic, links, lists, etc.
public virtual XhtmlString BodyContent { get; set; }

// string → editor gets a plain text input
public virtual string Subtitle { get; set; }
Use XhtmlString when:   ✅ Content needs formatting (bold, links, lists)
Use string when:        ✅ Simple text (titles, labels, short descriptions)

Step 3 — ViewModel Architecture
What

Two classes were created to handle how data flows from the CMS to the views:

LayoutModel.cs — holds data for the Navbar and Footer (global components)
PageViewModel<T>.cs — a generic wrapper that combines any page type with the LayoutModel
Why

A Razor view can only have one model. But the layout (_Layout.cshtml) needs Navbar/Footer data, while the page view needs the page content. The PageViewModel<T> solves this by combining both into a single object.

csharp
// Generic — works with any page type
public class PageViewModel<T> where T : SitePageData
{
public T CurrentPage { get; set; }    // ← page-specific content
public LayoutModel Layout { get; set; } // ← navbar + footer data
}

How the Views Consume It
_Layout.cshtml
└── reads from Model.Layout
    ├── Model.Layout.NavLinks    → renders Navbar
    └── Model.Layout.FooterText  → renders Footer

Index.cshtml (e.g. HomePage)
└── reads from Model.CurrentPage
    ├── Model.CurrentPage.HeroTitle   → renders page content
    └── Model.CurrentPage.BodyContent → renders page content

Why Generic <T>?

The PageViewModel<T> pattern means one ViewModel works for all page types.

csharp
// HomePage
PageViewModel<HomePage>

// AboutPage — same pattern, no new ViewModel needed
PageViewModel<AboutPage>

// ContactPage — same pattern
PageViewModel<ContactPage>

Step 4 — Page Controller
What

A controller that handles requests for the HomePage page type.

Why

Every page type in Optimizely needs a corresponding controller to fetch the data and return the correct view.

Key Concepts
PageController<T> — Optimizely's Magic Routing

Instead of defining manual URL routes, Optimizely handles routing automatically.

Content editor creates a page of type "HomePage" in the CMS
└── Names it "Start"
    └── Optimizely automatically routes all requests to /start
        └── HomePageController.Index() is called
            └── HomePage data is injected as the parameter
csharp
public class HomePageController : PageController<HomePage>
{
public IActionResult Index(HomePage currentPage)
//                         ↑
//          Optimizely fetches ALL properties from the database
//          and injects the fully populated page object here
{
    var model = new PageViewModel<HomePage>
    {
        CurrentPage = currentPage,   // ← CMS content
        Layout      = GetLayout()    // ← Navbar + Footer data
    };

    return View(model);
}
}

Automatic Data Injection

The currentPage parameter is not manually fetched. Optimizely resolves the current URL, finds the matching content in the database, maps all properties to the HomePage object, and injects it automatically.

View Structure

After completing Steps 1–4, the following view structure was established:

Views/
├── Shared/
│   ├── _Layout.cshtml     ← master layout wrapper (reads Model.Layout)
│   ├── _Head.cshtml       ← <head> tag: SEO meta tags, CSS links
│   ├── _Navbar.cshtml     ← site navigation (reads Model.Layout.Nav*)
│   └── _Footer.cshtml     ← site footer (reads Model.Layout.Footer*)
│
├── _ViewStart.cshtml      ← sets _Layout.cshtml as default layout
│
└── HomePage/
└── Index.cshtml       ← homepage content (reads Model.CurrentPage)

Data Flow Through the Views
HomePageController
└── PageViewModel<HomePage>
    ├── .Layout       →  _Layout.cshtml
    │                      ├── _Head.cshtml    (SEO tags ← SitePageData)
    │                      ├── _Navbar.cshtml  (nav data ← LayoutModel)
    │                      └── _Footer.cshtml  (footer data ← LayoutModel)
    │
    └── .CurrentPage  →  HomePage/Index.cshtml
                           └── page sections

Current State

At the end of Step 4, the following was true:

Component	Status	Source
SEO Meta Tags	✅ Dynamic	SitePageData properties
<head> content	✅ Dynamic (SEO only)	_Head.cshtml + SitePageData
Navbar	❌ Static (hardcoded)	LayoutModel with dummy data
Footer	❌ Static (hardcoded)	LayoutModel with dummy data
HomePage sections	❌ Static (hardcoded)	Index.cshtml with hardcoded HTML

The view structure was correctly split into separate partials, but only the SEO section was pulling real dynamic data from the CMS. All other components — Navbar, Footer, and page sections — were still rendering hardcoded content.

Architecture Decisions
✅ Base Class Over Repetition

Shared properties (SEO fields) live in SitePageData once. All page types inherit them automatically. No duplication. No maintenance burden.

✅ Generic ViewModel

PageViewModel<T> works for every page type in the project. No need to create a separate ViewModel for each page.

✅ Separated View Responsibilities

Each partial view has one job:

_Head.cshtml → manages only <head> content
_Navbar.cshtml → manages only navigation
_Footer.cshtml → manages only footer
Index.cshtml → manages only page-specific content
✅ virtual Properties Enforced

All model properties across the project use virtual without exception. This is a hard rule — non-virtual properties silently return null in Optimizely.

Next Steps
The Problem

Navbar and Footer are global components — they appear on every page and should be manageable from a single place in the CMS. Page sections (Hero, About, Services, etc.) should be editable per page.

Recommended Approach
For Navbar & Footer → SiteSettings Page

Create a dedicated SiteSettingsPage content type that holds all global data. This page lives once in the CMS content tree and is loaded by every controller.

CMS Content Tree:
└── Root
├── Site Settings      ← one page, holds Navbar + Footer data
├── Home               ← HomePage
├── About              ← AboutPage
└── ...

For Page Sections → Direct Properties with Custom Tabs

Each section on the page becomes a group of properties organized into a dedicated tab in the CMS editor.

HomePage Tabs:
┌──────────┬──────────────────┬──────────────┬─────┐
│   SEO    │  Heading Section │ About Section│ ... │
└──────────┴──────────────────┴──────────────┴─────┘


Each section includes:

A bool ShowXxxSection toggle — hide without losing content
All section-specific properties grouped under their tab
A dedicated partial view _XxxSection.cshtml
A partial class file HomePage.XxxSection.cs
Key Rule for Sections

Use direct properties for sections unique to one page type. Refactor to Blocks only when a section needs to be shared across multiple page types.


# Optimizely CMS — HomePage: Heading Section

## Overview
This document covers the implementation of the **HeadingSection** for the HomePage
in the Optimizely CMS project (VIVEcms). It explains what was built, why each
decision was made, and the best practices followed.

---

## Table of Contents
1. [Project Structure](#project-structure)
2. [What Was Built](#what-was-built)
3. [Implementation Details](#implementation-details)
4. [Best Practice Decisions](#best-practice-decisions)
5. [How It Works in the CMS Dashboard](#how-it-works-in-the-cms-dashboard)
6. [How to Add a New Section](#how-to-add-a-new-section)

---

## Project Structure



VIVEcms/ │ ├── Models/ │ ├── Pages/ │ │ └── HomePage/ │ │ ├── HomePage.cs ← [ContentType] + Tab names only │ │ └── HomePage.HeadingSection.cs ← Heading section properties │ │ │ ├── Media/ │ │ └── ImageFile.cs ← Handles all image uploads in CMS │ │ │ └── ViewModels/ │ └── PageViewModel.cs ← Generic wrapper for page + layout │ ├── Services/ │ ├── IImageService.cs ← Interface for image helper │ └── ImageService.cs ← Gets alt text from uploaded images │ └── Views/ └── HomePage/ ├── Index.cshtml ← Main homepage view └── Sections/ └── _HeadingSection.cshtml ← Heading section partial view


---

## What Was Built

### 1. `ImageFile.cs`
Registers image uploads in the Optimizely CMS asset panel.

**Before adding this file:**
- The CMS had no upload button for images
- Optimizely did not know how to handle image file types

**After adding this file:**
- Editors can upload images via the Assets panel
- Alt text is required before publishing any image
- Every image uploaded is stored and manageable in the CMS

---

### 2. `HomePage.cs` (Partial Class — Core File)
Holds only the `[ContentType]` attribute and the `Tabs` static class.

```csharp
[ContentType(DisplayName = "Home Page", GUID = "...")]
public partial class HomePage : SitePageData
{
  public static class Tabs
  {
      public const string HeadingSection = "Heading Section";
      // future sections added here...
  }
}

3. HomePage.HeadingSection.cs (Partial Class — Section File)

Holds only the properties that belong to the Heading Section.

Properties registered:

Property	Type	Purpose
ShowHeadingSection	bool	Toggle section on/off
HeadingLeftImage	ContentReference	Left column image
HeadingLine1	string	First heading line e.g "Speak"
HeadingLine2	string	Second heading line e.g "Fitness"
HeadingLine3	string	Third heading line e.g "With Your"
HeadingAnimatedWords	string	Comma-separated animated words e.g "Work,Wellbeing,Body"
HeadingDescription	string	Right column description text
HeadingRightImage	ContentReference	Right column image
4. IImageService + ImageService

A service responsible for loading the alt text from any uploaded image.

Editor uploads image → fills Alt Text (required)
   ↓
Any view that uses that image calls ImageService.GetAltText(contentRef)
   ↓
Returns the alt text stored on the ImageFile asset

5. _HeadingSection.cshtml

A partial view that renders the heading section. Receives HomePage as its model. Injects IImageService to resolve alt text for images.

Implementation Details
How the Section is Rendered
HomePageController
  └── Creates PageViewModel<HomePage>
      └── Returns View(model)
          └── Index.cshtml
              └── Checks: Model.CurrentPage.ShowHeadingSection == true
                  └── Renders: _HeadingSection.cshtml
                      └── Reads all properties from Model (HomePage)
                      └── Resolves image alt text via @inject IImageService

How Animated Words Work

The editor enters words as a comma-separated string in the CMS:

Work,Wellbeing,Body


The view splits this string into a list and renders each word as a <b> tag:

html
<span class="ah-words-wrapper">
  <b class="is-visible">Work</b>
  <b>Wellbeing</b>
  <b>Body</b>
</span>


The first word always gets the is-visible class to match the original animation behavior.

How Images Render
csharp
// ContentReference stored in CMS
// Converted to a URL in the view:
src="@Url.ContentUrl(Model.HeadingLeftImage)"

// Alt text loaded from the ImageFile asset:
alt="@ImageService.GetAltText(Model.HeadingLeftImage)"

Best Practice Decisions
✅ Decision 1: Partial Classes for Page Models

Problem: A homepage with 9 sections could have 60+ properties in a single file. This becomes unmaintainable very quickly.

Solution: C# partial classes — one file per section.

HomePage.cs                 ← core only
HomePage.HeadingSection.cs  ← section 1 only
HomePage.AboutSection.cs    ← section 2 only
...


Why it's better:

Each file has a single responsibility
Easy to find and edit a specific section
Optimizely treats it as one class — no impact on CMS behavior
New developers can understand the structure immediately
✅ Decision 2: Custom Tab Names Per Section

Problem: Putting all properties in the default "Content" tab creates a cluttered, hard-to-use editor experience.

Solution: Each section gets its own dedicated tab in the CMS dashboard.

csharp
public static class Tabs
{
  public const string HeadingSection = "Heading Section";
  public const string AboutSection   = "About Section";
  // ...
}


Why it's better:

Clean editor experience
Editors can jump directly to the section they need
All tab names are defined in one place — easy to manage
✅ Decision 3: Show/Hide Toggle Per Section

Problem: If an editor wants to temporarily hide a section, they would have to delete all the content. This means losing all the data.

Solution: A bool ShowXxxSection property as the first property in each tab.

csharp
[Display(Name = "Show Heading Section", Order = 1, GroupName = Tabs.HeadingSection)]
public virtual bool ShowHeadingSection { get; set; }


In the view:

html
@if (Model.CurrentPage.ShowHeadingSection)
{
  @await Html.PartialAsync("_HeadingSection.cshtml", Model.CurrentPage)
}


Why it's better:

Section is hidden but all content is preserved
Editor can re-enable with one click
No risk of accidental data loss
✅ Decision 4: Alt Text Stored on the ImageFile Asset

Problem: If alt text is a property on each page, editors must fill it on every page that uses the same image. This is repetitive and error-prone.

Solution: Alt text lives on the ImageFile model with [Required].

csharp
[Required]
public virtual string AltText { get; set; }


Why it's better:

Set once, used everywhere
[Required] means the editor cannot publish an image without alt text
Consistent alt text across the entire site
Better for accessibility and SEO
✅ Decision 5: Direct Properties vs Blocks

Problem: Should each section be a Block type or direct properties on the page?

Decision: Direct properties on the page for sections that belong only to this page.

	Direct Properties	Blocks
Section unique to this page	✅ Use this	Overkill
Section shared across pages	❌ Hard to reuse	✅ Use this
Editor experience	Simple	Extra steps
Show/Hide control	Easy	Needs extra work

Rule going forward:

If a section becomes shared across multiple pages in the future, refactor it into a Block at that point. Do not over-engineer early.

✅ Decision 6: Never Modify Original HTML Structure

Problem: Modifying original CSS classes or data attributes breaks the existing design and JavaScript behavior (animations, Elementor scripts).

Rule followed strictly:

Original HTML  →  Touch NOTHING except:
                ✅ text content  → @Model.PropertyName
                ✅ image src     → @Url.ContentUrl(Model.Property)
                ✅ image alt     → @ImageService.GetAltText(Model.Property)
                ✅ add on top    → @Html.EditAttributes(x => x.Property)
                ✅ wrap with @if → for show/hide logic

                ❌ Never touch: classes, data-id, data-settings,
                                data-widget_type, inline styles

✅ Decision 7: Razor Comments Not HTML Comments

Problem: Using wrong comment syntax renders visible text in the browser.

Syntax	Type	Renders in Browser?
{{!-- --}}	Handlebars	✅ Yes (as text) — WRONG
<!-- -->	HTML	✅ Yes (as hidden comment)
@* *@	Razor	❌ Never — CORRECT

Rule: Always use @* *@ for comments in .cshtml files.

How It Works in the CMS Dashboard
HomePage in CMS Editor:
┌──────────┬──────────────────┬─────────────┬─────┐
│   SEO    │  Heading Section │ About ...   │ ... │
└──────────┴──────────────────┴─────────────┴─────┘

Inside "Heading Section" tab:
┌──────────────────────────────────────────────────┐
│  ☑  Show Heading Section                         │
│  ────────────────────────────────────────────    │
│  Left Image         [ Select from Assets 🖼️ ]   │
│  ────────────────────────────────────────────    │
│  Heading Line 1     [ Speak                  ]   │
│  Heading Line 2     [ Fitness                ]   │
│  Heading Line 3     [ With Your              ]   │
│  Animated Words     [ Work,Wellbeing,Body    ]   │
│  ────────────────────────────────────────────    │
│  Description Text   [ Powered by fitness...  ]   │
│  Right Image        [ Select from Assets 🖼️ ]   │
└──────────────────────────────────────────────────┘

How to Add a New Section

Follow these steps for every new section:

Step 1: Add the tab name in HomePage.cs

csharp
public const string NewSection = "New Section";


Step 2: Create HomePage.NewSection.cs

csharp
public partial class HomePage
{
  [Display(Name = "Show New Section", Order = 1, GroupName = Tabs.NewSection)]
  public virtual bool ShowNewSection { get; set; }

  // ... section properties
}


Step 3: Create Views/HomePage/Sections/_NewSection.cshtml

html
@model HomePage
@inject IImageService ImageService
<!-- original HTML with dynamic values only -->


Step 4: Add to Index.cshtml

html
@if (Model.CurrentPage.ShowNewSection)
{
  @await Html.PartialAsync("~/Views/HomePage/Sections/_NewSection.cshtml",
      Model.CurrentPage)
}

Notes
All virtual keywords on properties are required by Optimizely for database proxying
All GUIDs must be unique across the entire project
[UIHint(UIHint.Image)] on ContentReference properties tells the CMS to show the image picker instead of a generic content picker
IImageService is registered as Scoped in Startup.cs under the "CUSTOM APPLICATION SERVICES" section
