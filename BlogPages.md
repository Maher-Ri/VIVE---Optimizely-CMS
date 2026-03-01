My thought process
markdown
# Blog System — VIVEcms

## Overview
Two page types work together:
- **BlogPage** → lists all posts (listing page)
- **BlogPostPage** → displays a single post (detail page)

---

## Content Tree Structure


Start └── Blog (BlogPage) ├── Post 1 (BlogPostPage) → /en/blog/post-1/ ├── Post 2 (BlogPostPage) → /en/blog/post-2/ └── Post 3 (BlogPostPage) → /en/blog/post-3/


---

## Files Created

### Models
| File | Purpose |
|------|---------|
| `BlogPage.cs` | Listing page type |
| `BlogPageViewModel.cs` | Holds FeaturedPost + RegularPosts |
| `BlogPostPage.cs` | Single post page type |
| `BlogPostPage.HeaderSection.cs` | PostDate, FeaturedImage, AuthorName, AuthorAvatar, Tags |
| `BlogPostPage.Content.cs` | IntroContent, Quote, Images, Gallery, ClosingContent |
| `BlogPostPage.RelatedSection.cs` | ShowRelatedSection, RelatedPosts |
| `BlogPostPage.CommentSection.cs` | ShowCommentSection, CommentFormTitle |
| `BlogPostPage.NavigationSection.cs` | ShowNavigation |
| `CommentFormModel.cs` | Form data (Author, Email, Comment...) |

### Controllers
| File | Purpose |
|------|---------|
| `BlogPageController.cs` | Fetches BlogPostPage children → splits into Featured + Regular |
| `BlogPostPageController.cs` | Renders single post + handles comment form POST |

### Views


Views/ BlogPage/ Index.cshtml ← listing (featured left, grid right) BlogPostPage/ Index.cshtml ← single post wrapper Sections/ _HeaderSection ← bg image, title, author, date _MainContentSection ← intro, quote, images _GallerySection ← 6 images grid _ClosingContentSection ← final text + heading _RelatedSection ← 2 related posts (auto or manual) _CommentSection ← comment form _NavigationSection ← previous article (auto-fetched)


---

## How It Works

### Listing Page


BlogPageController └── GetChildren(currentPage.ContentLink) └── OrderByDescending(PostDate) ├── First → FeaturedPost (left, large) └── Rest → RegularPosts (right, grid)


### Single Post


BlogPostPageController └── GET → renders all 7 sections └── POST → SubmitComment() └── Logs to console └── TempData success message └── Redirect back to post


### Auto-Fetched Data
| Data | How |
|------|-----|
| Related Posts | Siblings ordered by date (most recent 2) |
| Previous Post | Older sibling by date |
| Post URLs | `IUrlResolver.GetUrl(post.ContentLink)` |

---

## CMS Tabs — BlogPostPage


┌────────┬──────────────┬──────────────────┬──────────┬──────────┬────────────┐ │ SEO │ Header │ Post Content │ Related │ Comments │ Navigation │ └────────┴──────────────┴──────────────────┴──────────┴──────────┴────────────┘


---

## Key Rules


✅ BlogPostPage MUST be child of BlogPage in content tree ✅ Post URLs are auto-generated from page Name ✅ If a field is empty → its section does not render ✅ Related + Navigation posts are auto-fetched (no manual work) ✅ Comment form logs to terminal console (development)