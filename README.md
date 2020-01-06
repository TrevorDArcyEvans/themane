# **_themane_** - Totally Awesome Text Summarisation!

_We can take some text, analyse it, and generate a concise summary at the click of a button.  
There's even some parameters to play with, so you can tweak it to your tastes, but, honestly,
the defaults work just fine._

## Background:
This is a simple app to wrap three different text summarisation algorithms:
* CodePlex.OpenTextSummarizer
* Open Text Summarizer
* Text Rank

The app is written in:
* C#
* Blazor
* Dotnet Core

There is a database to authenticate users and track usage.  Database creation scripts are provided for:
* Microsoft SQL Server
* SQLite

There are also various websites which do similar summarisations:
* https://www.splitbrain.org/services/ots
* https://deepai.org/machine-learning-model/summarization
* https://deepai.org/machine-learning-model/text-tagging

## Building

```
git clone https://github.com/TrevorDArcyEvans/themane.git
dotnet restore
dotnet build
cd Themane.Web
dotnet run
```

Navigate to _http://localhost:5000/_

## Summary:
_Extractive_ summarisation works well; _abstractive_ summarisation does not.

## Discussion:
_Text summarisation_ is generating an abstract or summary of an article.  There are currently two main types of summarisation:
* _extractive_ is where the most relevant/important sentences are taken from the article and used directly in the summary.
* _abstractive_ is where the summary is written in much the same way that a human would write it.
This requires understanding of both the subject matter and language.

_Extractive_ summarisation is well known, well understood and works reasonably well.
There are several implementations available and most previous research has been on this technique.

_Abstractive_ summarisation is an emerging technique and is using artificial intelligence (AI) and machine learning (ML) methods.
There has been a lot of recent activity, probably fuelled by the current interest in AI+ML.
Whilst the technique shows a lot of promise, there are a lot of issues:
* deep understanding of AI
* very large training datasets
* resource intensive to train AI algorithms
* difficulty in training algorithms
* currently only works (at all) with _short_ articles

## References:
A very small selection of articles:
* https://www.salesforce.com/products/einstein/ai-research/tl-dr-reinforced-model-abstractive-summarization/
* https://rare-technologies.com/text-summarization-in-python-extractive-vs-abstractive-techniques-revisited/

A search in google will no doubt yield other articles.
