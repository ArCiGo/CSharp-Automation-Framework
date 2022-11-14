# Automation framework made with C# + Selenium

## The project 💻

A *C# + Selenium* template to create new automation framework projects!

**Before you continue reading:** You can check in this repository a [full sample](https://github.com/ArCiGo/CSharp-Automation-Framework/tree/SampleProject_1) made based on this template.

## Tools ⚙️

* *C# v10.0.*
* *.NET Core v6.0.400.*
* *Microsoft .NET Test SDK v17.0.0.*
* *NUnit v3.13.2.-*
    * *NUnit 3 Test Adapter v4.0.0.*
* *Selenium.-*
    * *Selenium Support v3.141.0.*
    * *Selenium WebDriver v3.141.0.*
    * *Selenium WebDriver ChromeDriver v104.0.5112.7900.*
    * *Selenium WebDriver GeckoDriver v0.31.0.1.*
* *DotNetSeleniumExtras WaitHelpers v3.11.0.*
* *ExtentReports v4.1.0.*
* *Bogus v33.1.1.*
* *Serilog v2.11.0.-*
    * *Serilog Sinks Console v4.0.1.*
    * *Serilog Sinks File v5.0.0.*
* *CsvHelper v27.1.1.*
* *RestSharp v106.12.0.*

## Project folder structure 🗂️

```bash
.
├── PageObjectModel/
│   ├── Components/
│   │   ├── Home
│   │   └── Results
│   ├── Pages
│   └── Utilities
└── Tests/
    ├── APIAndData/
    │   ├── Client
    │   ├── Data
    │   └── Models
    ├── UI/
    │   └── AutomationResources
    └── Utilities
```

## Setup 🛠️

I developed the code using a Mac, but it should work on a PC.

The following steps can be executed using a terminal (I use [hyper](https://hyper.is/)).

1. Clone the repo.-

```bash
> https://github.com/ArCiGo/CSharp-Automation-Framework.git

> git checkout master
```

2. Install the packages.-

```bash
> dotnet build
```

3. Don't forget to update the *Selenium WebDriver ChromeDriver* and the *Selenium WebDriver GeckoDriver*.

4. Delete the folders, files or branches you don't need.

## Run the tests ⚡️

```bash
# Run all the tests
> dotnet test
```

```bash
# Running the tests by category

# UI tests
> dotnet test --filter TestCategory=UI

# API test
> dotnet test --filter TestCategory=API

# CSV test
> dotnet test --filter TestCategory=CSV
```

When you execute the tests, new folders are generated at the workspace root (**APIReports** and **UIReports**). Inside of these folders, you are going to see the *index.html* reports (you can open them using your favorite browser). Also, new log files are generated (*APIlogs-^.txt*, *UIlogs-^.txt*) and you can open them using any text editor.

![UI Report Sample 1](./Image01.png)

![UI Report Sample 2](./Image02.png)

![Log Report Sample](./Image03.png)

## Collaborations 👨‍🏭

Do you want to collaborate or contribute in this project? No problem! I'm open to improvements, comments and suggestions. Just do a PR with your suggestions and we can discuss them 😀
