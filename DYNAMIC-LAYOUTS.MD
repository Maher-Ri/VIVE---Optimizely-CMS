markdown
# Dynamic Global Footer & Navbar — Summary

## What We Built
A system where Footer and Navbar content is managed from
one **SiteSettingsPage** in the CMS — no code changes needed.

---

## Files Created
| File | Purpose |
|------|---------|
| `SiteSettingsPage.cs` | CMS page that holds all global data |
| `ILayoutService.cs` | Interface for fetching layout data |
| `LayoutService.cs` | Fetches SiteSettingsPage → maps to LayoutModel |
| `IImageService.cs` | Interface for image alt text |
| `ImageService.cs` | Gets alt text from uploaded images |

## Files Updated
| File | What Changed |
|------|-------------|
| `LayoutModel.cs` | Added all footer + navbar properties |
| `ImageFile.cs` | Added namespace, removed `required` and `?` |
| `HomePageController.cs` | Replaced hardcoded data with `ILayoutService` |
| `Startup.cs` | Registered both new services |
| `_Footer.cshtml` | All values now come from `LayoutModel` |

---

## How It Works


SiteSettingsPage (CMS) ↓ LayoutService.GetLayoutModel() ↓ HomePageController → model.Layout ↓ _Layout.cshtml → _Footer.cshtml + _Navbar.cshtml


---

## Key Rules Learned


✅ Always add namespace to every file ✅ No required keyword on Optimizely properties ✅ No ? annotations on Optimizely virtual properties ✅ try/catch in LayoutService — never crash the site ✅ One file at a time → build → test → next file


---

## CMS Setup


Root → New Page → "Site Settings" └── Footer Tab ├── ☑ Show Footer ├── Logo, Address, Hours ├── Social URLs ├── Copyright Text └── Footer Links → Publish ✅


---

## Current State
| | Status |
|---|---|
| Footer | ✅ Dynamic |
| Navbar | ⏳ Coming next |
| Global (all pages) | ⚠️ Add `ILayoutService` to each new controller |
